using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class EPIrecongition
    {
        public List<string> EPIs = new List<string>();
        public List<List<string>> CheckList = new List<List<string>>();
        public EPIrecongition(List<string> minterms , List<string> PIs)
        {
            //Populating the CheckList
            foreach (string minterm in minterms)
            {
                var Temp = new List<string>();
                Temp.Add(minterm);
                foreach (string PI in PIs)
                {
                    if (Tools.CanBeA(minterm, PI))
                    {
                        Temp.Add(PI);
                    }
                }
                CheckList.Add(Temp);
            }
            //________________________
            int length = PIs.Count();
            for (int i = 0; i < length; i++)
            {
                var del = new List<List<string>>();
                foreach (List<string> list in CheckList)
                {
                    
                    if (list.Count() == 2)
                    {
                        EPIs.Add(list[1]);
                        
                        foreach (List<string> theList in CheckList)
                        {
                            if (Tools.CanBeA(theList[0], list[1]))
                            {
                                del.Add(theList);
                            }
                        }
                        
                    }
                }
                foreach (List<string> item in del)
                {
                    CheckList.Remove(item);
                }
            }
            EPIs = EPIs.Distinct().ToList();
        }
    }
}
