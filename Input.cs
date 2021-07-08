using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularMethod
{
    public class Input
    {
        public List<int> Minterms { get; set; }
        
        public Input()
        {
            Console.WriteLine("Press enter after typing each minterm.");
            Console.WriteLine("Press enter twice after typing the last minterm.");
            Console.WriteLine("If you were hesitant whether you enter a specific minterm or not,");
            Console.WriteLine("just enter it again! We'll promise to count it once ;)");
            Minterms = Tools.GetManyNum("Please enter the Minterms here:").Distinct().ToList();
            Console.WriteLine("Thanx!");
            Minterms.Sort();
        }
    }
}
