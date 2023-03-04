using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LINQSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ShopClassesDataContext context = new ShopClassesDataContext();
            //CRUD - create...read..update...delete
            //var products = context.Products;
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id}  Name:{p.Name}  {p.Price}");
            //}
            Console.OutputEncoding = Encoding.UTF8;
            //var products = context.Products
            //    .Where(p => p.Price > 500)
            //    .OrderByDescending(p => p.Price)
            //    .Take(5);

            var products = (from i in context.Products
                       where i.Price > 500
                       orderby i.Price descending
                       select i).Take(5);
            foreach (var p in products)Console.WriteLine($"Product : {p.Id}  Name:{p.Name}  {p.Price}");

            var SportBottle = new Product()
            {
                Name = "My bottle XL",
                TypeProduct = "Acessories",
                CostPrice = 180,
                Price = 400,
                Producer = "Poland",
                Quantity = 20
            };
            //context.Products.InsertOnSubmit(SportBottle);
            //context.Products.InsertOnSubmit(new Product() { });
            //context.SubmitChanges();

            //var productToEdit = context.Products.Where(p => p.Id == 17).FirstOrDefault();
            //productToEdit.Price += 300;
            //context.SubmitChanges();

            var productToDelete = context.Products.FirstOrDefault(p => p.Id == 17);
            if(productToDelete != null)
            {
                context.Products.DeleteOnSubmit(productToDelete);
            }


            context.SubmitChanges();

            Console.WriteLine("-----------------------------------");
            foreach (var p in context.Products)
            {
                Console.WriteLine($"Product : {p.Id}  Name:{p.Name}  {p.Price}");
            }




        }
    }
}
