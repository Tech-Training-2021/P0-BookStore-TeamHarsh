using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


namespace Admin
{
   public class Book
    {
        public string path = @"..\..\..\..\JSON\Books.json";
        public void setBookDetailsIntoFile(BookDetails bookDetails)
        {
             
            try
            {
                var json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<BookDetails>>(json) ?? new List<BookDetails>();
                customerData.Add(bookDetails);
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(customerData,
                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                Console.Write("\nDetails Entered Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }

        public void setBookDetails()
        {
            BookDetails book = null;
            Book book1 = new Book();
            Console.Write("\nEnter Book Id : ");
            int b_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Book Name : ");
            string b_name = Console.ReadLine();
            Console.Write("\nEnter Author Name : ");
            string b_author = Console.ReadLine();
            Console.Write("\nEnter Book Price : ");
            double b_price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select the Category\n1.Fiction\t2.Science");
            int category_id = int.Parse(Console.ReadLine());
            var categoryName=category.fiction;
            if (category_id == 1)
            {
                categoryName = category.fiction;
            }
            else if (category_id == 2)
            {
                categoryName = category.Science;
            }
            Console.Write("\nEnter Book Description : ");
            string b_description = Console.ReadLine();
            Console.Write("\nEnter Book Quantity : ");
            int b_qty = Convert.ToInt32(Console.ReadLine());

            book = new BookDetails()
            {
                Book_Id = b_id,
                Book_Name = b_name,
                Book_Author = b_author,
                Book_Price = b_price,
                categoryName = categoryName,
                Book_Description = b_description,
                Book_Qty = b_qty,

            };
            book1.setBookDetailsIntoFile(book);
        }
}
}
