using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;

namespace ZDZCode_Api.Src.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(string email);
        Task<bool> Create(UserEntity userEntity);
    }
}
