using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class Grouping
    {
        public List<List<int>> GroupedMinterms { get; set; }

        public List<int> OnesList(List<int> minterms)
        {
            var result = new List<int>();
            foreach (int item in minterms)
            {
                result.Add(Tools.OneCounter(item));
            }
            result.Sort();
            return result.Distinct().ToList();
        }
        public Grouping(List<int> minterms)
        {
            foreach (int item in OnesList(minterms))
            {
                var temp = new List<int>();
                foreach(int mint in minterms)
                {
                    if(Tools.OneCounter(mint) == item)
                    {
                        temp.Add(mint);
                    }
                }
                GroupedMinterms.Add(temp);
            }
        }
        
    }
}
