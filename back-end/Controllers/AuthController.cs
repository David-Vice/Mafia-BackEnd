﻿using back_end.Dtos;
using back_end.Models;
using back_end.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
       
        [HttpPost("register")]
        public async Task<ActionResult<User?>> Register(AuthDto userDto)
        {
            User? user = await _authService.Register(userDto);
            if (user==null)
            {
                return BadRequest("This username has already been taken");
            }
            return Ok(user);
            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.Id, user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AuthDto userDto)
        {
            int id=await _authService.Login(userDto);
            if (id==-1)
            {
                return BadRequest("Username not found!");
            }
            else if (id==0)
            {
                return BadRequest("Wrong password");
            }
            return Ok($"{id}");
          //  return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.Id, user);
        }
    }
}
