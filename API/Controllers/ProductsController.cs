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
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsTypesMakersSpecification();
            var products = await _repoProduct.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsTypesMakersSpecification(id);
            var product = await _repoProduct.GetEntityWithSpec(spec);
            return product;
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
