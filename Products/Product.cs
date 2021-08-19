using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
namespace Products
{
   public class Product
    {
        public string path = @"..\..\..\..\JSON\Books.json";
        List<Book_def> booksList = new List<Book_def>();
        public IEnumerable<Book_def> getBooksByCategory(int category_id) 
        {
            try
            {
                var data = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<List<Book_def>>(data) ?? new List<Book_def>();
                
                foreach (var book in result.Where<Book_def>(obj => obj.categoryName == (CategoryName)category_id))
                {
                    booksList.Add(book);
                }

                return booksList;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
            return null;
        }

        public Book_def getBook(int book_id)
        {
            try
            {
                var data = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<List<Book_def>>(data) ?? new List<Book_def>();
                var book = result.Where<Book_def>(x => x.Book_Id == book_id).FirstOrDefault();
                return book;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
            return null;
        }
    }
}
