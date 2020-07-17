using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specification
{
    public class ProductsTypesMakersSpecification : BaseSpecification<Product>
    {
        public ProductsTypesMakersSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductMaker);
        }

        public ProductsTypesMakersSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductMaker);
        }
    }
}
