using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBracketsStringValidation
{
    /// <summary>
    /// Can be used for checking maths expression on validation.
    /// </summary>
    public class CheckerForBrackets
    {
        List<char> listOfBrackets;

        /// <summary>
        /// Initialise list of brackets.
        /// </summary>
        public CheckerForBrackets()
        {
            listOfBrackets = new List<char>();
            listOfBrackets.Add('{');
            listOfBrackets.Add('}');
            listOfBrackets.Add('[');
            listOfBrackets.Add(']');
            listOfBrackets.Add('(');
            listOfBrackets.Add(')');
        }

        /// <summary>
        /// Check is string can be like math expression.
        /// </summary>
        /// <param name="source"> String contains math expression. </param>
        /// <returns> Returns true, if string is valid. </returns>
        public bool Check(string source)
        {
            if (source.Length == 0 || (source.Length == 1 && !listOfBrackets.Contains(source[0])))
            {
                return true;
            }

            if (source.Length == 1 && listOfBrackets.Contains(source[0]))
            {
                return false;
            }

            bool result = true;
            List<char> bracketsInSource = new List<char>();

            for (int i = 0; i < source.Length; i++)
            {
                if (listOfBrackets.Contains(source[i]))
                {
                    bracketsInSource.Add(source[i]);
                }
            }

            Console.WriteLine("bracketsInSource");
            bracketsInSource.ForEach(Console.WriteLine);

            bool isWasDeleted = true;
            while (isWasDeleted)
            {
                isWasDeleted = false;
                for (int i = 0; i < bracketsInSource.Count - 1; i++)
                {
                    //Console.WriteLine("bracketsInSource[i+1]={0}!?={1}!", bracketsInSource[i + 1], listOfBrackets[listOfBrackets.IndexOf(bracketsInSource[i]) + 1]);
                    if (listOfBrackets.IndexOf(bracketsInSource[i]) % 2 == 0 &&
                        listOfBrackets.IndexOf(bracketsInSource[i + 1]) % 2 == 1 &&
                        bracketsInSource[i + 1] == listOfBrackets[listOfBrackets.IndexOf(bracketsInSource[i]) + 1])
                    {
                        Console.WriteLine("bracketsInSource[i+1]={0}!?={1}!Equals", bracketsInSource[i + 1], listOfBrackets[listOfBrackets.IndexOf(bracketsInSource[i]) + 1]);
                        bracketsInSource.RemoveAt(i);
                        bracketsInSource.RemoveAt(i);
                        i--;
                        isWasDeleted = true;
                    }
                }
            }

            if (bracketsInSource.Count != 0)
            {
                result = false;
            }

            return result;
        }
    }
}