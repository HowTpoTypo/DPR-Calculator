using DPRCalculator;
using System;

namespace DPRCalculatorTests
{
    [TestClass]
    public class DieTests
    {
        
        [TestMethod]
        public void CreateDieFromSideCount()
        {
            Die d3 = new Die(3);
            string actual = d3.ToString();
            string expected = "d3: 1/3*X^3 + 1/3*X^2 + 1/3*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateDieFromSidesList_NoDuplicates()
        {
            int[] sides = {1,2,8,12,60};
            Die die = new Die(sides);
            string actual = die.ToString();
            string expected = "d{1,2,8,12,60}: 1/5*X^60 + 1/5*X^12 + 1/5*X^8 + 1/5*X^2 + 1/5*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateDieFromSidesList_WithDuplicates()
        {
            int[] sides = { 1, 8, 8, 12, 12 };
            Die die = new Die(sides);
            string actual = die.ToString();
            string expected = "d{1,8,8,12,12}: 2/5*X^12 + 2/5*X^8 + 1/5*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.AddDice(d3,d3).ToString();
            string expected = "d3+d3: 1/9*X^6 + 2/9*X^5 + 1/3*X^4 + 2/9*X^3 + 1/9*X^2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);    
            string actual = Die.AddDice(d3, d4).ToString();
            string expected = "d3+d4: 1/12*X^7 + 1/6*X^6 + 1/4*X^5 + 1/4*X^4 + 1/6*X^3 + 1/12*X^2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractDiceFromNumber()
        {
            Die d3 = new Die(3);
            Die single10 = new Die([10]);
            string actual = Die.SubtractDice(single10, d3).ToString();
            string expected = "d{10}-d3: 1/3*X^9 + 1/3*X^8 + 1/3*X^7";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractSameDice()
        {
            Die d3 = new Die(3);
            Die single10 = new Die([10]);
            string actual = Die.SubtractDice(Die.AddDice(d3,single10), d3).ToString();
            string expected = "d3+d{10}-d3: 1/9*X^12 + 2/9*X^11 + 1/3*X^10 + 2/9*X^9 + 1/9*X^8";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            Die single10 = new Die([10]);
            string actual = Die.SubtractDice(Die.AddDice(d3, single10), d4).ToString();
            string expected = "d3+d{10}-d4: 1/12*X^12 + 1/6*X^11 + 1/4*X^10 + 1/4*X^9 + 1/6*X^8 + 1/12*X^7";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyDieBy2()
        {
            Die d3 = new Die(3);
            string actual = Die.MultiplyDie(d3, 2).ToString();
            string expected = "2(d3): 1/9*X^6 + 2/9*X^5 + 1/3*X^4 + 2/9*X^3 + 1/9*X^2";
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        public void MultiplyDieBy3()
        {
            Die d3 = new Die(3);
            string actual = Die.MultiplyDie(d3, 3).ToString();
            string expected = "3(d3): 1/27*X^9 + 1/9*X^8 + 2/9*X^7 + 7/27*X^6 + 2/9*X^5 + 1/9*X^4 + 1/27*X^3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplySameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.MultiplyDice(d3, d3).ToString();
            string expected = "d3*d3: 1/9*X^9 + 2/9*X^6 + 1/9*X^4 + 2/9*X^3 + 2/9*X^2 + 1/9*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            string actual = Die.MultiplyDice(d3, d4).ToString();
            string expected = "d3*d4: 1/12*X^12 + 1/12*X^9 + 1/12*X^8 + 1/6*X^6 + 1/6*X^4 + 1/6*X^3 + 1/6*X^2 + 1/12*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HighestOfSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.HighestOf(d3, d3).ToString();
            string expected = "MaxOf(d3,d3): 5/9*X^3 + 1/3*X^2 + 1/9*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HighestOfDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            string actual = Die.HighestOf(d3, d4).ToString();
            string expected = "MaxOf(d3,d4): 1/4*X^4 + 5/12*X^3 + 1/4*X^2 + 1/12*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LowestOfSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.LowestOf(d3, d3).ToString();
            string expected = "MinOf(d3,d3): 1/9*X^3 + 1/3*X^2 + 5/9*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LowestOfDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            string actual = Die.LowestOf(d3, d4).ToString();
            string expected = "MinOf(d3,d4): 1/6*X^3 + 1/3*X^2 + 1/2*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RerollOnce_UniformDie()
        {
            Die d4 = new Die(4);
            string actual = Die.RerollOnce(d4, 2).ToString();
            string expected = "(d4)ro<2: 3/8*X^4 + 3/8*X^3 + 1/8*X^2 + 1/8*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RerollOnce_NonUniformDie()
        {
            Die d3 = new Die(3);
            Die _2d3 = Die.MultiplyDie(d3, 2);
            string actual = Die.RerollOnce(_2d3, 3).ToString();
            string expected = "(2(d3))ro<3: 4/27*X^6 + 8/27*X^5 + 4/9*X^4 + 2/27*X^3 + 1/27*X^2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DieGreaterOrEqualUniform()
        {
            Die d3 = new Die(3);
            string actual = Die.DieGreaterOrEqual(d3, 2).ToString();
            string expected = "2/3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DieGreaterOrEquaNonlUniform()
        {
            Die die = new Die([1,2,2,2,2,3,4]);
            string actual = Die.DieGreaterOrEqual(die, 3).ToString();
            string expected = "2/7";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DieEqualUniform()
        {
            Die d3 = new Die(3);
            string actual = Die.DieEqual(d3, 2).ToString();
            string expected = "1/3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DieEquaNonlUniform()
        {
            Die die = new Die([1, 2, 2, 2, 2, 3, 4]);
            string actual = Die.DieEqual(die, 3).ToString();
            string expected = "1/7";
            Assert.AreEqual(expected, actual);
        }
    }
}