using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pro6_lc.Models
{
    [Table("productTbl")]
    public class ProductModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        public int catId { get; set; }

        public string productName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;

        public decimal price { get; set; }

        public string description { get; set; } = string.Empty;

        public Nullable<DateTime> createdDate { get; set; }

        public Nullable<DateTime> modifiedDate { get; set; }









    }
}