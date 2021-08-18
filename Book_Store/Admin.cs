using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;

namespace Book_Store
{
   public class Admin
    {
        public void book()
        {
            Book book = new Book();
            book.setBookDetails();
        }
        public void admin()
        {
            do
            {
                Console.WriteLine("\n****Welcome Admin****");
                Console.WriteLine("0.Sign Out\n1.Add Book\n2.Search Book\n3.Add Role\n4.Display Book");
                Console.Write("Enter Your Choice : ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        book();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            } while (true);

        }

    }
}
