using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
       
        [Display(Name ="Order No")]
        public string OrderNo { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]   
        public string Address { get; set; }
      
        [Display(Name = "Order Date")]
        public DateTime  OrderDate { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
