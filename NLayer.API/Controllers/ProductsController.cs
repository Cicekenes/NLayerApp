﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services.AbstractEntitiesService;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        
    }
}
