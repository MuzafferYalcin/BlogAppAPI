using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IYazarService _service;
        private readonly IMapper _mapper;
        public AuthController( IMapper mapper, IYazarService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("[action]")]
        public IActionResult Register(YazarForRegister yazarForRegister)
        {
            var yazar = _mapper.Map<Yazar>(yazarForRegister);
            yazar.CreatedDate = DateTime.Now;
            _service.Add(yazar);
            return Ok(yazar);
        }


        [HttpPost("[action]")]
        public IActionResult Login(YazarForLogin yazarForLogin)
        {
            var yazar = _service.Get(y => y.Email == yazarForLogin.Email);
            if (yazar == null)
            {
                return BadRequest("yazar bulunamadı");
            }
            if (yazar.Password != yazarForLogin.Password)
            {
                return BadRequest("yanlış Şifre");
            }

            return Ok(new
            {
                token = GenerateJwtToken(yazar)
            }); ;
        }

        private string GenerateJwtToken(Yazar yazar)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eee9b1be342b4e7991810cde7c18c27095116baa26245f00b249867cdf48832602caa79677032d7ee0b7bd71787731cd90e9d1ef34d818c6b5133b3cb15dd34c");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, yazar.Id.ToString()),
                    new Claim(ClaimTypes.Name, yazar.UserName),
                    new Claim("isAdmin", yazar.IsAdmin.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
