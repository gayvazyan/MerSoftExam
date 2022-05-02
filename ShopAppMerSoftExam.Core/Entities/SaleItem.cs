using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppMerSoftExam.Core.Entities
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; } 

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }


        public int SaleId { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale Sale { get; set; }

        public int Count { get; set; }

        public int SalePrice { get; set; }
        public int DiscountedPrice { get; set; }
        public DateTime ValideDate { get; set; }
    }
}
