using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Models
{
    public class SpacialTag
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Spacial Tag")]
        public string spacialTag { get; set; }

    }
}
