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

        public string ChekNumber { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
        public DateTime ValideDate { get; set; }

        public int ClientDiscounte { get; set; }
       
    }
}
