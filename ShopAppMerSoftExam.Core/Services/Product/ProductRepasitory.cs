using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class ProductRepasitory : Repositories<Product>, IProductRepasitory
    {
        public ProductRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
