using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.DB
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string CompanyCode { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
