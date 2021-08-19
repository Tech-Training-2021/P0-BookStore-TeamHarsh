using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


namespace Admin
{
    /// <summary>
    /// Defines the <see cref="Book" />.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Defines the path.
        /// </summary>
        public string path = @"..\..\..\..\JSON\Books.json";

        /// <summary>
        /// The setBookDetailsIntoFile.
        /// </summary>
        /// <param name="bookDetails">The bookDetails<see cref="BookDetails"/>.</param>
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

        /// <summary>
        /// The setBookDetails.
        /// </summary>
        public void setBookDetails()
        {
            BookDetails book = null;
            Book book1 = new Book();
            Console.Write("\nEnter Book Id : ");
            int b_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Book ISBN : ");
            string b_isbn = Console.ReadLine();
            Console.Write("\nEnter Book Language : ");
            string b_language = Console.ReadLine();
            Console.Write("\nEnter Book Publisher : ");
            string b_publisher = Console.ReadLine();
            Console.Write("\nEnter Total Book Pages : ");
            int b_pages = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Book Publication Date : ");
            string b_date = Console.ReadLine();
            Console.Write("\nEnter Book Name : ");
            string b_name = Console.ReadLine();
            Console.Write("\nEnter Author Name : ");
            string b_author = Console.ReadLine();
            Console.Write("\nEnter Book Price : ");
            double b_price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select the Category\n1.Action And Adventure\n2.Classic\n3.Comic Book Or Graphic Novel\n4.Detective And Mystry\n5.Fantasy\n6.Historical Fiction\n7.Horror\n8.Literary Fiction\n9.Romance\n10.Science Fiction");
            int category_id = int.Parse(Console.ReadLine());
            var categoryName = Category.Action_and_Adventure;
            if (category_id == 1)
            {
                categoryName = Category.Action_and_Adventure;
            }
            else if (category_id == 2)
            {
                categoryName = Category.Classics;
            }
            else if (category_id == 3)
            {
                categoryName = Category.Comic_Book_or_Graphic_Novel;
            }
            else if (category_id == 4)
            {
                categoryName = Category.Detective_and_Mystery;
            }
            else if (category_id == 5)
            {
                categoryName = Category.Fantasy;
            }
            else if (category_id == 6)
            {
                categoryName = Category.Historical_Fiction;
            }
            else if (category_id == 7)
            {
                categoryName = Category.Horror;
            }
            else if (category_id == 8)
            {
                categoryName = Category.Literary_Fiction;
            }

            else if (category_id == 9)
            {
                categoryName = Category.Romance;
            }
            else if (category_id == 10)
            {
                categoryName = Category.Science_Fiction;
            }

            Console.Write("\nEnter Book Description : ");
            string b_description = Console.ReadLine();

            Console.Write("\nEnter Book Customer Review : ");
            double b_customer_review = double.Parse(Console.ReadLine());

            Console.Write("\nEnter Book Quantity : ");
            int b_qty = Convert.ToInt32(Console.ReadLine());

            book = new BookDetails()
            {
                Book_Id = b_id,
                ISBN_10 = b_isbn,
                Language = b_language,
                Publisher = b_publisher,
                Total_Pages = b_pages,
                Publication_Date = b_date,
                Book_Name = b_name,
                Book_Author = b_author,
                Book_Price = b_price,
                categoryName = categoryName,
                Book_Description = b_description,
                Customer_Review = b_customer_review,
                Book_Qty = b_qty,
            };
            book1.setBookDetailsIntoFile(book);
        }

