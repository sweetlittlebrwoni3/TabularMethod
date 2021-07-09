using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input();
            List<string> minterms = new List<string>(Tools.Convert2Bin(input.Minterms));
            //Adding zeros at the start of numbers to have the same number of characters for each number
            for(int i = 0; i < minterms.Count(); i++)
            {
                while(minterms[i].Length < minterms[minterms.Count() - 1].Length)
                {
                    minterms[i] = new string(minterms[i].Insert(0, "0").ToCharArray ());
                }
            }
            List<string> finalMinterms = new List<string>();
            while (true)
            {
                var comp = new Comparison(minterms);
                foreach (string item in comp.LeftMinterms)
                {
                    finalMinterms.Add(item);
                }
                minterms.Clear();
                foreach(string item in comp.ChangedMinterms)
                {
                    minterms.Add(item);
                }
                if(comp.IsNew == false)
                {
                    break;
                }
            }
            finalMinterms = finalMinterms.Distinct().ToList();
            foreach (string item in finalMinterms)
            {
                Console.WriteLine(item);
            }
        }
    }
}
