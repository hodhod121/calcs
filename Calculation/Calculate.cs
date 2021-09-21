using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class Calculate
    {
        public double Calculation(string v)      
        {
           
                string[] list = v.Split(" ");
                List<string> result = new List<string>();
                List<string> temp = new List<string>();
                List<string> total = new List<string>();

                for (int q = 0; q < list.Count(); q++)
                {
                    result.Add(list[q]);
                }

                while (result.Count != 1)
                {
                    if (Double.TryParse(result[0], out double firstInt) && Double.TryParse(result[2], out double secondInt))
                    {
                        if (result[1] == "*")
                        {
                            temp.Add((firstInt * secondInt).ToString());
                            for (int j = 0; j < 3; j++)
                            {
                                result.RemoveAt(0);
                            }
                            foreach (string item in result)
                            {
                                temp.Add(item);
                            }
                            result.Clear();
                            foreach (string item in temp)
                            {
                                result.Add(item);
                            }
                            temp.Clear();
                        }
                        else if (result[1] == "/")
                        {
                        if (secondInt == 0)
                        {
                            return double.MaxValue;
                        }
                            temp.Add((firstInt / secondInt).ToString());
                            for (int j = 0; j < 3; j++)
                            {
                                result.RemoveAt(0);
                            }
                            foreach (string item in result)
                            {
                                temp.Add(item);
                            }
                            result.Clear();
                            foreach (string item in temp)
                            {
                                result.Add(item);
                            }
                            temp.Clear();

                        }
                        else if (result[1] == "+" || result[1] == "-")
                        {
                            total.Add(result[0]);
                            result.RemoveAt(0);
                            total.Add(result[0]);
                            result.RemoveAt(0);
                        }
                    }
                }
                total.Add(result[0]);
                double Addition = Double.Parse(total[0]);

                for (int p = 1; p < total.Count; p += 2)
                {
                    if (total[p] == "+")
                    {
                        Addition += Double.Parse(total[p + 1]);
                    }
                    else
                    {
                        Addition -= Double.Parse(total[p + 1]);
                    }
                }

                return Addition;
                      
            
        }
    }
}
