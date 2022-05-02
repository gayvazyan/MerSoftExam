using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppMerSoftExam.Core.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } 

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        //public int Sum { get; set; }
        public int Overhead { get; set; }
        public int SalePrice { get; set; }
        public DateTime ValideDate { get; set; }
    }
}
