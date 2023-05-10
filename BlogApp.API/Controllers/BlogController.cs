using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _service;
        public BlogController(IMapper mapper, IBlogService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpPost("[action]")]
        public IActionResult PostBlog(AddBlogDto blogdto)
        {
            var blog = _mapper.Map<Blog>(blogdto);
            blog.CreatedDate = DateTime.Now;
            _service.Add(blog);
            return Ok(CustomResponseDto<Blog>.Success(200));
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
    }
}
