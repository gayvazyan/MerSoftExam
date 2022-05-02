using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class ClientRepasitory : Repositories<Client>, IClientRepasitory
    {
        public ClientRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
