using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
   public class Book_def
    {
        public int Book_Id { get; set; }
        public string ISBN_10{get;set;}
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int Total_Pages { get; set; }
        public string Publication_Date { get; set; }
        public string Book_Name { get; set; }
        public string Book_Author { get; set; }
        public double Book_Price { get; set; }
        public CategoryName categoryName { get; set; }
        public string Book_Description { get; set; }
        public double Customer_Review { get; set; }
        public string Book_Image { get; set; }
        public int Book_Qty { get; set; }
    }
    public enum CategoryName 
    {
        Action_and_Adventure=1001, Classics=1002, Comic_Book_or_Graphic_Novel=1003, Detective_and_Mystery=1004, Fantasy=1005, Historical_Fiction=1006,Horror=1007, Literary_Fiction=1008, Romance=1009, Science_Fiction=1010
    }
}
