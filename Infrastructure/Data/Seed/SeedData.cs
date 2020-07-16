using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class SeedData
    {
        public static async Task SeedDataAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            // Seed Product Makers
            try
            {
                if (!context.ProductMakers.Any())
                {
                    var makersData = File.ReadAllText("some path to a json file here");
                    var makers = JsonSerializer.Deserialize<List<ProductMaker>>(makersData);

                    foreach (var item in makers)
                    {
                        context.ProductMakers.Add(item);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ProductMaker>();
                logger.LogError(ex, "An error occurred during seeding of Product Makers");
            }

            // Seed Product Types
            try
            {
                if (!context.ProductMakers.Any())
                {
                    var typessData = File.ReadAllText("some path to a json file here");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typessData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ProductMaker>();
                logger.LogError(ex, "An error occurred during seeding of Product Makers");
            }
        }
    }
}
