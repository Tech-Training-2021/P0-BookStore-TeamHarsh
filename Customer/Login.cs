using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption_Decryption_Password;

namespace Customer
{
   public class Login
    {
        public bool login()
        {
            Email: Console.WriteLine("Enter Email Address\t");
            string email = Console.ReadLine();
            if (email == null)
            {
                Console.WriteLine("Email Cannot be null");
                goto Email;
            }
            else if (email == "")
            {
                Console.WriteLine("Email cannot be empty");
                goto Email;
            }
       check:Console.Write("\nEnter Password\t");
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            if (password == null)
            {
                Console.WriteLine("Name Cannot be null");
                goto check;
            }
            else if (password == "")
            {
                Console.WriteLine("Password cannot be empty");
                goto check;
            }
            Registration registration = new Registration();
            var customers = registration.getAllUserDetails();
            var count = 0;
            foreach (var customer in customers)
            {
                if (email == customer.Email && password == AES_Operation.DecryptString(customer.Password))
                {

                    count = count + 1;
                    UserSession userSession = new UserSession();
                    userSession.setSession(new UserDetails()
                    {
                        Id = customer.Id,Name=customer.Name,Email=customer.Email,Password=customer.Password
                    });
                }
                else count = count;
            }
            if (count == 1) return true;
            else return false;
        }
    }
}
