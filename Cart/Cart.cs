using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer;
using Products;
namespace Cart
{
   public class Cart
    {
        public UserDetails userDetails { get; set; }   
     public List<cart_def> cart_details { get; set; }  
    }
    public class cart_def
    {
        public Book_def book_Def { get; set; }
        public int quantity { get; set; }
    }
}
