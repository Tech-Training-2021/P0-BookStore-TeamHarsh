using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Customer
{
   public class UserSession
    {
        public string path = @"..\..\..\..\JSON\UserSession.json";
        public UserDetails getSession()
        {
            
            try
            {
                var json = File.ReadAllText(path);
                var customerData = JsonConvert.DeserializeObject<UserDetails>(json) ?? new UserDetails();
                return customerData;
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
            return null;
        }
        public void setSession (UserDetails userDetails)
        {
            try
            {
                var json = File.ReadAllText(path);
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails,
                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
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
    }
}
