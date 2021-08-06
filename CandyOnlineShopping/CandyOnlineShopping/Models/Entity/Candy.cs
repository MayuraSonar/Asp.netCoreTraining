using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Entity
{
    public class Candy
    {
        [Column("CandyId")]
        public int Id { get; set; }
        [Column("CandyName")]
        public string Name { get; set; }
        [Column("CandyDescription")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
