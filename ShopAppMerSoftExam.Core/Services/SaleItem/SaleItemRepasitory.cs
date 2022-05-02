using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class SaleItemRepasitory : Repositories<SaleItem>, ISaleItemRepasitory
    {
        public SaleItemRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
