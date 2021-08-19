using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Customer;
namespace Cart
{
   public class AddToCart
    {
        UserSession userSession = new UserSession();
        Product product = new Product();
        public string path = @"..\..\..\..\JSON\Cart.json";
        public void getBookDetails() {
            Console.Write("Enter Book Id to see the Entire Details \t");
            int book_id=Convert.ToInt32(Console.ReadLine());
            Console.Clear();
          
            var book_Details = product.getBook(book_id);
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Id", $"{book_Details.Book_Id}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"ISBN_10", $"{book_Details.ISBN_10}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Book_Name", $"{book_Details.Book_Name}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Author_Name", $"{book_Details.Book_Author}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Publisher", $"{book_Details.Publisher}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Language", $"{book_Details.Language}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Publication_Date", $"{book_Details.Publication_Date}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Book_Price", $"{book_Details.Book_Price}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Book_Description", $"{book_Details.Book_Description}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Customer_Review", $"{book_Details.Customer_Review}");
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150, $"Description");
            Table.Table.PrintLine(150);
            Console.WriteLine($"{book_Details.Book_Description}");
            Table.Table.PrintLine(150);
        }

        public void addToCart()
        {
            Console.Write("Enter Book Id Add to Cart \t");
            int book_id = Convert.ToInt32(Console.ReadLine());
            var book_Details = product.getBook(book_id);
       quantity:     Console.Write("\nEnter Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity == 0)
            {
                Console.WriteLine("Quantity should be greater than 0");
                goto quantity;
            }else if (quantity < 0)
            {
                Console.WriteLine("Quantity Cannot be Negatives");
                goto quantity;
            }
            try
            {
                var json = File.ReadAllText(path);
                var cartData = JsonConvert.DeserializeObject<List<Cart>>(json) ?? new List<Cart>();
                
                foreach (var customer in cartData.Where<Cart>(obj => obj.userDetails.Id == userSession.getSession().Id))
                {
                    customer.cart_details.Add(new cart_def()
                    {
                        book_Def = book_Details,
                        quantity = quantity
                    });
                    
                    string newJsonResult1 = Newtonsoft.Json.JsonConvert.SerializeObject(cartData,
                               Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, newJsonResult1);
                    Console.WriteLine("\nAdded successfully to cart");
                    return;
                }
                List<cart_def> cart = new List<cart_def>();
                cart.Add(new cart_def()
                {
                    book_Def = book_Details,
                    quantity = quantity
                });
                Cart data = new Cart()
                {
                    userDetails = userSession.getSession(),
                    cart_details = cart
                };
                cartData.Add(data);
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(cartData,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                Console.WriteLine("\nAdded successfully to cart");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
