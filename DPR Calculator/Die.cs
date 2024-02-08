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
        public Polynomial<BigRational> GenFunct { get; }
        public string Name { get; }

        public Die()
        {
            GenFunct = new Polynomial<BigRational>([new Term<BigRational>(1,0)]);
            Name = "d0";
        }
        public Die(int sides) 
        {
            GenFunct = new Polynomial<BigRational>();
            for (int i = 0; i < sides; i++) 
            {
                Term<BigRational>[] term = [new Term<BigRational>(BigRational.Divide(1, new BigRational(sides)), i+1)];
                GenFunct = Polynomial<BigRational>.Add(GenFunct,new Polynomial<BigRational>(term));
            }
            Name = $"d{sides}";
        }
        public Die(int[] sides)
        {
            GenFunct = new Polynomial<BigRational>();
            for (int i = 0; i < sides.Length; i++)
            {
                Term<BigRational>[] term = [new Term<BigRational>(BigRational.Divide(1, new BigRational(sides.Length)), sides[i])];
                GenFunct = Polynomial<BigRational>.Add(GenFunct, new Polynomial<BigRational>(term));
            }
            Name = "d{";
            for (int i = 0;i < sides.Length;i++)
            {
                Name += sides[i];
                if (!(i==sides.Length-1)) 
                {
                    Name += ",";
                }
            }
            Name += "}";
        }

        public Die(Polynomial<BigRational> genFunct, string name)
        {
            GenFunct = genFunct;
            Name = name;
        }

        public static Die WeightDie(Die die, BigRational weight)
        {
            return new Die(Polynomial<BigRational>.Multiply(die.GenFunct, new Polynomial<BigRational>([new Term<BigRational>(weight,0)])), die.Name);
        }

        public static Die AddDice(Die left, Die right)
        {
            return new Die(Polynomial<BigRational>.Multiply(left.GenFunct, right.GenFunct), $"{left.Name}+{right.Name}");
        }
        public static Die MultiplyDie(Die die, int count)
        {
            return new Die(Polynomial<BigRational>.Pow(die.GenFunct, count), $"{count}({die.Name})");
        }

        //Fails if any result is negative
        public static Die SubtractDice(Die left, Die right)
        {
            Polynomial<BigRational> poly = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, leftTerms[i].Exponent - rightTerms[j].Exponent)];
                    poly = Polynomial<BigRational>.Add(poly, new Polynomial<BigRational>(term));
                }
            }
            return new Die(poly, $"{left.Name}-{right.Name}");
        }
        public static Die MultiplyDice(Die left, Die right)
        {
            Polynomial<BigRational> poly = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, leftTerms[i].Exponent * rightTerms[j].Exponent)];
                    poly = Polynomial<BigRational>.Add(poly, new Polynomial<BigRational>(term));
                }
            }
            return new Die(poly, $"{left.Name}*{right.Name}");
        }

        public static Die HighestOf(Die left, Die right)
        {
            Polynomial<BigRational> poly = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, Math.Max(leftTerms[i].Exponent, rightTerms[j].Exponent))];
                    poly = Polynomial<BigRational>.Add(poly, new Polynomial<BigRational>(term));
                }
            }
            return new Die(poly, $"MaxOf({left.Name},{right.Name})");
        }
        public static Die LowestOf(Die left, Die right)
        {
            Polynomial<BigRational> poly = new Polynomial<BigRational>();
            Term<BigRational>[] leftTerms = left.GenFunct.Terms;
            Term<BigRational>[] rightTerms = right.GenFunct.Terms;
            for (int i = 0; i < leftTerms.Length; i++)
            {
                for (int j = 0; j < rightTerms.Length; j++)
                {
                    Term<BigRational>[] term = [new Term<BigRational>(leftTerms[i].CoEfficient * rightTerms[j].CoEfficient, Math.Min(leftTerms[i].Exponent, rightTerms[j].Exponent))];
                    poly = Polynomial<BigRational>.Add(poly, new Polynomial<BigRational>(term));
                }
            }
            return new Die(poly, $"MinOf({left.Name},{right.Name})");
        }
        public static Die RerollOnce(Die die, int lessthan)
        {
            Polynomial<BigRational> poly = new Polynomial<BigRational>();
            Term<BigRational>[] terms = die.GenFunct.Terms;
            for (int i = 0; i < terms.Length; i++)
            {
                for (int j = 0; j < terms.Length; j++)
                {
                    Term<BigRational>[] term;
                    if (terms[i].Exponent <= lessthan)
                    {
                        term = [new Term<BigRational>(terms[i].CoEfficient * terms[j].CoEfficient, terms[j].Exponent)];
                    } 
                    else
                    {
                        term = [new Term<BigRational>(terms[i].CoEfficient * terms[j].CoEfficient, terms[i].Exponent)];
                    }
                    poly = Polynomial<BigRational>.Add(poly, new Polynomial<BigRational>(term));
                }
            }
            return new Die(poly, $"({die.Name})ro<{lessthan}");
        }
        public static BigRational DieEqual(Die die, int number)
        {
            BigRational chance = new(0);
            foreach (var term in die.GenFunct.Terms)
            {
                if (term.Exponent == number)
                {
                    chance += term.CoEfficient;
                }
            }            
            return chance;
        }
        public static BigRational DieGreaterOrEqual(Die die, int number)
        {
            BigRational chance = new(0);
            foreach (var term in die.GenFunct.Terms)
            {
                if (term.Exponent >= number)
                {
                    chance += term.CoEfficient;
                }
            }
            return chance;
        }
        public BigRational Expected()
        {
            return Polynomial<BigRational>.GetDerivativePolynomial(GenFunct).Evaluate(1);
        }
        public override string ToString()
        {
            return $"{Name}: {GenFunct}";
        }
    }
}
