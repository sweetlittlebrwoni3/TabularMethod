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
            for (int i = 0; i < minterms.Count(); i++)
            {
                while (minterms[i].Length < minterms[minterms.Count() - 1].Length)
                {
                    minterms[i] = new string(minterms[i].Insert(0, "0").ToCharArray());
                }
            }
            List<string> mintermsCopy = new List<string>(minterms);
            List<string> PIs = new List<string>();
            while (true)
            {
                var comp = new Comparison(minterms);
                foreach (string item in comp.LeftMinterms)
                {
                    PIs.Add(item);
                }
                minterms.Clear();
                foreach (string item in comp.ChangedMinterms)
                {
                    minterms.Add(item);
                }
                if (comp.IsNew == false)
                {
                    break;
                }
            }
            PIs = PIs.Distinct().ToList();
            bool IsFinished = false;
            var Final = new List<string>();
            while (IsFinished == false)
            {
                var EPIRecognizer = new EPIrecongition(mintermsCopy, PIs);
                var EPIlist = new List<string>(EPIRecognizer.EPIs);


                //Going for the SEPIs
                var LeftMinterms = new List<string>();
                var LeftPIs = new List<string>();
                foreach (List<string> list in EPIRecognizer.CheckList)
                {
                    LeftMinterms.Add(list[0]);
                }
                foreach (string item in PIs)
                {
                    if (!EPIlist.Contains(item))
                    {
                        LeftPIs.Add(item);
                    }
                }
                var Sepi = new SEPIrecognition(LeftMinterms, LeftPIs);
                foreach (string item in EPIlist)
                {
                    Final.Add(item);
                }

                //Repopulating the enteries.
                mintermsCopy.Clear();
                foreach (string item in LeftMinterms)
                {
                    mintermsCopy.Add(item);
                }
                PIs.Clear();
                foreach (string item in Sepi.SEPIs)
                {
                    PIs.Add(item);
                }
                Final = Final.Distinct().ToList();
                if (LeftMinterms.Count() == 0)
                {
                    IsFinished = true;
                }
                else
                {
                    IsFinished = false;
                }
            }
            var Out = new Output(Final);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Minterms are :");
            Console.WriteLine(Out.result);
            Console.WriteLine();
            Console.WriteLine("And their binary form is:");
            foreach(string item in Final)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
