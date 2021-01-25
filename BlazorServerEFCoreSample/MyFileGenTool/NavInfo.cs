using System;
using System.Collections.Generic;
using System.Text;

namespace MyFileGenTool
{
    class NavInfo
    {
        public NavInfo(string v1, string v2, string v3)
        {
            PRE = v1;
            ENT = v2;
            TITLE = v3;

        }
        public string PRE { get; set; }
        public string ENT { get; set; }
        public string TITLE { get; set; }
    }
}
