using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.Core
{
    public class GrupeRepasitory : Repositories<Grup>, IGrupeRepasitory
    {
        public GrupeRepasitory(ShopAppDbContect dbContext) : base(dbContext) { }

    }


}
