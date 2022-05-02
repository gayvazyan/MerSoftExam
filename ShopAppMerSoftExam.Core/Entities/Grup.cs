using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppMerSoftExam.Core.Entities
{
    public class Grup
    {
        [Key]
        public int Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}
