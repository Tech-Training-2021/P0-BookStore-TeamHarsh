using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class getUserDetails
    {
        public  UserDetails getUserById(int id)
        {
            Registration registration = new Registration();
            var customers = registration.getAllUserDetails();
            var customer = customers.Where<UserDetails>(x => x.Id == id).FirstOrDefault();
            return customer;
        }
    }
}
