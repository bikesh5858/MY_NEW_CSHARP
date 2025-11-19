using ConsoleTables;
using My_Project_Inventory_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace My_Product_Inventory_App
{
    public class Product_Operations : IProduct
    {
        List<Product> products = new List<Product>
        {
            new Product
            {
                ProductCode = "P001",
                ProductName = "Soaps",
                CategoryCode = "001",
                AvailableQuantity = 100,
                ProductPrice = 8000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 20,
                    MinQuantity = 2
                }
            },
            new Product
            {
                ProductCode = "P002",
                ProductName = "Milk",
                CategoryCode = "002",
                AvailableQuantity = 200,
                ProductPrice = 80000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 25,
                    MinQuantity = 10
                }
            },

            new Product
            {
                ProductCode = "P003",
                ProductName = "Pens",
                CategoryCode = "003",
                AvailableQuantity = 300,
                ProductPrice = 8000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 10,
                    MinQuantity = 5
                }
            },

            new Product
            {
                ProductCode = "P004",
                ProductName = "Shirts",
                CategoryCode = "004",
                AvailableQuantity = 30,
                ProductPrice = 62000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 20,
                    MinQuantity = 3
                }
            },

            new Product
            {
                ProductCode = "P005",
                ProductName = "Mobiles",
                CategoryCode = "005",
                AvailableQuantity = 20,
                ProductPrice = 61000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 10,
                    MinQuantity = 2
                }
            },


        };

        public List<Product> GetAllProducts()
        {
            var table = new ConsoleTable("ProductCode", "ProductName", "CategoryCode", "AvailableQuantity", "ProductPrice", "DiscountPercentage", "MinQuantity");
            foreach (var product in products)
            {
                table.AddRow(product.ProductCode, product.ProductName, product.CategoryCode, product.AvailableQuantity, product.ProductPrice, product.productOnDiscount.DiscountPercentage, product.productOnDiscount.MinQuantity);
            }
            table.Write();
            var result = products.ToList();
            return result;
            //return products;
        }
        public Product AddProduct(Product p)
        {
            try
            {
                Console.WriteLine("Enter ProductCode as P001,P002,and so on...");
                p.ProductCode = Console.ReadLine();
                if (string.IsNullOrEmpty(p.ProductCode))
                    throw new ProductInventory_Exceptions("Invalid ProductCode...");
                if (!Regex.IsMatch(p.ProductCode, @"^[A-Za-z]\d{3}$")) throw new ProductInventory_Exceptions("Invalid ProductCode...");
                Console.WriteLine("Enter ProductName as string value...");
                p.ProductName = Console.ReadLine();
                if (string.IsNullOrEmpty(p.ProductName))
                    throw new ProductInventory_Exceptions("Invalid ProductName...");

                Console.WriteLine("Enter Category Code as 001,002,003 as string");
                p.CategoryCode = Console.ReadLine();
                Console.WriteLine("Enter AvailableQuantity as integer value");
                p.AvailableQuantity = Convert.ToInt32(Console.ReadLine());
                if (p.AvailableQuantity <= 0)
                {
                    throw new ProductInventory_Exceptions("AvailableQuantity should be > 0");
                }
                Console.WriteLine("Enter Product Price as double value...");
                p.ProductPrice = Convert.ToDouble(Console.ReadLine());
                if (p.ProductPrice <= 0)
                {
                    throw new ProductInventory_Exceptions("Product Price should be > 0");
                }



            }
            catch (ProductInventory_Exceptions ex)
            {
                string complete_data = $"Error:{ex.Message}\n" +
                    $"Date and Time:{DateTime.Now.ToShortDateString()}\n" +
                    $"Class and Method Line:{ex.StackTrace}\n" +
                    $"Source:{ex.Source}\n";
                FileStream fs = new FileStream(@"C:\\Users\\HRISHIKA  SAH\\OneDrive\\Desktop\\csharp\\My_Project_Inventory_App\\error_log.txt",
                FileMode.OpenOrCreate, FileAccess.ReadWrite); 
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(complete_data);
                writer.Flush();
                writer.Close();
            }
            p.productOnDiscount.DiscountPercentage = 10;
            p.productOnDiscount.MinQuantity = 10;



            products.Add(p);
            return p;
        }

        // Modify product 
        public Product ModifyProduct(string productCode)
        {
            var product = products.FirstOrDefault(x => x.ProductCode == productCode);

            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return null;
            }

            Console.WriteLine("Leave field empty to keep old value.");

            Console.Write($"New Product Name ({product.ProductName}): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                product.ProductName = newName;

            Console.Write($"New Quantity ({product.AvailableQuantity}): ");
            string newQty = Console.ReadLine();
            if (int.TryParse(newQty, out int qty) && qty > 0)
                product.AvailableQuantity = qty;

            Console.Write($"New Price ({product.ProductPrice}): ");
            string newPrice = Console.ReadLine();
            if (double.TryParse(newPrice, out double price) && price > 0)
                product.ProductPrice = price;

            Console.WriteLine("Product Updated Successfully!");
            return product;
        }

        //Delete product
        public Product DeleteProduct(string productCode)
        {
            var product = products.FirstOrDefault(x => x.ProductCode == productCode);

            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return null;
            }

            products.Remove(product);
            Console.WriteLine("Product Deleted Successfully!");

            return product;
        }

        // search product by name 
        public List<Product> GetProductsByName(string productName)
        {
            var result = products
                .Where(p => p.ProductName.ToLower().Contains(productName.ToLower()))
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No matching products found.");
                return new List<Product>();
            }

            var table = new ConsoleTable("Code", "Name", "Category", "Qty", "Price");

            foreach (var p in result)
                table.AddRow(p.ProductCode, p.ProductName, p.CategoryCode, p.AvailableQuantity, p.ProductPrice);

            table.Write();

            return result;
        }

    }

}
