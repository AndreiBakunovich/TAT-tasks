using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dev9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[2];
            string path = @"c:\Users\source.txt";
            try
            {
                lines = File.ReadAllLines(path);
                if (lines[0] == String.Empty || lines[1] == String.Empty)
                {
                    Console.WriteLine("Incorrect file data format");
                    Console.ReadLine();
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Incorrect file data format.");
                Console.ReadLine();
                return;
            }
            
            char[] lineOneInChar = new char[lines[0].Length];
            char[] lineTwoInChar = new char[lines[1].Length];
            lineOneInChar = lines[0].ToCharArray();
            lineTwoInChar = lines[1].ToCharArray();

            //random string selection
            string result;
            Replacer rep = new Replacer();
            Random rnd = new Random();
            if (rnd.Next(1, 3) == 1)
            {
                
                int lineTwoIntervalStart = rnd.Next(0, lineTwoInChar.Length),
                    lineTwoIntervalFinish = rnd.Next(lineTwoIntervalStart + 1, lineTwoInChar.Length),
                    lineOneIntervalStart = rnd.Next(0, lineOneInChar.Length),
                    lineOneIntervalFinish = rnd.Next(lineOneIntervalStart + 1, lineOneInChar.Length);
                result = rep.ReplacingPartsInStrings(lineOneInChar, lineOneIntervalStart, lineOneIntervalFinish,
                    lineTwoInChar, lineTwoIntervalStart, lineTwoIntervalFinish);
            }
            else
            {
                
                int lineOneIntervalStart = rnd.Next(0, lineOneInChar.Length),
                    lineOneIntervalFinish = rnd.Next(lineOneIntervalStart + 1, lineOneInChar.Length),
                    lineTwoIntervalStart = rnd.Next(0, lineTwoInChar.Length),
                    lineTwoIntervalFinish = rnd.Next(lineTwoIntervalStart + 1, lineTwoInChar.Length);
                result = rep.ReplacingPartsInStrings(lineTwoInChar, lineTwoIntervalStart, lineTwoIntervalFinish,
                    lineOneInChar, lineOneIntervalStart, lineOneIntervalFinish);
            }

            Console.WriteLine("First line: " + lines[0]);
            Console.WriteLine("Second line: " + lines[1]);
            Console.WriteLine("Result of manipulation: " + result);
            Console.Read();
        }
    }
}
