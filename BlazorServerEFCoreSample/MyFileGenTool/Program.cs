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
              string path = @"D:\ZZZ\Gen001\Adapters\A001Adapter.cs";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine(path +" 不存在");
                return;
            }

            string str = File.ReadAllText(path);
            string fmt = "000";
            for (int i = 1; i <= 99; i++)
            {
                Console.WriteLine(i.ToString(fmt));
            }


            Console.WriteLine(str);
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
