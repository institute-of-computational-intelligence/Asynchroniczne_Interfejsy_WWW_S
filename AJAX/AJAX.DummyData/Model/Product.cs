using System;
using System.Collections.Generic;
using System.Text;

namespace AJAX.DummyData.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
