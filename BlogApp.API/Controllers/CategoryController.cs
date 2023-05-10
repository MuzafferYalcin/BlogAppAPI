using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet("[action]")]
        public IActionResult GetCategories()
        {
            var categories = _service.GetAll();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);    
            return Ok(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }

    }
}
