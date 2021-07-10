using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class Output
    {
        public string result;
        public Output(List<string> BinEPIs)
        {
            string temp = "";
            foreach(string item in BinEPIs)
            {
                for(int i = 0;i< item.Length; i++)
                {
                    if(item[i] == '1')
                    {
                        temp += ((char)(i+65)).ToString() ;
                    }
                    if (item[i] == '0')
                    {
                        temp += ((char)(i+65)).ToString() +"'";
                    }
                }
                if (item != BinEPIs[BinEPIs.Count() - 1])
                {
                    temp += " + ";
                }
            }
            result = temp;
        }
    }
}
