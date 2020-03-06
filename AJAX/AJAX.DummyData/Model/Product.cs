using System;
using System.Collections.Generic;
using System.Text;

namespace AJAX.DummyData.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }
    }
}
