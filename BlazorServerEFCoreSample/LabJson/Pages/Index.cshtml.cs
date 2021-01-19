using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickType;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

namespace LabJson.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Welcome> items;
        public void OnGet()
        {
            //using (var webClient = new WebClient())
            //{


            //    var welcome = Welcome.FromJson(jsonString);
            //}

            //JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));

            //using (StreamReader file = File.OpenText(@"c:\videogames.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}

            //     var legal = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Legalease.txt"));


   //         string dir = System.IO.Path.GetDirectoryName(
   //System.Reflection.Assembly.GetExecutingAssembly().Location);
   //         string file = dir + @"g.json";

            string localFile = "D:\\2021\\Lab\\Lab0116\\BlazorServerDbContextExample\\BlazorServerEFCoreSample\\LabJson\\g.json";

            //   using StreamReader r = new StreamReader("D:\\2021\\Lab\\Lab0116\\BlazorServerDbContextExample\\BlazorServerEFCoreSample\\LabJson\\g.json");



            //https://stackoverflow.com/questions/10623656/streamreader-to-a-relative-filepath
            //using StreamReader r = new StreamReader(file);
            using StreamReader r = new StreamReader(localFile);

            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<Welcome>>(json);
            
        }
    }
}
