using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }


      [Required]
      [Display (Name ="Product Type")]
        public string ProductType { get; set; }
    }
}
