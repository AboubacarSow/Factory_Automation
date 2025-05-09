using FactoryProject.Models.UserDtos;

namespace FactoryProject.Contracts
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
        
    }
}