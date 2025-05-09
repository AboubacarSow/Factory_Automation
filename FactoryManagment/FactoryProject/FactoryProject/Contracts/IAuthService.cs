using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models.UserDtos;

namespace FactoryProject.Contracts
{
    public interface IAuthService
    {
        Task<TokenContainer>? LoginAsync(LoginModel loginModel);

        Task SetAuthenticateAsync(TokenContainer token);
        Task LogoutAsync();
        
    }
}