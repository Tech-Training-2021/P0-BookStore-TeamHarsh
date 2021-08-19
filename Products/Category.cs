using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
namespace Products
{
    public class Category 
    {
        public string path = @"..\..\..\..\JSON\Category.json";
        public IEnumerable<Category_Def> getAllCategories() 
        {
            try
            {
                var data = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<List<Category_Def>>(data);
                if (result.Count > 0)
                {
                    return result;
                }
                else return null;
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
            return null;
        }

    }
   
}
