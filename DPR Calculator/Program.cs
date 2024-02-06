
/*
 reqs
 calculate optimal once per turn bonus usage strategy - extra
 handle piecer - extra
 text file input with multiple calculations across lines, text file output
 summary, complete, at least and at most outputs
 weapon comparison by using a base and listing stat changes
 calculate across levels by listing stats per level
 
 design
 based on generating functions
 dice class make generating function based on a dice size
 function to convolve (sum of two dice)
 calculate miss,hit,crit chance and hit,crit damage
 calculate chance for at least one hit for once per round bonus
 read input from text file
 write summary output to text file or complete output to csv
*/
using DPRCalculator;
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
            Console.WriteLine(adv.GenFunct);

        }
    }
}
