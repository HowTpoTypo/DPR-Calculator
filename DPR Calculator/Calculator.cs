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
        public static void Main() { }
        public static (BigRational,BigRational) CalculateHitCritChance(Die hit, Die mods, int ac, int critrange)
        {
            BigRational critchance = Die.DieGreaterOrEqual(hit, critrange);
            BigRational hitchance = Die.DieGreaterOrEqual(Die.AddDice(hit, mods), ac) - critchance;
            int maxMods = mods.GenFunct.Degree;
            if (maxMods +1 >= ac)
            {
                BigRational nat1chance = Die.DieEqual(hit, 1);
                hitchance -= nat1chance;
            }
            return (hitchance,critchance);
        }
    }
}
