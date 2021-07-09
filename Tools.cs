using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public static class Tools
    {
        //Tools for input
        //The user can press enter twice to finish entering data
        //That's the reason using nullable int.
        public static int? GetNum()
        {
            string input;
            int? item;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        return null;
                    }
                    item = int.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }
            return item;
        }
        public static int? GetNum(string massage)
        {
            Console.WriteLine(massage);
            return GetNum();
        }
        public static List<int> GetManyNum()
        {
            var theList = new List<int>();
            while (true)
            {
                int? temp = GetNum();
                if (temp is null)
                {
                    break;
                }
                else
                {
                    theList.Add(temp ?? 0);
                }
            }
            return theList;
        }
        public static List<int> GetManyNum(string massage)
        {
            Console.WriteLine(massage);
            return GetManyNum();
        }
        //___________________________________________________________________________________
        public static int OneCounter(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 2;
                num /= 2;
            }
            return sum;
        }
        public static int VariableCounter(List<int> minterms)
        {
            return Convert.ToString(minterms.Max(), 2).Length;
        }
        //___________________________________________________________________________________

        public static bool PowerOf2Detector(int input)
        {
            while(input > 1)
            {
                if(input % 2 == 1)
                {
                    return false;
                }
                input /= 2;
            }
            return true;
        }
        public static List<string> Convert2Bin(List<int> minterms)
        {
            var result = new List<string>();
            foreach(int item in minterms)
            {
                result.Add(Convert.ToString(item, 2));
            }
            return result;
        }
        public static int DifferenceCounter(string first , string second)
        {
            int dif = 0;
            for(int i = 0; i < second.Length; i++)
            {
                if(first[i] != second[i])
                {
                    dif++;
                }
            }
            return dif;
        }
        public static int DifferenceFinder(string first , string second)
        {
            for(int i =0; i<second.Length; i++)
            {
                if(first[i] != second[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool CanBeA(string minterm , string PI)
        {
            char[] ch = minterm.ToCharArray();
            for (int i = 0; i < PI.Length; i++)
            {
                if(PI[i] == '_')
                {
                    ch[i] = '_';
                }
            }
            if(new string(ch) == PI)
            {
                return true;
            }
            else { return false; }
        }
    }
}
