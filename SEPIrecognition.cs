using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class SEPIrecognition
    {
        public List<string> SEPIs = new List<string>();
        public List<List<string>> CheckList = new List<List<string>>();
        public SEPIrecognition(List<string> LeftMinterms , List<string> LeftPIs)
        {
            //Populating the CheckList with reverse conditions.
            foreach (string PI in LeftPIs)
            {
                var Temp = new List<string>();
                Temp.Add(PI);
                foreach (string minterm in LeftMinterms)
                {
                    if (Tools.CanBeA(minterm , PI))
                    {
                        Temp.Add(minterm);
                    }
                }
                CheckList.Add(Temp);
            }
            //_______________________________________________
            CheckList = CheckList.OrderByDescending(x => Tools.XCounter(x[0])).ToList();

            for(int i = 0; i < CheckList.Count()-1; i++)
            {
                for(int j = i+1; j < CheckList.Count(); j++)
                {
                    if(Tools.ListContains(CheckList[i] , CheckList[j]))
                    {
                        CheckList.Remove(CheckList[j]);
                    }
                }
            }
            foreach(List<string> list in CheckList)
            {
                SEPIs.Add(list[0]);
            }
        }
    }
}
