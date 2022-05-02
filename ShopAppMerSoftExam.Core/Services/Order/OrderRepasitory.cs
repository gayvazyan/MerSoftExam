using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class OrderRepasitory : Repositories<Order>, IOrderRepasitory
    {
        public OrderRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
