using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace _04_Change_Calculator
{
    class JeffToolBox
    {
        public static decimal StringtoDecimal(string myString)
        {


            decimal myDecimal = Convert.ToDecimal(myString);

            return myDecimal;
        }

        public static string DecimalToDollar(decimal myDecimal)
        {
            string myString = myDecimal.ToString();

            myString = "$" + myString;
            return myString;

        }

        public static string RectangleMath(decimal width, decimal length, decimal cost)
        {
            decimal Totalcost = width * length;
            Totalcost = Totalcost * cost;
            string finalCost = DecimalToDollar(Totalcost);
            return finalCost;
        }

        public static string RectangleSqFt(decimal width, decimal length)
        {
            decimal sqft = width * length;
            string totalSqFt = sqft.ToString();

            return totalSqFt;
        }

        public static string testIntergersOnly(string myString)
        {
            while (true)
            {
                try
                {


                }

                catch
                {


                }


            }

        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static string RemoveLetters(string myString)
        {
            string newString = Regex.Replace(myString, "[A-Za-z ]", "");

            return newString;
        }
        public static bool hasLetters(string myString)
        {
            foreach (var i in myString)
            {
                if ((i < '0' || i > '9'))
                {
                    return false;

                }
            }

            return true;


        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static void WriteToConsole<T>(IList<T> collection)
        {
            WriteToConsole<T>(collection, "\t");
        }

        public static void WriteToConsole<T>(IList<T> collection, string delimiter)
        {
            int count = collection.Count();
            for (int i = 0; i < count; ++i)
            {
                Console.Write("{0}{1}", collection[i].ToString(), delimiter);
            }
            Console.WriteLine();
        }
        public static string ListToString(List<string> collection)
        {
            string myString = string.Join(",", collection.ToArray());

            return myString;
        }
        public static decimal ReadDecimal(string message, bool positiveNumber = false, bool acceptZero = true)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);

                    string input = Console.ReadLine();

                    decimal returnValue = decimal.Parse(input);

                    if (positiveNumber == true && returnValue < 0)
                    {
                        Console.WriteLine("Please enter a positive number");

                        continue;
                    }
                    if (acceptZero == false && returnValue == 0)
                    {
                        Console.WriteLine("Please enter a number other than 0");

                        continue;
                    }

                    return returnValue;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Please enter a value");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a numerical value");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Please enter a reasonably sized number");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error reading this decimal");
                }
            }
        }

        public static decimal ReadCurrency(string message, bool positiveNumber = false, bool acceptZero = true)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    Console.Write("$");

                    string input = Console.ReadLine();


                    decimal returnValue = decimal.Parse(input);

                    if (positiveNumber == true && returnValue < 0)
                    {
                        Console.WriteLine("---------------- \n \n");
                        Console.WriteLine("Please enter a positive number");

                        continue;
                    }
                    if (acceptZero == false && returnValue == 0)
                    {
                        Console.WriteLine("Please enter a number other than 0");

                        continue;
                    }
                    if ((returnValue * 2 > Decimal.MaxValue) || (returnValue * 3 > Decimal.MaxValue))
                    {
                        Console.WriteLine("---------------- \n \n");
                        Console.WriteLine("Please enter a smaller number, dont be a hacker...");
                        continue;
                    }


                    return returnValue;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Please enter a value");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a numerical value");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Please enter a reasonably sized number");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error reading this decimal");
                }
            }
        }


    }//End class




} // End NameSpace

