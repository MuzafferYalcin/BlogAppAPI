using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploadItems");
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBlogService _service;
        public BlogController(IMapper mapper, IBlogService service, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> PostBlog(int id, IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return BadRequest("no file");
            }
            try
            {
                if (!Directory.Exists(_uploadPath))
                    Directory.CreateDirectory(_uploadPath);

                var filePath = Path.Combine(_uploadPath, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var blog = _service.Get(p=>p.Id == id);
                blog.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                _service.Update(blog);

                return Ok("File uploaded successfully.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }



        [HttpGet("[action]")]
        public IActionResult GetBlogWithYazar()
        {
            var blogs = _service.GetBlogWithYazarCategory();
            var blogdtos = _mapper.Map<List<BlogDto>>(blogs);
            return Ok(blogdtos);
        }

        [HttpGet("[action]")]
        public IActionResult GetBlogs()
        {
            var blogs = _service.GetAll(); //veri tabanından blogları çekiyorum
            var blogDtos = _mapper.Map<List<BlogDto>>(blogs); // veri tabanından çektiğim blogları sumak için blogDto nesnesine çeviriyorum
            return Ok(CustomResponseDto<List<BlogDto>>.Success(200, blogDtos));
        }

        [HttpGet("[action]/{Id}")]
        public IActionResult GetBlog(int Id)
        {
            var blog = _service.Get(b => b.Id == Id);
            return Ok(CustomResponseDto<Blog>.Success(200,blog));
        }

        [HttpGet("deneme")]
        public IActionResult Deneme()
        {
            var blogPost =  _service.Get(b => b.Id == 5);
            if (blogPost == null)
            {
                return NotFound();
            }

            var fileId = blogPost.ImageUrl;
            return Ok(fileId);
        }
        [HttpPost("uploadresim")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                // Dosyayı yükleme işlemi (yukarıda verilen örnek kod)

                var relativePath = "uploadItems/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, relativePath);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                
                var blog = _service.Get(p => p.Id == 5);
                blog.ImageUrl = relativePath;
                _service.Add(blog);

                

                return Ok("File uploaded and saved to the database successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }

}
