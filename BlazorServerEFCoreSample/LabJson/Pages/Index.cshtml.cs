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
using Dreamaitek.Chenpingling;

namespace LabJson.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Plan> Plans;
        public void OnGet()
        {
     

            string localFile = "D:\\2021\\Lab\\Lab0116\\BlazorServerDbContextExample\\BlazorServerEFCoreSample\\LabJson\\plan.json";
            using StreamReader r = new StreamReader(localFile);

            string json = r.ReadToEnd();
            Plans = JsonConvert.DeserializeObject<List<Plan>>(json);
            
        }
 
    }
}
