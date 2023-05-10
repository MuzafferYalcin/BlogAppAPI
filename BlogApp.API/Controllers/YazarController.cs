using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private readonly IYazarService _service;
        private readonly IMapper _mapper;

        public YazarController(IMapper mapper, IYazarService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult Getir()
        {
            var yazars = _service.GetAll();
            var yazarDto = _mapper.Map<List<YazarDto>>(yazars);
            return Ok(CustomResponseDto<List<YazarDto>>.Success(200,yazarDto));
        }
    }
}
