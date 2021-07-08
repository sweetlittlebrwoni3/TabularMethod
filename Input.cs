using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public static class Tools
    {
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
                if(temp is null)
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
    }
    public class Input
    {
        public List<int> Minterms { get; set; }
        
        public Input()
        {
            Console.WriteLine("Press enter after typing each minterm.");
            Console.WriteLine("Press enter twice after typing the last minterm.");
            Console.WriteLine("If you were hesitant whether you enter a specific minterm or not,");
            Console.WriteLine("just enter it again! We'll promise to count it once ;)");
            Minterms = Tools.GetManyNum("Please enter the Minterms here:");
            Console.WriteLine("Thanx!");
        }
    }
}
