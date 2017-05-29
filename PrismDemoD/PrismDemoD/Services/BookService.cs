using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PrismDemoD.Models;

namespace PrismDemoD.Services
{
    public class BookService : IBookService
    {
        public async Task<IList<BookGroup>> GetBookGroups()
        {
            // Read RecipeData.json from this PCL's DataModel folder
            var name = typeof(BookService).AssemblyQualifiedName.Split(',')[1].Trim();
            var assembly = Assembly.Load(new AssemblyName(name));
            var stream = assembly.GetManifestResourceStream(name + ".Data.Booklist2.json");

            // Parse the JSON and generate a collection of RecipeGroup objects
            using (var reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                var obj = new { Groups = new List<BookGroup>() };
                var result = JsonConvert.DeserializeAnonymousType(json, obj);
                return result.Groups;

            }
        }
    }
}
