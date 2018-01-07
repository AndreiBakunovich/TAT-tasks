using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Dev11
{
    class SymbolConverter
    {
        public Dictionary<string, string> FillDictionary(string path)
        {
            Dictionary<string, string> alphabetTranslit = new Dictionary<string, string>();

            try
            {
                TextReader strRead = new StreamReader( path, Encoding.GetEncoding ( 1251 ) );
                string line = String.Empty;
                line = strRead.ReadLine();
                while (line != null)
                {
                    alphabetTranslit.Add(line.Substring(0, line.IndexOf("=")),
line.Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1));
                    line = strRead.ReadLine();
                }
                strRead.Close();
            }
            catch
            {
                Console.WriteLine( "Something goes wrong. Check data format in file with alphabet." );
                return alphabetTranslit;
            }
            return alphabetTranslit;
        }
    }
}
