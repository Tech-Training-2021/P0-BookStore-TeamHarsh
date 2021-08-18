using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Admin
{
   public class BookDetails
    {
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Book_Author { get; set; }
        public double Book_Price { get; set; }
        public category categoryName { get; set; }

        public string Book_Description { set; get; }
        public int Book_Qty { set; get; }

    }
    public enum category
    {
        fiction=1001,Science=1002
    }
}
