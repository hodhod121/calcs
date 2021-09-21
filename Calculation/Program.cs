using Calculation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FirstProject
{
    class Program
    {          
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine(" 0) Exit");
            Console.WriteLine(" 1) Calculate");
           
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    Calc();
                    return true;       
                default:
                    return true;
            }
        }

        private static string Calc()
        {
            Console.Clear();
            bool TryAgain = true;
            while (TryAgain)
            {               
                Calculate calculate = new Calculate();
                int TempInt_1;
                int TempInt_2;
                int NonZero = 0;
                string TempString_2;
                string TempString_3;
                string TempString_4;
                string TempString_5;
                double tempAddition;
                BuildingString buildingString = new BuildingString();
                Console.Write("Enter your expressioon, you can use '+' ,'-', '*', '/', digital numbers, decimal numbers like this 32,5 and paranteces ");
                Console.WriteLine();
                string expression = Console.ReadLine();
                string TempString_6 = "";


                string st = expression.Trim();
                string[] list_2 = st.Split(" ");

                foreach (string str in list_2)
                {
                    TempString_6 += str;
                }
                char[] charArray = TempString_6.ToCharArray();
                foreach(char c in charArray)
                {
                    if(!(c==',' || c==')' || c=='(' || c=='*' || c=='+' || c=='-' || c=='/' || char.IsDigit(c)))
                    {
                        NonZero++;

                    }
                }
                for(int i = 0; i < charArray.Length-1; i++)
                {
                    if(charArray[i] == ',' && !char.IsDigit(charArray[i+1]))
                    {
                        NonZero++;
                    }
                   
                    if (charArray[charArray.Length - 1]==',')
                    {
                        NonZero++;
                    }

                }
                for(int i = 1; i < charArray.Length; i++)
                {
                    if (charArray[i] == '(' && !(charArray[i - 1] == '+' || charArray[i - 1] == '-' || charArray[i - 1] == '/' || charArray[i - 1] == '*'))
                    {
                        NonZero++;
                    }
                }              

                StringBuilder stb = buildingString.Strings(expression);
                Console.WriteLine(stb.ToString());               
                string TempString_1 = stb.ToString();
                while (TempString_1.Contains("("))
                {
                    TempInt_1 = TempString_1.LastIndexOf('(');
                    TempString_2 = TempString_1.Substring(0, TempInt_1);
                    TempString_3 = TempString_1.Substring(TempInt_1 - 1);
                    TempInt_2 = TempString_3.IndexOf(')');
                    if (TempInt_2 != -1)
                    {
                        TempString_4 = TempString_1.Substring(TempInt_1 + 1, TempInt_2 - 2);
                        TempString_5 = TempString_3.Substring(TempInt_2 + 1);
                    }
                    else
                    {
                        TempString_4 = TempString_1.Substring(TempInt_1 + 1);
                        TempString_5 = "";
                    }

                    tempAddition = calculate.Calculation(TempString_4);
                    if(tempAddition == double.MaxValue)
                    {                      
                        NonZero++;                      
                    }

                    TempString_1 = TempString_2 + tempAddition.ToString() + TempString_5;
                }
                double Addition = 0;
                if(NonZero == 0)
                {
                    Addition = calculate.Calculation(TempString_1);
                }
                double results = Addition;
                if (results == double.MaxValue || NonZero>0)
                {
                    Console.WriteLine("It is invalid to divid a number to zero or invalid character is used, please try again");                   
                }
                else
                {
                Console.WriteLine($"Hello, the answer is {results}");
                    TryAgain = false;

                }                
            }
            Console.WriteLine();
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }   
    }
}
