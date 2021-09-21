using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class BuildingString
    {
        public StringBuilder Strings(string s)
        {
            string Temp = "";


            string sd = s.Trim();
            string[] list_1 = sd.Split(" ");

            foreach (string str in list_1)
            {
                Temp += str;
            }           
            StringBuilder sb = new StringBuilder(Temp);
            int sbLength = sb.Length;

            for (int i = 0; i < sbLength; i++)
            {

                if ((sb[i].ToString() == "*" || sb[i].ToString() == "/" || sb[i].ToString() == "+" || sb[i].ToString() == "-") && sb[i - 1].ToString() != " ")
                {
                    sb.Insert(i, " ");
                    sbLength++;
                }
                if ((sb[i].ToString() == "*" || sb[i].ToString() == "/" || sb[i].ToString() == "+" || sb[i].ToString() == "-") && sb[i + 1].ToString() != " ")
                {
                    sb.Insert(i + 1, " ");
                    sbLength++;
                }
            }
            return sb;
        }
    }
}
