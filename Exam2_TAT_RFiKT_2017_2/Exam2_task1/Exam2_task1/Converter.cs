using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_task_01
{
    /// <summary>
    /// Converted type string to type int.
    /// </summary>
    public class Converter
    {
        private const int ASCIICodeOf0 = 48;
        private const int ASCIICodeOf9 = 57;
        private const int ASCIICodeOfComma = 44;
        private const int ASCIICodeOfMinus = 45;
        private const int ASCIICodeOfPoint = 46;

        /// <summary>
        /// Convert string to int. Get exception if it impossible.
        /// </summary>
        /// <param name="convert"></param>
        /// <returns></returns>
        public int ConvertToInt(string convert)
        {
            if (!IsPossibleStringToInt(convert))
            {
                FormatException formatException = new FormatException();
            }

            int result = 0;
            int coeff = 1;
            StringBuilder toIntStringBuilder = new StringBuilder(convert);
            if (toIntStringBuilder[0] == ASCIICodeOfMinus)
            {
                coeff = -1;
                toIntStringBuilder.Remove(0, 1);
            }

            // delete zeros on string start
            for (int i = 0; i < toIntStringBuilder.Length - 1; i++)
            {
                if (toIntStringBuilder[i] == '0' && toIntStringBuilder[i + 1] == '0')
                {
                    toIntStringBuilder.Remove(i, 1);
                    i--;
                }
                else if (toIntStringBuilder[i] == '0' && toIntStringBuilder[i + 1] != '0')
                {
                    toIntStringBuilder.Remove(i, 1);
                    break;
                }
                else
                {
                    break;
                }
            }

            // check position of commas
            if (convert.Contains(ASCIICodeOfComma.ToString()) &&
                convert.Contains(ASCIICodeOfPoint.ToString()) &&
                convert.LastIndexOf(ASCIICodeOfComma.ToString()) > convert.LastIndexOf(ASCIICodeOfPoint.ToString()))
            {
                if (toIntStringBuilder.ToString().LastIndexOf((char)ASCIICodeOfComma) != toIntStringBuilder.ToString().Length - 1)
                {
                    for (int i = toIntStringBuilder.ToString().LastIndexOf((char)ASCIICodeOfComma); i < toIntStringBuilder.ToString().Length; i++)
                    {
                        if (toIntStringBuilder[i] == '0')
                        {
                            toIntStringBuilder.Remove(i, 0);
                            i--;
                        }
                    }
                }
            }

            // check position of commas
            if (convert.Contains(ASCIICodeOfComma.ToString()) &&
                convert.Contains(ASCIICodeOfPoint.ToString()) &&
                convert.LastIndexOf(ASCIICodeOfComma.ToString()) < convert.LastIndexOf(ASCIICodeOfPoint.ToString()))
            {
                if (toIntStringBuilder.ToString().LastIndexOf((char)ASCIICodeOfPoint) != toIntStringBuilder.ToString().Length - 1)
                {
                    for (int i = toIntStringBuilder.ToString().LastIndexOf((char)ASCIICodeOfPoint); i < toIntStringBuilder.ToString().Length; i++)
                    {
                        if (toIntStringBuilder[i] == '0')
                        {
                            toIntStringBuilder.Remove(i, 0);
                            i--;
                        }
                    }
                }
            }

            if (toIntStringBuilder[toIntStringBuilder.Length - 1] == '.' ||
                toIntStringBuilder[toIntStringBuilder.Length - 1] == ',')
            {
                toIntStringBuilder.Remove(toIntStringBuilder.Length - 1, 1);
            }
            if (toIntStringBuilder.ToString().Contains('.') &&
                toIntStringBuilder.ToString().Contains(','))
            {
                throw new FormatException("Int can not contain so mutch points and commas simultaneously.");
            }

            // removing all commas if exist
            if (toIntStringBuilder.ToString().Contains(','))
            {
                for (int i = 0; i <= (toIntStringBuilder.Length - 1) / 3; i++)
                {
                    if (toIntStringBuilder[toIntStringBuilder.Length - 1 - i * 3] == ',')
                    {
                        toIntStringBuilder.Remove(toIntStringBuilder.Length - 1 - i * 3, 1);
                    }
                }
            }

            // removing all points if exist
            if (toIntStringBuilder.ToString().Contains('.'))
            {
                for (int i = 0; i <= (toIntStringBuilder.Length - 1) / 3; i++)
                {
                    if (toIntStringBuilder[toIntStringBuilder.Length - 1 - i * 3] == '.')
                    {
                        toIntStringBuilder.Remove(toIntStringBuilder.Length - 1 - i * 3, 1);
                    }
                }
            }
            if (toIntStringBuilder.ToString().Contains('.') &&
                toIntStringBuilder.ToString().Contains(','))
            {
                throw new FormatException("Int can not contain so mutch points and commas simultaneously.");
            }

            for (int i = toIntStringBuilder.Length - 1; i >= 0; i--)
            {
                result += (toIntStringBuilder[i] - 48) * (int)Math.Pow(10,(toIntStringBuilder.Length - 1 - i));
                Console.WriteLine("toIntStringBuilder[i]={0}.(toIntStringBuilder.Length - 1 - i)={1}.", toIntStringBuilder[i], (int)Math.Pow(10, (toIntStringBuilder.Length - 1 - i)));
            }

            return result * coeff;
        }

        private bool IsPossibleStringToInt(string forChecking)
        {
            bool result = true;

            if (forChecking == String.Empty)
            {
                return false;
            }

            if (forChecking.Contains(ASCIICodeOfMinus.ToString()) && forChecking[0] != ASCIICodeOfMinus)
            {
                return false;
            }

            for (int i = 0; i < forChecking.Length; i++)
            {
                if (forChecking[i] < ASCIICodeOf0 || forChecking[i] > ASCIICodeOf9)
                {
                    if (forChecking[i] != ASCIICodeOfMinus)
                    {
                        return false;
                    }
                }
            }

            // Check for correct position of commas and points.
            if (forChecking.Contains(ASCIICodeOfComma.ToString()) &&
                forChecking.Contains(ASCIICodeOfPoint.ToString()) &&
                forChecking.LastIndexOf(ASCIICodeOfComma.ToString()) > forChecking.LastIndexOf(ASCIICodeOfPoint.ToString()))
            {
                if (forChecking.LastIndexOf((char)ASCIICodeOfComma) != forChecking.Length - 1)
                {
                    for (int i = forChecking.LastIndexOf((char)ASCIICodeOfComma); i < forChecking.Length; i++)
                    {
                        if (forChecking[i] != '0')
                        {
                            return false;
                        }
                    }
                }
            }

            if (forChecking.Contains(ASCIICodeOfComma.ToString()) &&
                forChecking.Contains(ASCIICodeOfPoint.ToString()) &&
                forChecking.LastIndexOf(ASCIICodeOfComma.ToString()) < forChecking.LastIndexOf(ASCIICodeOfPoint.ToString()))
            {
                if (forChecking.LastIndexOf((char)ASCIICodeOfComma) != forChecking.Length - 1)
                {
                    for (int i = forChecking.LastIndexOf((char)ASCIICodeOfComma); i < forChecking.Length; i++)
                    {
                        if (forChecking[i] != '0')
                        {
                            return false;
                        }
                    }
                }
            }

            return result;
        }
    }
}
