﻿using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;

namespace NLayer.Core.Services.AbstractEntitiesService
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    }
}
