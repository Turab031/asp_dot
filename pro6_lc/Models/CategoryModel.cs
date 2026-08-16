using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pro6_lc.Models
{
    [Table("categoryTbl")]
    public class CategoryModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId{get;set;}

        
        
    }
}