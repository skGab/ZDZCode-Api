using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Infrastructure.Database
{
    public class UserRepository(DbAdapter dbAdapter, ILogger<UserController> logger) : IUserRepository
    {

        private readonly DbAdapter _dbAdapter = dbAdapter;
        private readonly ILogger<UserController> _logger = logger;

        async public Task<bool> AuthenticateUser(string email)
        {
            try
            {
                var user = await _dbAdapter.FindAsync<UserEntity>(email);

                if (user == null)
                {
                    _logger.LogInformation("{User was not found to be authenticated}", email);

                    return false;
                }

                return true;

            }
            catch (Exception error)
            {
                _logger.LogError("{Error while trying to authentica the user}", error);
                return false;
            }
        }

        async public Task<bool> Create(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                _logger.LogError("UserEntity data is null.");
                return false;
            }

            try
            {
                var user = await _dbAdapter.FindAsync<UserEntity>(userEntity.email);

                if (user != null)
                {
                    return false;
                }

                _dbAdapter.Add(userEntity);

                var task = await _dbAdapter.SaveChangesAsync();

                if (task == 0)
                {
                    _logger.LogWarning("Failed to save changes to the database for user ID: {id}", userEntity.id);
                    return false;
                };

                return true;

            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occurred while creating the user: {id}", userEntity.id);
                return false;
            }
        }
    }
}
