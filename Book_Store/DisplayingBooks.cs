using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;
using Table;
using Cart;
namespace Book_Store
{
   public class DisplayingBooks
    {
        AddToCart addToCart = new AddToCart();
        public void displayBooks(IEnumerable<Book_def> bookList) {
        
            Table.Table.PrintLine(150);
            Table.Table.PrintRow(150,"Book_Id", "ISBN_10", "Book_Name", "Author", "Publication_Date");
            foreach (var book in bookList)
            {
                Table.Table.PrintLine(150);
                Table.Table.PrintRow(150,$"{book.Book_Id}", $"{book.ISBN_10}", $"{book.Book_Name}", $"{book.Book_Author}", $"{book.Publication_Date}");
            }
            Table.Table.PrintLine(150);
            Console.WriteLine("1.Book Details Of Particular Book Id\t2.Add Particular Book To Cart");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    addToCart.getBookDetails();
                    break;
                case 2:
                    addToCart.addToCart();
                    break;
                default:
                    Console.WriteLine("Invalid Option Please Enter Proper Operation");
                    break;
            }
            
        }
        
    }
}
