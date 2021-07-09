﻿using System;
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
                foreach(string item in comp.ChangedMinterms)
                {
                    minterms.Add(item);
                }
                if(comp.IsNew == false)
                {
                    break;
                }
            }
            PIs = PIs.Distinct().ToList();
            var EPIRecognizer = new EPIrecongition(mintermsCopy , PIs);
            foreach(string item in EPIRecognizer.EPIs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("........................................");
            foreach (string item in PIs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
