using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace task_01
{
    public class Checker
    {
        // 97 is ASCII code of 'z'
        const int ASCIICodeOfa = 97;
        // 97 is ASCII code of 'a'
        const int ASCIICodeOfz = 122;
        // 92 is ASCII code of '\'
        const char backslash = ( char ) 92;
        //start of very long paths
        string veryLongPathsStart;
        private string [] arrayOfWrongStartString;
        private string [] arrayOfWrongFileNames;
        private string [] arrayOfWrongSymbols;

        //heare paths of files with limitations
        public Checker ()
        {
            veryLongPathsStart = backslash.ToString () + backslash.ToString () + "?" + backslash.ToString ();
            //file path with wrong start value of directories or files
            string pathForWrongStartString = @"f:\Test\ControlWorkFirst\TAT0003.test01\ControlWork1\ControlWork1\WrongStartStrings.txt";
            //file path with wrong file names
            string pathForWrongFileNames = @"f:\Test\ControlWorkFirst\TAT0003.test01\ControlWork1\ControlWork1\WrongFileNames.txt";
            //file path with wrong simbols for file or directory name
            string pathForWrongSymbols = @"f:\Test\ControlWorkFirst\TAT0003.test01\ControlWork1\ControlWork1\WrongSymbols.txt";
            arrayOfWrongStartString = File.ReadAllLines ( pathForWrongStartString );
            arrayOfWrongFileNames = File.ReadAllLines ( pathForWrongFileNames );
            arrayOfWrongSymbols = File.ReadAllLines ( pathForWrongSymbols );
        }

        //Check for existance of forbidden symbols
        private bool CheckForForbiddenSymbols ( string path )
        {
            bool res = true;
            for ( int i = 0 ; i < arrayOfWrongSymbols.Length ; i++ )
            {
                if ( path.Contains ( arrayOfWrongSymbols [ i ] ) )
                {
                    return false;
                }
            }

            if ( ( path.Count ( x => x == '?' ) > 1 ) )
            {
                return false;
            }
            else if ( path.Contains ( '?' ) )
            {
                if ( path.Length < 4 )
                {
                    return false;
                }
                else if ( path.Substring ( 0 , 4 ) != veryLongPathsStart )
                {
                    return false;
                }
            }

            if ( path.Count ( x => x == ':' ) > 1 )
            {
                return false;
            }

            if ( path.Contains ( ':' ) )
            {
                if ( path.Length < 2 )
                {
                    return false;
                }
                else if ( path.Length < 6 && path [ 1 ] != ':' )
                {
                    return false;
                }
                else if ( path.Length > 5 && path [ 1 ] != ':' && path [ 5 ] != ':' )
                {
                    return false;
                }
                else if ( path [ path.IndexOf ( ':' ) - 1 ] > ASCIICodeOfz && path [ path.IndexOf ( ':' ) - 1 ] >= ASCIICodeOfa )
                {
                    return false;
                }
            }

            if ( path.Length > 5 && path [ 5 ] == ':' && path.Substring ( 0 , 4 ) != veryLongPathsStart )
            {
                return false;
            }

            return res;
        }

        //Check for existance of wrong file name or directory names
        private bool CheckForForbiddenNames ( string path )
        {
            bool res = true;
            string lastPartUfterSlash = path.Substring ( path.LastIndexOf ( backslash ) + 1 );

            for ( int i = 0 ; i < arrayOfWrongFileNames.Length ; i++ )
            {
                if ( path.Contains ( backslash + arrayOfWrongFileNames [ i ] + backslash ) )
                {
                    res = false;
                    break;
                }
                if ( path.Contains ( backslash + arrayOfWrongFileNames [ i ] + '.' ) )
                {
                    res = false;
                    break;
                }
                if ( path.Contains ( ':' + arrayOfWrongFileNames [ i ] + '.' ) )
                {
                    res = false;
                    break;
                }
                if ( path.Contains ( ':' + arrayOfWrongFileNames [ i ] + backslash ) )
                {
                    res = false;
                    break;
                }
                if ( lastPartUfterSlash == arrayOfWrongFileNames [ i ] )
                {
                    res = false;
                    break;
                }
                if ( path.StartsWith ( arrayOfWrongFileNames [ i ] + '.' ) )
                {
                    res = false;
                    break;
                }
                if ( path.StartsWith ( arrayOfWrongFileNames [ i ] + backslash ) )
                {
                    res = false;
                    break;
                }
                if ( path == arrayOfWrongFileNames [ i ] )
                {
                    res = false;
                    break;
                }
            }

            return res;
        }

        //Check for existance of wrong start symbols of directories and files
        private bool CheckForForbiddenStartValue ( string path )
        {
            bool res = true;
            string firstPartBeforeSlash;
            try
            {
                firstPartBeforeSlash = path.Substring ( 0 , path.IndexOf ( backslash ) );
            }
            catch
            {
                firstPartBeforeSlash = String.Empty;
            }

            for ( int i = 0 ; i < arrayOfWrongStartString.Length ; i++ )
            {
                if ( path.Contains ( backslash + arrayOfWrongStartString [ i ] ) )
                {
                    res = false;
                    break;
                }
                if ( path.Contains ( ':' + arrayOfWrongStartString [ i ] ) )
                {
                    res = false;
                    break;
                }
                if ( path.Contains ( backslash + arrayOfWrongStartString [ i ] ) )
                {
                    res = false;
                    break;
                }
                if ( firstPartBeforeSlash != String.Empty && firstPartBeforeSlash.StartsWith ( arrayOfWrongStartString [ i ] ) )
                {
                    return false;
                }
            }

            return res;
        }

        private List<string> DividePathForModules ( string path )
        {
            List<string> listOfDirectoriesAndFileNamesInPath = new List<string> ();
            StringBuilder pathMy = new StringBuilder ( path );

            // detect in start '\\?\' and add to List if exist 
            if ( path.Length >= 4 && path.Substring ( 0 , 4 ) == veryLongPathsStart )
            {
                pathMy.Remove ( 0 , 4 );
                listOfDirectoriesAndFileNamesInPath.Add ( veryLongPathsStart );
            }

            // detect in start '<symbol>:' and if exist add to List
            if ( pathMy.Length > 1 && pathMy [ 1 ] == ':' )
            {
                listOfDirectoriesAndFileNamesInPath.Add ( pathMy [ 0 ] + ":" );
                pathMy.Remove ( 0 , 2 );
            }

            //make case like 'a\\\b\\\c\d' in this form 'a\b\c\d'
            int countOfSlash = 0;
            for ( int i = 0 ; i < pathMy.Length ; i++ )
            {
                if ( countOfSlash == 1 && pathMy [ i ] == backslash )
                {
                    pathMy.Remove ( i , 1 );
                    countOfSlash = 0;
                    i--;
                }
                if ( pathMy [ i ] == backslash )
                {
                    countOfSlash++;
                }
                else
                {
                    countOfSlash = 0;
                }
            }

            //divide path for directory names
            StringBuilder directoryName = new StringBuilder ( String.Empty );
            if ( pathMy.Length > 0 && pathMy [ 0 ] == backslash )
            {
                pathMy.Remove ( 0 , 1 );
            }
            for ( int i = 0 ; i < pathMy.Length ; i++ )
            {
                if ( pathMy [ i ] == backslash && directoryName.Length != 0 )
                {
                    pathMy.Remove ( 0 , directoryName.Length );
                    listOfDirectoriesAndFileNamesInPath.Add ( DeleteSpacesFromTheEnd ( directoryName ) );
                    pathMy.Remove ( 0 , 1 );
                    directoryName.Clear ();
                    i = -1;
                }
                else
                {
                    directoryName.Append ( pathMy [ i ] );
                }

                if ( i == pathMy.Length - 1 && pathMy.Length > 0 )
                {
                    pathMy.Remove ( 0 , directoryName.Length );
                    listOfDirectoriesAndFileNamesInPath.Add ( DeleteSpacesFromTheEnd ( directoryName ) );
                    i = 0;
                }
            }

            return listOfDirectoriesAndFileNamesInPath;
        }

        //delete all free spaces from the end of string. 
        //Ex.: function argument "string   ". Function will return "string".
        //if Function argument is line of spaces, then return value is unchanged line.
        private string DeleteSpacesFromTheEnd ( StringBuilder line )
        {
            if ( line.ToString ().Count ( x => x == ' ' ) == line.Length )
            {
                return "|";
            }
            bool hadBeenDeletedAtLeastOneSpace = false;
            if ( line.Length > 0 && line [ line.Length - 1 ] == ' ' )
            {
                for ( int i = line.Length - 1 ; i >= 0 ; i-- )
                {
                    if ( line [ i ] == ' ' )
                    {
                        line.Remove ( i , 1 );
                        hadBeenDeletedAtLeastOneSpace = true;
                    }
                    else
                    {
                        if ( line [ i ] == '.' && hadBeenDeletedAtLeastOneSpace )
                        {
                            return "|";
                        }
                        return line.ToString ();
                    }
                }
            }
            else
            {
                return line.ToString ();
            }

            return line.ToString ();
        }

        // check is length of file names and directory names are correct
        private bool CheckDirectorieNamesLength ( List<string> listOfDirectoryNames )
        {
            bool result = true;

            if ( listOfDirectoryNames [ 0 ].Contains ( veryLongPathsStart ) )
            {
                return true;
            }

            foreach ( string dirName in listOfDirectoryNames )
            {
                if ( dirName.Length >= 256 )
                {
                    return false;
                }
            }
            return result;
        }

        // check is POINT exist on the end of file
        private bool CheckDirectorieNamesForPointOnTheEnd ( List<string> listOfDirectoryNames )
        {
            bool result = true;

            for ( int i = 0 ; i < listOfDirectoryNames.Count ; i++ )
            {
                if ( ( listOfDirectoryNames [ i ].Equals ( "." ) ||
                    listOfDirectoryNames [ i ].Equals ( ".." ) ) &&
                    listOfDirectoryNames.Count - 1 == i &&
                    listOfDirectoryNames [ i ].Length == 1 )
                {
                    return false;
                }
                if ( listOfDirectoryNames [ i ].Count ( x => x == '.' ) == listOfDirectoryNames [ i ].Length &&
                    listOfDirectoryNames [ i ].Length > 2 )
                {
                    return false;
                }
                if ( listOfDirectoryNames [ i ] [ listOfDirectoryNames [ i ].Length - 1 ] == '.' &&
                    listOfDirectoryNames [ i ].Length > 2 )
                {
                    return false;
                }
            }

            return result;
        }

        //check for existance of spaces in forbidden positions ( that was replaced on '|' ) 
        private bool CheckSpaceAfterColon ( List<string> listOfDirectoryNames )
        {
            bool res = true;

            foreach ( string directoryName in listOfDirectoryNames )
            {
                if ( directoryName == "|" )
                {
                    return false;
                }
            }

            return res;
        }

        public bool Check ( string path )
        {
            path = path.ToLower ();

            if ( String.IsNullOrEmpty ( path ) )
            {
                return false;
            }

            if ( !CheckForForbiddenStartValue ( path ) ||
                !CheckForForbiddenNames ( path ) ||
                !CheckForForbiddenSymbols ( path ) )
            {
                return false;
            }
            else
            {
                List<string> listOfDirectoriesName = DividePathForModules ( path );
                if ( !CheckSpaceAfterColon ( listOfDirectoriesName ) ||
                    !CheckDirectorieNamesForPointOnTheEnd ( listOfDirectoriesName ) ||
                    !CheckDirectorieNamesLength ( listOfDirectoriesName ) )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}