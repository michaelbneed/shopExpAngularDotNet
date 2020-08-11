using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Repositories.Interfaces;
using Core.RepositoryInterfaces.Interfaces;
using Core.Specification;
using API.DTO;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repoProduct;
        private readonly IGenericRepository<ProductType> _repoProductType;
        private readonly IGenericRepository<ProductMaker> _repoProductMaker;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductType> productTypeRepo, 
            IGenericRepository<ProductMaker> productMakerRepo,
            IMapper mapper)
        {
            _repoProduct = productRepo;
            _repoProductType = productTypeRepo;
            _repoProductMaker = productMakerRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsTypesMakersSpecification(productParams);
            var products = await _repoProduct.ListAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsTypesMakersSpecification(id);
            var product = await _repoProduct.GetEntityWithSpec(spec);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            
            return mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("makers")]
        public async Task <ActionResult<IReadOnlyList<ProductMaker>>> GetProductMakers()
        {
            return Ok(await _repoProductMaker.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductMaker>>> GetProductTypes()
        {
            return Ok(await _repoProductType.GetAllAsync());
        }
    }
}
