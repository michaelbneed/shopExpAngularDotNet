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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repoProduct;
        private readonly IGenericRepository<ProductType> _repoProductType;
        private readonly IGenericRepository<ProductMaker> _repoProductMaker;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductMaker> productMakerRepo)
        {
            _repoProduct = productRepo;
            _repoProductType = productTypeRepo;
            _repoProductMaker = productMakerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var spec = new ProductsTypesMakersSpecification();
            var products = await _repoProduct.ListAsync(spec);

            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductMaker = product.ProductMaker.Name,
                ProductType = product.ProductType.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsTypesMakersSpecification(id);
            var product = await _repoProduct.GetEntityWithSpec(spec);

            return new ProductDto
            {
                Id = product.Id,
                Name= product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductMaker = product.ProductMaker.Name,
                ProductType = product.ProductType.Name
            };
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
