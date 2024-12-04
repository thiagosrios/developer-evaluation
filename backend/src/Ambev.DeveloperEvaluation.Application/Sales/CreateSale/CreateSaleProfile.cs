﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<Sale, CreateSaleResult>();
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<CreateSaleItemCommand, SaleItem>();
        }
    }
}
