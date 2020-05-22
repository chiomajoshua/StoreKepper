using AutoMapper;
using StoreKeeper.Data.DataTransferObject;
using StoreKeeper.Data.DbModel;
using StoreKeeper.Data.ViewModels;
using System;

namespace StoreKeeper.Common.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().AfterMap((source, destination) =>
            {
                destination.Email = source.Email;
                destination.Firstname = source.Firstname;
                destination.Lastname = source.Lastname;
                destination.DateAdded = source.DateAdded;
                destination.Role = source.Role;
            });

            CreateMap<ProductViewModel, Product>().AfterMap((source, destination) =>
            {
                destination.Id = Guid.NewGuid();
                destination.Name = source.Name;
                destination.PricePerUnit = source.PricePerUnit;
                destination.Quantity = source.Quantity;
                destination.SerialNumber = source.SerialNumber;
                destination.SuppliedBy = source.SuppliedBy;
                destination.SupplyMeasurement = source.SupplyMeasurement;
                destination.DateSupplied = DateTime.Now;
                destination.ExpiryDate = source.ExpiryDate;
            });

            CreateMap<Product, ProductDto>().AfterMap((source, destination) =>
            {
                destination.Id = source.Id.ToString();
                destination.Name = source.Name;
                destination.PricePerUnit = source.PricePerUnit;
                destination.Quantity = source.Quantity;
                destination.SerialNumber = source.SerialNumber;
                destination.SuppliedBy = source.SuppliedBy;
                destination.SupplyMeasurement = source.SupplyMeasurement;
                destination.DateSupplied = DateTime.Now;
                destination.ExpiryDate = source.ExpiryDate;
            });
        }
    }
}