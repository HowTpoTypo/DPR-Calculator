using DPRCalculator;
using ExtendedArithmetic;
using ExtendedNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DPRCalculator
{
    public class Calculator
    {
        public static void Main()
        {
            Die d6 = new Die(6);
            Die adv = Die.HighestOf(new Die(3), new Die(3));
            Console.WriteLine(new Polynomial<BigRational>());

        }
    }
}
