using Inventory.Data;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MyFileGenTool
{
    class Program
    {

        public static void ShowEntTypes(string strNamespace)
        {

            //Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "MyNamespace");
            //for (int i = 0; i < typelist.Length; i++)
            //{
            //    Console.WriteLine(typelist[i].Name);
            //}
            var typelist = GetTypesFromNamespace(Assembly.GetExecutingAssembly(), strNamespace);
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


        //https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
        //    var blogs = context.Blogs
        //.FromSqlRaw("SELECT * FROM dbo.Blogs")
        //.ToList();


        //    SELECT
        //        OBJECT_DEFINITION(
        //            OBJECT_ID(
        //                'V_STOCK_CURRENT'
        //    )
        //) view_info;




        //https://stackoverflow.com/questions/45667126/how-to-get-table-name-of-mapped-entity-in-entity-framework-core
        //var entityType = dbContext.Model.FindEntityType(typeof(YourEntity));
        //var schema = entityType.GetSchema();
        //var tableName = entityType.GetTableName();
        public static void LoopDbSet()
        {
            DbContextOptions<TaiweiContext> b = new();
            //  DbContextOptionsBuilder< TaiweiContext> b = new();
            var db = new TaiweiContext(b);
            //   IEnumerable<Type> 
            var entityTypes = db.Model.GetEntityTypes();
            foreach (var x in entityTypes)
            {
                Console.WriteLine(x.DisplayName() + "," + x.GetTableName() + "," + x.GetViewName());

                if (!(x.GetViewName() == null || x.GetViewName() == ""))
                {
                    Console.WriteLine("To get View info");

                    var Info = db.SimpleReturn.FromSqlRaw(@"  SELECT
                                        OBJECT_DEFINITION(
                                        OBJECT_ID(
                                                'V_STOCK_CURRENT'
                                    )
                                ) Info;").ToList();
                    foreach (var x2 in Info)
                    {
                        Console.WriteLine("=*** =" + x2.Info);

                    }
                }

            }
        }


        public static (string,string) GetDbSetTableOrView(string target)
        {
            DbContextOptions<TaiweiContext> b = new();
            var db = new TaiweiContext(b);
            var entityTypes = db.Model.GetEntityTypes();
            foreach (var x in entityTypes)
            {
                if (x.DisplayName() == target)
                {
                    if (!(x.GetViewName() == null || x.GetViewName() == ""))
                    {
                        return ("View", x.GetViewName());
                    }
                    return  ("Table", x.GetTableName());


                    if (!(x.GetViewName() == null || x.GetViewName() == ""))
                    {
                        Console.WriteLine("To get View info");

                        var Info = db.SimpleReturn.FromSqlRaw(@"  SELECT
                                        OBJECT_DEFINITION(
                                        OBJECT_ID(
                                                'V_STOCK_CURRENT'
                                    )
                                ) Info;").ToList();
                        foreach (var x2 in Info)
                        {
                            Console.WriteLine("=*** =" + x2.Info);

                        }
                    }
                }

            }
            return ("???","---");
        }


        static void Main(string[] args)
        {
            //   MakeAdapters();
            // MakeAddService();
            // MakePages();
            //MakeIndexPage();
            MakeIndex();

            //   MakeSwitch();
            //  ShowEntTypes("Inventory.Data");

            //LoopDbSet();

        }
        static void MakeSwitch()
        {
            string basePath = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\MyFileGenTool\GenSwitch\";
            string file1 = basePath + "Switch1.txt";
            string file2 = basePath + "Switch2.txt";

            //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");

            if (!File.Exists(file1))
            {
                Console.WriteLine(file1 + " switch 模板 NOT FOUND?");
                return;
            }
            string textTemplate = System.IO.File.ReadAllText(file1);
            string key1 = "BasePart";
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext?view=net-5.0
            if (!File.Exists(file2))
            {
                // Create a file to write to.
                File.WriteAllText(file2, "// AUTO GENERATED BY ... " + DateTime.Now);
            }
            foreach (var x in GetNavInfoList())
            {
                //MakePage(x.PRE, x.ENT, x.TITLE);
                string appendText = textTemplate.Replace(key1, x.ENT);
                File.AppendAllText(file2, appendText);

            }

        }
        static void MakeList()
        {
            //var entityType = dbContext.Model.FindEntityType(typeof(YourEntity));
            //var schema = entityType.GetSchema();
            //var tableName = entityType.GetTableName();
        }
        static List<NavInfo> GetNavInfoList()
        {
            List<NavInfo> nav = new();
            nav.Add(new NavInfo("A001", "BasePart", "物料"));
            nav.Add(new NavInfo("A002", "BaseOperator", "操作人員"));
            nav.Add(new NavInfo("A003", "VInoutType", "入出庫狀態設置"));
            nav.Add(new NavInfo("A004", "SysParameter", "編碼查表"));
            nav.Add(new NavInfo("A005", "SysConfig", "系統配置"));
            nav.Add(new NavInfo("A006", "BaseDocureason", "理由碼設置"));

            nav.Add(new NavInfo("A011", "VInasn", "入庫通知單"));
            nav.Add(new NavInfo("A012", "Inbill", "入庫單"));

            nav.Add(new NavInfo("A021", "V2Outasn", "出庫通知單"));
            nav.Add(new NavInfo("A022", "V2Outbill", "出庫單"));

            nav.Add(new NavInfo("A031", "VStockCurrent", "庫存查詢"));
            nav.Add(new NavInfo("A032", "V2StockCurrentAdjust", "庫存查詢"));

            nav.Add(new NavInfo("A041", "VCmdMst", "WCS命令查詢"));
            return nav;
        }

        static void MakePages()
        {
            // --------------- maing pages
            // A999是 原型
            foreach (var x in GetNavInfoList())
            {
                MakePage(x.PRE, x.ENT, x.TITLE);
            }

        }

        static void MakeIndex()
        {
            // --------------- maing pages
            // A999是 原型
            string basePath = @"D:\ZZZ\Gen001\";
            string path = basePath + "index_list.txt";
            StringBuilder sb = new();
            sb.Append("<table class=\"gridtable\">");
            sb.Append(Environment.NewLine);
            sb.Append("<tr><th></th><th>PRE</th><th>Entity</th><th>頁面顯示名稱</th><th>T/V</th><th>數據庫Table/View</th></tr>");
            sb.Append(Environment.NewLine);
            int k = 0;
            foreach (var x in GetNavInfoList())
            {
                k++;
                sb.Append(MakeIndexCore(k,x));
                sb.Append(Environment.NewLine);

            }
            sb.Append("</table>");
            sb.Append(Environment.NewLine);

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            Console.WriteLine("Please check file: " + path);
        }

        private static string MakeIndexCore(int seq,NavInfo x)
        {
            StringBuilder sb = new();
            sb.Append("<tr>");
            sb.Append("<th>");
            sb.Append(seq);
            sb.Append("</th>");
            sb.Append("<td>");
            sb.Append("<a href=\"");
            sb.Append(x.PRE);

            sb.Append("\">");
            sb.Append(x.PRE);
            sb.Append("</a>");


            sb.Append("</td>");



            sb.Append("<td>");
            sb.Append(x.ENT);
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append(x.TITLE);
            sb.Append("</td>");
            string v1, v2;
            (v1, v2) = GetDbSetTableOrView(x.ENT);
            sb.Append("<td>");
            sb.Append(v1);
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append(v2);
            sb.Append("</td>");

            sb.Append("</tr>");

            return sb.ToString();
            //    Console.WriteLine("" + x.PRE);
        }

        static void MakePages_OLD()
        {
            // --------------- maing pages
            // A999是 原型
            MakePage("A001", "BasePart", "物料");
            MakePage("A002", "BaseOperator", "操作人員");
            MakePage("A003", "VInoutType", "入出庫狀態設置");
            MakePage("A004", "SysParameter", "編碼查表");
            MakePage("A005", "SysConfig", "系統配置");
            MakePage("A006", "BaseDocureason", "理由碼設置");

            MakePage("A011", "VInasn", "入庫通知單");
            MakePage("A012", "Inbill", "入庫單");

            MakePage("A021", "V2Outasn", "出庫通知單");
            MakePage("A022", "V2Outbill", "出庫單");

            MakePage("A031", "VStockCurrent", "庫存查詢");
            MakePage("A032", "V2StockCurrentAdjust", "庫存查詢");

            MakePage("A041", "VCmdMst", "WCS命令查詢");

        }
        static void GetClass()
        {
            //https://stackoverflow.com/questions/2408789/getting-class-type-from-string
            //     Class <?> cls = Class.forName(className);
        }
        static void MakeAdapters()
        {
            string basePath = @"D:\ZZZ\Gen001\Adapters\";
            string path = basePath + "A001Adapter.cs";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine(path + " 不存在");
                return;
            }
            string key1 = "A001";
            string path2 = @"D:\ZZZ\Gen001\MyTest.txt";
            string str = File.ReadAllText(path);
            string SEQ = "002";
            string key1x = "A002";

            string fmt = "000";
            string str2;
            for (int i = 2; i <= 99; i++)
            {
                //  Console.WriteLine(i.ToString(fmt));
                SEQ = i.ToString(fmt);
                key1x = "A" + SEQ;
                path2 = basePath + "auto\\" + key1x + "Adapter.cs";
                str2 = str.Replace(key1, key1x);
                File.WriteAllText(path2, str2, Encoding.UTF8);
            }


            //   Console.WriteLine(str);
        }

        /**
         * 根據 project 所在的 Pages
         * LOOP 所有 Blazor 檔案, 
         * 取其
         * 
    private string TITLE = "出庫通知單";
    private string PRE = "A004";
    private string ENT = "V2Outasn";
         */
        static void MakeIndexPage()
        {
            string basePath = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\Inventory\A000\Pages\";
            Console.WriteLine("TO LOOP " + basePath);
            string[] files = null;
            //files = StackBasedIteration.TraverseTree(basePath);
            //string[] files = null;
            //    string path;
            //https://www.c-sharpcorner.com/article/c-sharp-regex-examples/
            //https://stackoverflow.com/questions/32637891/return-the-whole-line-that-contains-a-match-using-regular-expressions-in-c-sharp
            //string pattern = @"private string TITLE\w+";
            string pattern = @".*private string TITLE =.*";
            // Create a Regex  
            Regex rg = new Regex(pattern);//

            /**
        private string TITLE = "出庫單";
        private string PRE = "A999";
        private string ENT = "V2Outbill";
             */


            try
            {
                files = Directory.GetFiles(basePath);


                foreach (var file in files)
                {
                    //   Console.WriteLine(file);
                    //    path = basePath + file;
                    string str = File.ReadAllText(file);
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    //    Console.WriteLine( fi.Name);

                    string v1 = GetTITLE(str);
                    string v2 = GetPRE(str);
                    string v3 = GetENT(str);
                    Console.WriteLine(" " + v2 + "\t" + v1 + "\t\t" + v3 + "\t\t" + fi.Name);
                    //Console.WriteLine("PRE:" + v2, "ENT:" + v3);
                    //Console.WriteLine("TITLE:" + v1, "PRE:" + v2, "ENT:" + v3);

                    //var keyInfo = GetKeyInfo(str);
                    //Console.WriteLine(keyInfo.Item1, keyInfo.Item2, keyInfo.Item3);


                    //MatchCollection matchedAuthors = rg.Matches(str);
                    //for (int count = 0; count < matchedAuthors.Count; count++)
                    //    Console.WriteLine(matchedAuthors[count].Value);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        static (string, string, string) GetKeyInfo(string str)
        {
            string v1 = GetTITLE(str);
            string v2 = GetPRE(str);
            string v3 = GetENT(str);
            return (v1, v2, v3);

        }

        static string GetTITLE(string str)
        {
            string v1 = GetRegularExpressLine(str, @".*private string TITLE =.*");
            return GetValue(v1);
        }
        static string GetPRE(string str)
        {
            string v1 = GetRegularExpressLine(str, @".*private string PRE =.*");
            return GetValue(v1);
        }
        static string GetENT(string str)
        {
            string v1 = GetRegularExpressLine(str, @".*private string ENT =.*");
            return GetValue(v1);
        }


        static string GetValue(string str)
        {
            string[] v2 = str.Split("=");
            if (v2.Length != 2)
                return "";
            string v3 = v2[1];
            string v4 = v3.Replace("\"", "").Replace(";", "").Trim();
            return v4.Replace("\"", "");
        }




        static string GetRegularExpressLine(string str, string pattern)
        {
            // string pattern = @".*private string TITLE =.*";
            // Create a Regex  
            Regex rg = new Regex(pattern);//

            MatchCollection matchedAuthors = rg.Matches(str);
            for (int count = 0; count < matchedAuthors.Count; count++)
            {
                return matchedAuthors[count].Value;
                //     Console.WriteLine(matchedAuthors[count].Value);

            }
            return "";
        }


        static void MakePage(string PRE, string ENT, string TITLE)
        {
            string basePath = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\MyFileGenTool\Gen\";

            //NOTE by Mark, 2021-01-25, 直接寫入工作目錄
            string basePath2 = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\Inventory\A000\Pages\";

            string path = basePath + "A999V2Outbill.razor"; //這是提供原型
                                                            //     string path2 =basePath2 + "A005V2Outbill.razor";
                                                            // This text is added only once to the file.


            if (!File.Exists(path))
            {
                Console.WriteLine(path + " 不存在 , 請給 原型");
                return;
            }

            string str = File.ReadAllText(path);
            string key0 = "出庫單";
            string key1 = "A999";
            string key2 = "V2Outbill";

            string pathFinal = basePath + PRE + ENT + ".razor";
            string path2Final = basePath2 + PRE + ENT + ".razor";



            var strFinal = str.Replace(key0, TITLE).Replace(key1, PRE).Replace(key2, ENT);

            File.WriteAllText(pathFinal, strFinal, Encoding.UTF8);
            File.WriteAllText(path2Final, strFinal, Encoding.UTF8);


            //   Console.WriteLine(str);
        }

        static void MakeAddService()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-5.0
            string path = @"D:\ZZZ\Gen001\Startup_AddService.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "services.AddScoped<A001Adapter>();" + Environment.NewLine;


                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string fmt = "000";
            string SEQ = "002";
            string appendText = "services.AddScoped<A002Adapter>();";
            for (int i = 2; i <= 99; i++)
            {
                SEQ = i.ToString(fmt);
                appendText = "services.AddScoped<A" + SEQ + "Adapter>();" + Environment.NewLine;
                File.AppendAllText(path, appendText, Encoding.UTF8);
            }

            //   appendText = appendText.Replace("extra", "額外的");



            // Open the file to read from.
            //      string readText = File.ReadAllText(path);
            //      Console.WriteLine(readText);
        }


        static void MakePageV2(PageInfo p)
        {
            string PRE = p.PRE;
            string ENT = p.ENT;
            string TITLE = p.TITLE;

            string basePath = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\MyFileGenTool\Gen\";

            //NOTE by Mark, 2021-01-25, 直接寫入工作目錄
            string basePath2 = @"D:\2021\Lab\Hot\BlazorServerDbContextExample\BlazorServerEFCoreSample\Inventory\A000\Pages\";

            string path = basePath + "A999V2Outbill.razor"; //這是提供原型
                                                            //     string path2 =basePath2 + "A005V2Outbill.razor";
                                                            // This text is added only once to the file.


            if (!File.Exists(path))
            {
                Console.WriteLine(path + " 不存在 , 請給 原型");
                return;
            }

            string str = File.ReadAllText(path);
            string key0 = "出庫單";
            string key1 = "A999";
            string key2 = "V2Outbill";

            string pathFinal = basePath + PRE + ENT + ".razor";
            string path2Final = basePath2 + PRE + ENT + ".razor";



            var strFinal = str.Replace(key0, TITLE).Replace(key1, PRE).Replace(key2, ENT);

            File.WriteAllText(pathFinal, strFinal, Encoding.UTF8);
            File.WriteAllText(path2Final, strFinal, Encoding.UTF8);


            //   Console.WriteLine(str);
        }

        static void XXXMakeAddService()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-5.0
            string path = @"D:\ZZZ\Gen001\Startup_AddService.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "services.AddScoped<A001Adapter>();" + Environment.NewLine;


                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string fmt = "000";
            string SEQ = "002";
            string appendText = "services.AddScoped<A002Adapter>();";
            for (int i = 2; i <= 99; i++)
            {
                SEQ = i.ToString(fmt);
                appendText = "services.AddScoped<A" + SEQ + "Adapter>();" + Environment.NewLine;
                File.AppendAllText(path, appendText, Encoding.UTF8);
            }

            //   appendText = appendText.Replace("extra", "額外的");



            // Open the file to read from.
            //      string readText = File.ReadAllText(path);
            //      Console.WriteLine(readText);
        }
        static void Sample()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-5.0
            string path = @"D:\ZZZ\Gen001\MyTest.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "中文Hello and Welcome" + Environment.NewLine;


                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;

            appendText = appendText.Replace("extra", "額外的");

            File.AppendAllText(path, appendText, Encoding.UTF8);

            // Open the file to read from.
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
    }
}
