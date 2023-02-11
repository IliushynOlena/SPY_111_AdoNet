using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;

namespace _02_connectedMode
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
    }
    class SportShopDb
    {
        private SqlConnection connection;      
        //CRUD Interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete
        public SportShopDb(string conn)
        {           
            connection = new SqlConnection(conn);
            connection.Open();
        }
        public void Create(Product product )
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}', 
                                       {product.Quantity}, 
                                       {product.CostPrice}, 
                                      '{product.Producer}',
                                       {product.Price})";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while(reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name = '{product.Name}', 
                                  TypeProduct = '{product.Type}', 
                                  Quantity = {product.Quantity}, 
                                   CostPrice =  {product.CostPrice}, 
                                   Producer = '{product.Producer}',
                                    Price =  {product.Price}
                                WHERE Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        public Product GetById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
           Product product = new Product();
            while (reader.Read())
            {
                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];               
            }
            reader.Close();
            return product;

        }
        public void Delete(int id)
        {
            string cmdText = $@"delete  Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        ~SportShopDb()
        {
            connection.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string conn = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                            Initial Catalog=SportShop;
                            Integrated Security=True;
                            Connect Timeout=2;";
            SportShopDb db = new SportShopDb(conn);
            Product product = new Product()
            {   Name = "Boll",
                Type = "Spport equipment",
                Quantity = 3,
                CostPrice = 1500,
                Producer = "China",
                Price = 1200
            };
            //db.Create(product);
            //var products = db.GetAll();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.Id + " " +  item.Name);
            //}

            //Product pr = db.GetById(5);
            //Console.WriteLine("Product id = 5  " + pr.Name);

            //pr.CostPrice = 3000;
            //pr.Price = 2800;
            //db.Update(pr);

            db.Delete(18);

        }
    }
}
