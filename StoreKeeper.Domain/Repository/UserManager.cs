using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreKeeper.Common.Repository;
using StoreKeeper.Data.DataTransferObject;
using StoreKeeper.Data.DbModel;
using StoreKeeper.Data.Persistence;
using StoreKeeper.Data.ViewModels;
using StoreKeeper.Domain.Contract;
using System;
using System.Threading.Tasks;

namespace StoreKeeper.Domain.Repository
{
    public class UserManager : ManagerBase<User>, IUserManager<UserDto>
    {
        private readonly ILogger<UserManager> _logger;
        private readonly IMapper _mapper;
        private readonly StoreKeeperDbContext _storeKeeperDbContext;
        public UserManager(DbContext dbContext,
                           StoreKeeperDbContext storeKeeperDbContext,
                           ILogger<UserManager> logger, IMapper mapper)
            :base(dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _storeKeeperDbContext = storeKeeperDbContext;
        }

        public async Task<UserDto> Login(LoginViewModel loginViewModel)
        {
            try
            {
                var userProfile = await GetAsync(user => user.Email == loginViewModel.Email && user.Password == loginViewModel.Password);
                if (userProfile != null)
                {
                    _logger.LogInformation($"Login Method(), Login for {loginViewModel.Email} Successful at {DateTime.Now}");
                    return _mapper.Map<UserDto>(userProfile);
                }
                else
                    _logger.LogInformation($"Login Method(), Login for {loginViewModel.Email} Failed at {DateTime.Now}");
                return null;
            }
            catch(Exception exception)
            {
                _logger.LogInformation($"Login Method(), Error, {JsonConvert.SerializeObject(exception)} occured at {DateTime.Now}");
                return null;
            }
        }
    }
}
