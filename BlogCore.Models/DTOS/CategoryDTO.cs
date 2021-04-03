using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models.DTOS
{
    public class CategoryCreateDTO
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }
    }
}
