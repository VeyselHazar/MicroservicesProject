using AuthServer.Core.Dtos;
using AuthServer.Core.Models;
using AuthServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        //Task<Response<Tbl_Users>> CreateUserAsync(CreateUser createUserDto);

        Task<Response<Tbl_Users>> GetUserByIdAsync(int UserID);
    }

    public class UserService : IUserService
    {
        private readonly IGenericRepository<Tbl_Users> _userManager;
        public UserService(IGenericRepository<Tbl_Users> userManager)
        {
            _userManager = userManager;
        }
        //public async Task<Tbl_Users> CreateUserAsync(Tbl_Users createUserDto)
        //{
            
        //    //var result = await _userManager.AddAsync(createUserDto);
        //    //if (!result.Succeeded)
        //    //{
        //    //    var errors = result.Errors.Select(x => x.Description).ToList();
        //    //    return Response<Tbl_Users>.Fail(new ErrorDto(errors, true), 400);
        //    //}
        //    //return Response<Tbl_Users>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        //}

        public async Task<Response<Tbl_Users>> GetUserByIdAsync(int UserID)
        {
            var user = await _userManager.GetByIdAsync(UserID);

            if (user == null)
            {
                return Response<Tbl_Users>.Fail("Username is not found", 404, true);
            }
            return Response<Tbl_Users>.Success(user, 200);
        }


    }


}
