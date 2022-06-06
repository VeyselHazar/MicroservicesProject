using AuthServer.Core.Dtos;
using AuthServer.Core.Models;
using System.Threading.Tasks;


namespace AuthServer.Core.Services
{
    public interface ITokenService
    {
        Tbl_UserTokens CreateToken(LoginInfo userApp);

        Task<Response<Tbl_UserTokens>> CreateTokenAsync(LoginInfo loginDto);
    }
}
