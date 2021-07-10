using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class Comparison
    {
        //The properties
        public List<string> ChangedMinterms = new List<string>();
        public List<string> LeftMinterms = new List<string>();
        public bool IsNew = false;


        //Minterms must be sorted and duplicates must be removed for this to work
        public Comparison(List<string> minterms)
        {
            for (int i = 0; i < minterms.Count(); i++)
            {
                string first = minterms[i];
                for (int j = i; j < minterms.Count(); j++)
                {
                    string second = minterms[j];
                    if (Tools.DifferenceCounter(first, second) == 1)
                    {
                        IsNew = true;
                        var ch = first.ToCharArray();
                        ch[Tools.DifferenceFinder(first, second)] = 'X';
                        ChangedMinterms.Add(new string(ch));
                    }
                }
            }
            for (int j = 0; j < minterms.Count(); j++)
            {
                foreach (string item in ChangedMinterms)
                {
                    for (int i = 0; i < minterms.Count(); i++)
                    {

                        if (Tools.DifferenceCounter(item, minterms[i]) == 1)
                        {
                            minterms.Remove(minterms[i]);
                        }

                    }
                }
            }
            foreach (string item in minterms)
            {
                LeftMinterms.Add(item);
            }
        }
    }
}
