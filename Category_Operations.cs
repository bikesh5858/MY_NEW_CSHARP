using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Project_Inventory_App
{
    public class Category_Operations : ICategory
    {
        
        List<Category> categories = new List<Category>()
        {
            new Category{CategoryCode="001",CategoryName="Furniture"},
            new Category{CategoryCode="002",CategoryName="Cosmetics"},
            new Category{CategoryCode="003",CategoryName="Clothing"},
            new Category{CategoryCode="004",CategoryName="Sports"},
            new Category{CategoryCode="005",CategoryName="Kitchenware"}


        };
        public List<Category> GetAllcategories()
        {
            var table = new ConsoleTable("CategoryCode", "CategoryName");
            foreach (var displayResult in categories)
            {
                table.AddRow(displayResult.CategoryCode, displayResult.CategoryName);
            }
            table.Write();
            var result = categories.ToList();
            return result;

        }
    }
}


