using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace T0002
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "MyNamespace");
            //for (int i = 0; i < typelist.Length; i++)
            //{
            //    Console.WriteLine(typelist[i].Name);
            //}
            var typelist = GetTypesFromNamespace(Assembly.GetExecutingAssembly(), "T0002.Models");
            foreach (var x in typelist)
            {
                Console.WriteLine(x.Name);
            }
            
// CreateHostBuilder(args).Build().Run();
        }

        public static IEnumerable<Type> GetTypesFromNamespace(Assembly assembly,
                                               String desiredNamespace)
        {
            return assembly.GetTypes()
                           .Where(type => type.Namespace == desiredNamespace);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