        /// <summary>
        /// The updateBookRecord.
        /// </summary>
        public void updateBookRecord()
        {
            Console.Write("Enter the id : ");
            int b_id = int.Parse(Console.ReadLine());
            try
            {

                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<BookDetails>>(json) ?? new List<BookDetails>();
                /*Console.Write("Enter new name : ");
                string B_Name = Console.ReadLine();
                Console.Write("Enter new Author : ");
                string A_Name = Console.ReadLine();
                Console.Write("Enter new Price : ");
                double B_Price = double.Parse(Console.ReadLine());
*/

                /* Console.WriteLine("Select the Category\n1.Fiction\t2.Science");
                 int category_id = int.Parse(Console.ReadLine());
                 var categoryName = category.fiction;
                 if (category_id == 1)
                 {
                     categoryName = category.fiction;
                 }
                 else if (category_id == 2)
                 {
                     categoryName = category.Science;
                 }
                 */

                /*  Console.Write("\nEnter Book Description : ");
                  string B_Description = Console.ReadLine();
                  Console.Write("\nEnter Book Quantity : ");
                  int B_Qty = Convert.ToInt32(Console.ReadLine());*/

                Console.Write("\nEnter New ISBN : ");
                string b_isbn = Console.ReadLine();
                Console.Write("\nEnter New Book Language : ");
                string b_language = Console.ReadLine();
                Console.Write("\nEnter New Book Publisher : ");
                string b_publisher = Console.ReadLine();
                Console.Write("\nEnter New Total Book Pages : ");
                int b_pages = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter New Book Publication Date : ");
                string b_date = Console.ReadLine();
                Console.Write("\nEnter New Book Name : ");
                string b_name = Console.ReadLine();
                Console.Write("\nEnter New Author Name : ");
                string b_author = Console.ReadLine();
                Console.Write("\nEnter New Book Price : ");
                double b_price = Convert.ToDouble(Console.ReadLine());
                /* Console.WriteLine("Select the Category\n1.Action And Adventure\n2.Classic\n3.Comic Book Or Graphic Novel\n4.Detective And Mystry\n5.Fantasy\n6.Historical Fiction\n7.Horror\n8.Literary Fiction\n9.Romance\n10.Science Fiction");
                 int category_id = int.Parse(Console.ReadLine());
                 var categoryName = Category.Action_and_Adventure;
                 if (category_id == 1)
                 {
                     categoryName = Category.Action_and_Adventure;
                 }
                 else if (category_id == 2)
                 {
                     categoryName = Category.Classics;
                 }
                 else if (category_id == 3)
                 {
                     categoryName = Category.Comic_Book_or_Graphic_Novel;
                 }
                 else if (category_id == 4)
                 {
                     categoryName = Category.Detective_and_Mystery;
                 }
                 else if (category_id == 5)
                 {
                     categoryName = Category.Fantasy;
                 }
                 else if (category_id == 6)
                 {
                     categoryName = Category.Historical_Fiction;
                 }
                 else if (category_id == 7)
                 {
                     categoryName = Category.Horror;
                 }
                 else if (category_id == 8)
                 {
                     categoryName = Category.Literary_Fiction;
                 }

                 else if (category_id == 9)
                 {
                     categoryName = Category.Romance;
                 }
                 else if (category_id == 10)
                 {
                     categoryName = Category.Science_Fiction;
                 }*/

                Console.Write("\nEnter New Book Description : ");
                string b_description = Console.ReadLine();

                Console.Write("\nEnter New Book Customer Review : ");
                double b_customer_review = double.Parse(Console.ReadLine());

                Console.Write("\nEnter New Book Quantity : ");
                int b_qty = Convert.ToInt32(Console.ReadLine());

                foreach (var company in customerData.Where<BookDetails>(obj => obj.Book_Id == b_id))
                {
                    company.ISBN_10 = b_isbn;
                    company.Language = !string.IsNullOrEmpty(b_language) ? b_language : b_language;
                    company.Publisher = !string.IsNullOrEmpty(b_publisher) ? b_publisher : b_publisher;
                    company.Total_Pages = b_pages;
                    company.Publication_Date = !string.IsNullOrEmpty(b_date) ? b_date : b_date;
                    company.Book_Name = !string.IsNullOrEmpty(b_name) ? b_name : b_name;
                    company.Book_Author = !string.IsNullOrEmpty(b_author) ? b_author : b_author;
                    company.Book_Price = !double.IsNaN(b_price) ? b_price : b_price;
                    company.Book_Description = !string.IsNullOrEmpty(b_description) ? b_description : b_description;
                    company.Customer_Review = !double.IsNaN(b_customer_review) ? b_customer_review : b_customer_review;
                    company.Book_Qty = b_qty;

                    /*    BookDetails book;
                        Book book2 = new Book();
                        book = new BookDetails()
                      {
                            categoryName = categoryName,       
                      };
                    book2.setBookDetails(book);*/
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(customerData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
        }

        /*   deletebook*/
        /// <summary>
        /// The deleteBookRecord.
        /// </summary>
        public void deleteBookRecord()
        {
            Console.Write("\nEnter Book Id : ");
            int b_id = Convert.ToInt32(Console.ReadLine());
            List<BookDetails> booksList = new List<BookDetails>();
            /// <summary>
            /// The getBooksByCategory.
            /// </summary>
            /// <param name="b">The category_id<see cref="int"/>.</param>
            /// <returns>The <see cref="IEnumerable{BookDetails}"/>.</returns >

            try
            {
                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<BookDetails>>(json) ?? new List<BookDetails>();

                foreach (var compony in customerData.Where<BookDetails>(obj => obj.Book_Id == b_id))
                {
                    if (compony != null)
                    {
                        booksList.Remove(compony);
                    }

                }
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


        }


        /* searchbyname*/


        public void searchByName()
        {

            Console.Write("\nEnter Book Name\t");
            var searchName = Console.ReadLine();
            string search = null;
            try
            {
                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<BookDetails>>(json) ?? new List<BookDetails>();
                foreach (var book_name in customerData.Where<BookDetails>(obj => obj.Book_Name == searchName))
                {
                    search = book_name.Book_Name = !string.IsNullOrEmpty(searchName) ? searchName : searchName;
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(customerData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);

                if (search == searchName)
                {
                    Console.WriteLine("Book is avalable");
                }
                else
                {
                    Console.WriteLine("Book is not avalable");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
