using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YorumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService; 
        private readonly IYorumService _yorumService;

        public YorumController(IYorumService yorumService, IBlogService blogService, IMapper mapper)
        {
            _yorumService = yorumService;
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{blogId}")]
        public IActionResult GetAllBlogId(int blogId)
        {
            var blog = _blogService.Get(b => b.Id == blogId);
            if (blog == null)
            {
                return Ok(CustomResponseDto<NoContentDto>.Fail(404,"bulunamadı"));
            }
            var yorums = _yorumService.GetAllByBLogId(blogId);
            var yorumDtos = _mapper.Map<List<YorumDto>>(yorums);
            return Ok(CustomResponseDto<List<YorumDto>>.Success(200, yorumDtos)); 
        }

        [HttpPost("[action]/Yazar/{yazarId}/blog/{blogId}")]
        public IActionResult PostYorum(int blogId , int yazarId , YorumDto yorumDto )
        {
            var blog = _blogService.Get(b => b.Id ==blogId);
            if (blog == null)
            {
                return Ok(CustomResponseDto<NoContentDto>.Fail(404,"Blog Bulunamadı"));
            }
            var yorum = _mapper.Map<Yorum>(yorumDto);
            yorum.YazarId = yazarId;
            yorum.BlogId = blogId;
            yorum.CreatedDate = DateTime.Now;
            _yorumService.Add(yorum);
            return Ok(yorum);
        }

        [HttpGet("[action]/{yazarId}")]
        public IActionResult GetAllWithYazar(int yazarId)
        {
            var yorums = _yorumService.GetAllByYazarId(yazarId);
            var yorumdtos = _mapper.Map<List<YorumDto>>(yorums);
            return Ok(CustomResponseDto<List<YorumDto>>.Success(200, yorumdtos));
        }

    }
}
