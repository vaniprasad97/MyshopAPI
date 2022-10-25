using System;
using System.Collections.Generic;

namespace MyShopAPI.Models
{
    public partial class ProductDb
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
