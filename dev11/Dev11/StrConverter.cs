using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev11.Interfaces;

namespace Dev11
{
    class StrConverter : IStrConverter
    {
        protected Dictionary<string, string> alphabetTransLatinToCyrillic;
        protected Dictionary<string, string> alphabetTransCyrillicToLatin;

        public StrConverter ( string pathLatinToCirillic, string pathCirillicToLatin )
        {
            SymbolConverter symbolConvert = new SymbolConverter();
            alphabetTransCyrillicToLatin = symbolConvert.FillDictionary ( pathCirillicToLatin );
            alphabetTransLatinToCyrillic = symbolConvert.FillDictionary ( pathLatinToCirillic );

            // Check right filling of dictionary
            if ( alphabetTransCyrillicToLatin.Count < 15 || alphabetTransLatinToCyrillic.Count < 15 )
            {
                Console.WriteLine( "Something goes wrong. Check the source file with conversion." );
                return;
            }
        }

        // Make translit of string data to cyrillic alpabet
        public string StrLatinToCirillicConverter( string data )
        {
            StringBuilder result = new StringBuilder();

            for ( int i = 0; i < data.Length; i++ )
            {
                string helpSymbol = String.Empty;
                if ( alphabetTransLatinToCyrillic.ContainsKey( data[i].ToString() ) )
                {
                    alphabetTransLatinToCyrillic.TryGetValue( data[ i ].ToString(), out helpSymbol );
                    result.Append( helpSymbol );
                }
                else
                {
                    result.Append( data [ i ] );
                }
            }
            return result.ToString();
        }

        // Make translit of string data to latin alpabet
        public string StrCirillicToLatinConverter( string data )
        {
            StringBuilder result = new StringBuilder();

            for ( int i = 0; i < data.Length; i++ )
            {
                string helpSymbol = String.Empty;
                if ( i != 0 && data [ i ] == 'е' && ( data [ i - 1 ] == ' ' || data [ i - 1 ] == 'а' ||
                    data [ i - 1 ] == 'о' || data [ i - 1 ] == 'у' || data [ i - 1 ] == 'ы' ||
                    data [ i - 1 ] == 'и' || data [ i - 1 ] == 'э' || data [ i - 1 ] == 'я' ||
                    data [ i - 1 ] == 'ю' || data [ i - 1 ] == 'ь' || data [ i - 1 ] == 'ъ'))
                {
                    alphabetTransCyrillicToLatin.TryGetValue( ( data[ i - 1 ].ToString() + data[ i ].ToString()), out helpSymbol ); 
                    result.Append ( helpSymbol );
                    continue;
                }
                if ( i != 0 && data [ i ] == 'я' && data [ i - 1 ] == 'ь')
                {
                    alphabetTransCyrillicToLatin.TryGetValue( ( data[ i - 1 ].ToString() + data [ i ].ToString() ), out helpSymbol );
                    result.Append ( helpSymbol );
                    continue;
                }
                if (( i != ( data.Length - 1)) && i > 1 && ( data [ i ] == 'и' || data [ i ] == 'ы') && data [ i + 1 ] == 'й' && 
                    !alphabetTransCyrillicToLatin.ContainsKey( data [ i + 1 ].ToString() ) )
                {
                    alphabetTransCyrillicToLatin.TryGetValue ( ( data [ i ].ToString() + data [ i + 1 ].ToString() ), out helpSymbol );
                    result.Append ( helpSymbol );
                    i += 2;
                    continue;
                }

                if ( alphabetTransCyrillicToLatin.ContainsKey( data [ i ].ToString() ) )
                {
                    alphabetTransCyrillicToLatin.TryGetValue( data [ i ].ToString(), out helpSymbol );
                    result.Append ( helpSymbol );
                }
                else
                {
                    result.Append ( data [ i ] );
                }
            }
            return result.ToString();
        }
    }
}
