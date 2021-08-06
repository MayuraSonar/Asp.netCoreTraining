using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Entity
{
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; }
        [Column("CategoryDescription")]
        public string Description { get; set; }
        public List<Candy> Candies { get; set; }

    }
}
