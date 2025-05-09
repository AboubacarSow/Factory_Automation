using FactoryProject.Models.UserDtos;

namespace FactoryProject.Contracts;

public interface IAccountService
{
    public Task<bool> RegisterAysnc(RegisterDto registerDto);

}