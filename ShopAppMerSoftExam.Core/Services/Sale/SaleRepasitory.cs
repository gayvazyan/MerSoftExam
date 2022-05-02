using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class SaleRepasitory : Repositories<Sale>, ISaleRepasitory
    {
        public SaleRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
