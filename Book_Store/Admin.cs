using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
using Products;


namespace Book_Store
{
   public class Admin
    {
        public void book()
        {
            Book book = new Book();
            book.setBookDetails();
        }
        public void signOut()
        {
            Program p1 = new Program();
            p1.displayOperation();
        }
        public void updateBook()
        {
            Book book = new Book();
            book.updateBookRecord();
            Console.WriteLine("\n ****Records Updated Successfully****");
        }
        public void deleteBook()
        {
            Book book = new Book();
            book.deleteBookRecord();
        }
        public void searchBookByName()
        {
            Book book = new Book();
            book.searchByName();
        }

        public void admin()
        {
            do
            {
                Console.WriteLine("\n****Welcome Admin****");
                Console.WriteLine("0.Sign Out\n1.Add Book\n2.Display Book\n3.Update Book\n4.Delete Book\n5.Search Book");
                Console.Write("Enter Your Choice : ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        System.Environment.Exit(0);
                        signOut();
                        break;
                    case 1:
                        book();
                        break;
                    case 2:

                        break;
                    case 3:
                        updateBook();
                        break;

                    case 4:
                        deleteBook();
                        break;
                    case 5:
                        searchBookByName();
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            } while (true);

        }
    }
}
