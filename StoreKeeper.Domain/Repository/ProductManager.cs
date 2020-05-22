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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreKeeper.Domain.Repository
{
    public class ProductManager : ManagerBase<Product>, IProductManager<ProductDto>
    {
        private readonly ILogger<ProductManager> _logger;
        private readonly IMapper _mapper;
        private readonly StoreKeeperDbContext _storeKeeperDbContext;
        public ProductManager(DbContext dbContext,
                              StoreKeeperDbContext storeKeeperDbContext,
                              ILogger<ProductManager> logger, IMapper mapper)
            : base(dbContext)
        {
            _storeKeeperDbContext = storeKeeperDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddProduct(ProductViewModel productViewModel)
        {
            try
            {
                var mappedRequest = _mapper.Map<Product>(productViewModel);
                var isExist = await GetAsync(product => product.SerialNumber == mappedRequest.SerialNumber);
                if (isExist != null)
                {
                    var result = await AddAsync(mappedRequest);
                    if (result)
                    {
                        _logger.LogInformation($"AddProduct Method(), AddProduct for {productViewModel.SerialNumber} Successful at {DateTime.Now}");
                        return result;
                    }
                    else
                        _logger.LogInformation($"AddProduct Method(), AddProduct for {productViewModel.SerialNumber} Failed at {DateTime.Now}");
                    return result;
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"AddProduct Method(), Error, {JsonConvert.SerializeObject(exception)} occured at {DateTime.Now}");
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var allProducts = await GetAllAsync().Result.ToListAsync();
            return _mapper.Map(allProducts, new List<ProductDto>());
        }

        //public async Task<bool> SubtractItem(string serialNumber, int quantity)
        //{
        //    try
        //    {
        //        var isExist = await GetAsync(product => product.SerialNumber == serialNumber);
        //        if (isExist != null)
        //        {
        //            isExist.Quantity = isExist.Quantity - quantity;
        //            var result = await AddAsync(isExist);
        //            if (result)
        //            {
        //                _logger.LogInformation($"AddProduct Method(), AddProduct for {productViewModel.SerialNumber} Successful at {DateTime.Now}");
        //                return result;
        //            }
        //            else
        //                _logger.LogInformation($"AddProduct Method(), AddProduct for {productViewModel.SerialNumber} Failed at {DateTime.Now}");
        //            return result;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogInformation($"AddProduct Method(), Error, {JsonConvert.SerializeObject(exception)} occured at {DateTime.Now}");
        //        return false;
        //    }
        //}
    }
}
