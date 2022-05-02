using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppMerSoftExam.Core.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; } 

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual OrderItem OrderItem { get; set; }

        public int Count { get; set; }

        public int SalePrice { get; set; }
        public int DiscountedPrice { get; set; }
        public int ChekNumber { get; set; }
        public int Overhead { get; set; }
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
        public DateTime ValideDate { get; set; }
    }
}
