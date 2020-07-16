﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Repositories.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _repo;

        public Products(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return product;
        }

        [HttpGet("makers")]
        public async Task <ActionResult<IReadOnlyList<ProductMaker>>> GetProductMakers()
        {
            return Ok(await _repo.GetProductMakersAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductMaker>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}
