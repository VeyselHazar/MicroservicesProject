using AuthServer.Core.Models;
using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IGenericRepository<LoginInfo> _userManager;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser createUserDto)
        {
            return null;//ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        

        [HttpPost]
        public async Task<IActionResult> GetUser(Tbl_Users user)
        {

            
            return ActionResultInstance(await _userService.GetUserByIdAsync(user.Id)); // 1 yazan yere kullanıcının idsi
        }

    }
}
