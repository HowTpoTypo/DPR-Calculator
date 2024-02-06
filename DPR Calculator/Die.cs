using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedArithmetic;
using ExtendedNumerics;

namespace DPRCalculator
{
    public class Die
    {
        public Polynomial<BigRational> GenFunct { get; set; }

        public Die(int sides) 
        {
            GenFunct = new Polynomial<BigRational>();
            for (int i = 0; i < sides; i++) 
            {
                Term<BigRational>[] term = [new Term<BigRational>(BigRational.Divide(new BigRational(1), new BigRational(sides)), i+1)];
                GenFunct = Polynomial<BigRational>.Add(GenFunct,new Polynomial<BigRational>(term));
            }
        }
        public Die(Polynomial<BigRational> genFunct)
        {
            GenFunct = genFunct;
        }

        public static Die AddDice(Die left, Die right)
        {
            return new Die(Polynomial<BigRational>.Multiply(left.GenFunct, right.GenFunct));
        }
        public static Die MultiplyDice(Die die, int count)
        {
            return new Die(Polynomial<BigRational>.Pow(die.GenFunct, count));
        }
        
        public static Die HighestOf(Die left, Die right)
        {
            Polynomial<BigRational> highestOfDie = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, Math.Max(leftTerms[i].Exponent, rightTerms[j].Exponent))];
                    highestOfDie = Polynomial<BigRational>.Add(highestOfDie, new Polynomial<BigRational>(term));
                }
            }
            return new Die(highestOfDie);
        }
        public static Die LowestOf(Die left, Die right)
        {
            Polynomial<BigRational> highestOfDie = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, Math.Min(leftTerms[i].Exponent, rightTerms[j].Exponent))];
                    highestOfDie = Polynomial<BigRational>.Add(highestOfDie, new Polynomial<BigRational>(term));
                }
            }
            return new Die(highestOfDie);
        }
        public override string ToString()
        {
            return GenFunct.ToString();
        }
    }
}
