using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppMerSoftExam.Core.Entities
{
    public class ShopAppDbContect : DbContext
    {
        public ShopAppDbContect(DbContextOptions<ShopAppDbContect> options)
            : base(options)
        {
        }

       
        //public DbSet<Product> ProductDb { get; set; }

    }
}
