using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.DB
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FkOrder { get; set; }
        public virtual Order FkOrderNavigation { get; set; }
        
        [Required]
        public int FkProduct { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal StockQty { get; set; }
    }
}
