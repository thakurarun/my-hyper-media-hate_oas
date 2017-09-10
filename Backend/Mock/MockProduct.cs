using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Mock
{
    public class MockProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public double Quantity { get; set; }
    }
}