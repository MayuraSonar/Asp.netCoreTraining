using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Entity
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Required (ErrorMessage ="Please Enter Your FirstName")]
         [StringLength(25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your LastName")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        [Display(Name ="Street Address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your CityName")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your State Name")]
        [StringLength(2,MinimumLength =2)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [BindNever]
        public decimal Total { get; set; }
        public DateTime OrderPlaced { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
