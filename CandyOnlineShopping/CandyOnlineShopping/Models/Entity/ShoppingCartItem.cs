using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Entity
{
   
        public class ShoppingCartItem
        {
            [Column("ShoppingCartItemId")]
            public int Id { get; set; }
            public string ShoppingCartId { get; set; }
            public Candy Candy { get; set; }
            public int Amount { get; set; }
        }
    }

