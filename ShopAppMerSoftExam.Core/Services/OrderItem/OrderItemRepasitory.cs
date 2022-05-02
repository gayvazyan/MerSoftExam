using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class OrderItemRepasitory : Repositories<OrderItem>, IOrderItemRepasitory
    {
        public OrderItemRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
