using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Encryption_Decryption_Password;
namespace Customer
{

    public class Registration
    {
        public string path = @"..\..\..\..\JSON\Customers.json";
        //"C:\Users\Admin\Documents\Book-Store\JSON"

        public void setDetails(UserDetails userDetails)
        {
            try
            {
                var json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<UserDetails>>(json) ?? new List<UserDetails>();
                customerData.Add(userDetails);
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(customerData,
                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                Console.WriteLine("\nDetails Entered Successfully");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }
        public int getId()
        {
            var json = File.ReadAllText(path);
            var customerData = JsonConvert.DeserializeObject<List<UserDetails>>(json) ?? new List<UserDetails>();
            return customerData.Count;
        }
        public IEnumerable<UserDetails> getAllUserDetails()
        {
            try
            {
                var data = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<List<UserDetails>>(data) ?? new List<UserDetails>();
                if (result.Count > 0)
                {
                    return result;
                }
                else return null;
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
            return null;
        }
        public void getUserDetails()
        {
            UserDetails register = null;
            Registration registration = new Registration();
        Name: Console.Write("Enter Name\t");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Name Cannot be null");
                goto Name;
            }
            else if (name == "")
            {
                Console.WriteLine("Name cannot be empty");
                goto Name;
            }
        Email: Console.Write("\nEnter Email Address\t");
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
        check:
            Console.Write("\nEnter Password\t");
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
        checkPassword:    Console.Write("\nEnter Confirm Password\t");
            var confirmPassword = string.Empty;
            ConsoleKey key1;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key1 = keyInfo.Key;

                if (key1 == ConsoleKey.Backspace && confirmPassword.Length > 0)
                {
                    Console.Write("\b \b");
                    confirmPassword = confirmPassword[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    confirmPassword += keyInfo.KeyChar;
                }
            } while (key1 != ConsoleKey.Enter);
            if (confirmPassword == null)
            {
                Console.WriteLine("Name Cannot be null");
                goto checkPassword;
            }
            else if (confirmPassword == "")
            {
                Console.WriteLine("Password cannot be empty");
                goto checkPassword;
            }
            int id = registration.getId();
            if (password == confirmPassword)
            {
                register = new UserDetails()
                {
                    Id = id + 1,
                    Name = name,
                    Email = email,
                    Password = AES_Operation.EncryptString(password),
                    role = Role.User
                };
                registration.setDetails(register);
            }
            else
            {
                Console.WriteLine("Password Doesnt Matched!! \n Please Try Again");
                goto check;
            };
        }
    }
}
