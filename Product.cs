using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Project_Inventory_App
{
    public class Product
    {
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CategoryCode { get; set; }
        public int AvailableQuantity { get; set; }
        public double ProductPrice { get; set; }
        public ProductOnDiscount productOnDiscount { get; set; }

    }
    public class ProductOnDiscount
    {
        public double DiscountPercentage { get; set; }
        public int MinQuantity { get; set; }
    }
}
