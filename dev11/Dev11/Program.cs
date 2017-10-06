using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dev11
{
    class Program
    {
        private const string pathAlpabetCyrillicToLatin = @"c:\Users\CirillicToLatin.txt";
        private const string pathAlpabetLatinToCyrillic = @"c:\Users\LatinToCirillic.txt";
        private const string path = @"c:\Users\source.txt";

        static void Main( string[] args )
        {
            // Read string to convert from file
            string data;
            try
            {
                TextReader textRead = new StreamReader(path, Encoding.GetEncoding(1251));
                data = textRead.ReadLine();
                if ( data == String.Empty )
                {
                    Console.WriteLine ( "Incorrect file data format or its empty. Check the file {0}", path );
                    Console.ReadLine();
                    return;
                }
                textRead.Close();
            }
            catch
            {
                Console.WriteLine ( "Incorrect file data format." );
                Console.ReadLine();
                return;
            }

            // Detecting type of alphabet in data
            StrConverter strConvert = new StrConverter ( pathAlpabetLatinToCyrillic, pathAlpabetCyrillicToLatin );
            char dataFormat = 'c';
            int checkFormatLength = 10;
            if ( data.Length < 10 ) checkFormatLength = data.Length;
            for ( int i = 0; i < checkFormatLength; i++ )
            {
                if (( data[i] > 64 && data[i] < 91 ) || ( data[i] > 96 && data[i] < 123 ))
                {
                    dataFormat = 'l';
                }
            }

            // Translit string in according with detecting type
            string dataTranslit = String.Empty;
            if ( dataFormat == 'l')
            {
                dataTranslit = strConvert.StrLatinToCirillicConverter(data);
            }
            else if ( dataFormat == 'c') dataTranslit = strConvert.StrCirillicToLatinConverter(data);

            Console.WriteLine ( "Source data:" + data );
            Console.WriteLine ( "Translited data:" + dataTranslit );
            Console.Read();
        }
    }
}
