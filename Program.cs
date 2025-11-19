using My_Product_Inventory_App;

namespace My_Project_Inventory_App
{
    public class Program
    {
        public void ProdOperations(string adminInput, Product_Operations prod, ref bool adminMode)
        {
            Product p = new Product();
            switch (adminInput)
            {
                case "1":
                    {
                        prod.GetAllProducts();
                        break;
                    }
                case "2":
                    {
                        Product p1 = new Product();

                        Console.Write("Enter Product Code: ");
                        p1.ProductCode = Console.ReadLine();

                        Console.Write("Enter Product Name: ");
                        p1.ProductName = Console.ReadLine();

                        Console.Write("Enter Category Code: ");
                        p1.CategoryCode = Console.ReadLine();

                        Console.Write("Enter Available Quantity: ");
                        p1.AvailableQuantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Product Price: ");
                        p1.ProductPrice = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Discount Percentage: ");
                        double dis = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Min Quantity For Discount: ");
                        int mqty = Convert.ToInt32(Console.ReadLine());

                        p1.productOnDiscount = new ProductOnDiscount
                        {
                            DiscountPercentage = dis,
                            MinQuantity = mqty
                        };

                        prod.AddProduct(p1);
                        break;
                    }
                case "3":
                    {

                        // Modify Product
                        Console.Write("Enter Product Code to Modify: ");
                        string modifyCode = Console.ReadLine();
                        prod.ModifyProduct(modifyCode);
                        break;
                    }
                case "4":
                    {
                        Console.Write("Enter Product Code to Delete: ");
                        string deleteCode = Console.ReadLine();
                        prod.DeleteProduct(deleteCode);
                        break;
                    }
                case "5": //search product
                    {
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        prod.GetProductsByName(name);
                        break;
                    }
                case "6": //exit
                    {
                        adminMode = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("invalid Operation");
                        break;
                    }
            }
        }
        public static void Main(string[] args)
        {
            {
                Program program = new Program();
                Category_Operations category = new Category_Operations();
                Product_Operations operations = new Product_Operations();
                bool exit = true;
                while (exit)
                {
                    Console.Clear();
                    Console.WriteLine("-----PRODUCT INVENTORY MANAGEMENT-----");
                    Console.WriteLine("[1]  : Categories");
                    Console.WriteLine("[2]  : Products");
                    Console.WriteLine("[3]  : Exit");
                    Console.Write("\nSelect one option:");
                    string selectedOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (selectedOption)
                    {
                        case "1":
                            //Console.WriteLine("Hello World");
                            category.GetAllcategories();
                            break;

                        case "2":
                            {
                                bool adminMode = true;
                                while (adminMode)
                                {
                                    Console.Clear();
                                    Console.WriteLine("-----Product Menu-----");
                                    Console.WriteLine("[1] Get All Product");
                                    Console.WriteLine("[2] Add Product");
                                    Console.WriteLine("[3] Modify Product");
                                    Console.WriteLine("[4] Udpate Product");
                                    Console.WriteLine("[5] Search Product By Product Name");
                                    Console.WriteLine("[6] Exit Product Menu And Go to Main Menu");
                                    Console.Write("\nSelect one option:");
                                    string adminInput = Console.ReadLine();
                                    program.ProdOperations(adminInput, operations, ref adminMode);
                                    Console.WriteLine("please [Enter] to go Back");
                                    Console.ReadKey();
                                }
                                //showsubmenu();
                                break;

                            }

                        //Console.WriteLine("Hello World");
                        //category.GetAllcategories();
                        //break;
                        case "3":
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid Operation");
                                break;
                            }
                    }
                    Console.WriteLine("\nPress [Enter] For Main Menu");
                    Console.ReadKey();
                    Console.ReadKey();
                    Console.ReadKey();
                }

            }

        }


    }
}
