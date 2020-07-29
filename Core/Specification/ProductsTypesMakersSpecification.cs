using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specification
{
    public class ProductsTypesMakersSpecification : BaseSpecification<Product>
    {
        public ProductsTypesMakersSpecification(ProductSpecParams productParams)
            : base(x => 
                  (!productParams.MakerId.HasValue || x.ProductMakerId == productParams.MakerId) &&
                  (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
              )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductMaker);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsTypesMakersSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductMaker);
        }
    }
}
