using System;
using System.IO;
using System.Text;

namespace MyFileGenTool
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeAdapter();
        }

        static void MakeAdapter()
        {
            string basePath = @"D:\ZZZ\Gen001\Adapters\";
            string path = basePath+"A001Adapter.cs";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine(path +" 不存在");
                return;
            }
            string key1 = "A001";
            string path2 = @"D:\ZZZ\Gen001\MyTest.txt";
            string str = File.ReadAllText(path);
            string SEQ = "002";
            string key1x = "A002";

            string fmt = "000";
            string str2;
            for (int i = 2; i <= 9; i++)
            {
                //  Console.WriteLine(i.ToString(fmt));
                SEQ = i.ToString(fmt);
                key1x = "A" + SEQ;
                path2 = basePath + key1x+ "Adapter.cs";
                str2 = str.Replace(key1, key1x);
                File.WriteAllText(path2, str2, Encoding.UTF8);
            }


         //   Console.WriteLine(str);
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
