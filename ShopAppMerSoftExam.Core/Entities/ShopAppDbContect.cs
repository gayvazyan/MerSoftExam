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

       
        public DbSet<Grup> GrupDb { get; set; }
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<Client> ClientDb { get; set; }
        public DbSet<Order> OrderDb { get; set; }
        public DbSet<OrderItem> OrderItemDb { get; set; }
        public DbSet<Sale> SaleDb { get; set; }
        public DbSet<SaleItem> SaleItemDb { get; set; }
        



    }
}
