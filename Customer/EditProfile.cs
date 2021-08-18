using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Encryption_Decryption_Password;
namespace Customer
{
    public class EditProfile
    {
        public string path = @"..\..\..\..\JSON\Customers.json";
        public void editName()
        {
            var details = getDetails();
            Console.WriteLine("Old Name = " + details.Name);
            var id = details.Id;
            Console.Write("\nEnter New Name\t");
            var newName = Console.ReadLine();
            try
            {
                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<UserDetails>>(json) ?? new List<UserDetails>();
                foreach (var company in customerData.Where<UserDetails>(obj => obj.Id == id))
                {
                    company.Name = !string.IsNullOrEmpty(newName) ? newName : details.Name;
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(customerData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                getUserDetails user = new getUserDetails();
                var customer=user.getUserById(id);
                UserSession userSession = new UserSession();
                userSession.setSession(new UserDetails()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password
                });
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
        }
        public void editEmail()
        {
            var details = getDetails();
            Console.WriteLine("Old Email  = " + details.Email);
            var id = details.Id;
            Console.Write("\nEnter New Email\t");
            var newEmail = Console.ReadLine();
            try
            {
                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<UserDetails>>(json) ?? new List<UserDetails>();
                foreach (var company in customerData.Where<UserDetails>(obj => obj.Id == id))
                {
                    company.Email = !string.IsNullOrEmpty(newEmail) ? newEmail : details.Email;
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(customerData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                getUserDetails user = new getUserDetails();
                var customer = user.getUserById(id);
                UserSession userSession = new UserSession();
                userSession.setSession(new UserDetails()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password
                });
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
        }
        public void editPassword()
        {
            var details = getDetails();
            var id = details.Id;
            Console.Write("\nEnter New Password\t");
            var newPassword = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && newPassword.Length > 0)
                {
                    Console.Write("\b \b");
                    newPassword = newPassword[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    newPassword += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            try
            {
                string json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<List<UserDetails>>(json) ?? new List<UserDetails>();
                foreach (var company in customerData.Where<UserDetails>(obj => obj.Id == id))
                {
                    company.Password = !string.IsNullOrEmpty(newPassword) ? AES_Operation.EncryptString(newPassword) : details.Password;
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(customerData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                getUserDetails user = new getUserDetails();
                var customer = user.getUserById(id);
                UserSession userSession = new UserSession();
                userSession.setSession(new UserDetails()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password
                });
            }
            catch (Exception e) { Console.WriteLine(e.Message.ToString()); }
        }
        public UserDetails getDetails()
        {
            UserSession userSession = new UserSession();
            return userSession.getSession();
        }
        public void getEditOptions()
        {
        options:
            Console.WriteLine("1.Edit Name\n2.Edit Email\n3.Edit Password");
            Console.WriteLine("Enter choice\t");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    editName();
                    break;
                case 2:
                    editEmail();
                    break;
                case 3:
                    editPassword();
                    break;
                default:
                    Console.WriteLine("Please Enter Proper Choice");
                    goto options;
                    break;
            }
        }
    }
}
