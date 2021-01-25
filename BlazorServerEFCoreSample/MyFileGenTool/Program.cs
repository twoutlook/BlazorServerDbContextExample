﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MyFileGenTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //   MakeAdapters();
            // MakeAddService();
            // MakePages();
            MakeIndexPage();

        }

        static void MakePages()
        {
            // --------------- maing pages
            // A999是 原型
            MakePage("A001", "BasePart", "物料");
            MakePage("A002", "BaseOperator", "物料");
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
                    Console.WriteLine( fi.Name);

                    string v1 = GetTITLE(str);
                    string v2 = GetPRE(str);
                    string v3 = GetENT(str);
                    Console.WriteLine("TITLE:" + v1+" PRE:" + v2 + " ENT:" + v3);
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
