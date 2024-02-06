using DPRCalculator;

namespace DPRCalculatorTests
{
    [TestClass]
    public class DieTests
    {
        
        [TestMethod]
        public void CreateDie()
        {
            Die d3 = new Die(3);
            string actual = d3.ToString();
            string expected = "1/3*X^3 + 1/3*X^2 + 1/3*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.AddDice(d3,d3).ToString();
            string expected = "1/9*X^6 + 2/9*X^5 + 1/3*X^4 + 2/9*X^3 + 1/9*X^2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);    
            string actual = Die.AddDice(d3, d4).ToString();
            string expected = "1/12*X^7 + 1/6*X^6 + 1/4*X^5 + 1/4*X^4 + 1/6*X^3 + 1/12*X^2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyDieBy2()
        {
            Die d3 = new Die(3);
            string actual = Die.MultiplyDice(d3, 2).ToString();
            string expected = "1/9*X^6 + 2/9*X^5 + 1/3*X^4 + 2/9*X^3 + 1/9*X^2";
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        public void MultiplyDieBy3()
        {
            Die d3 = new Die(3);
            string actual = Die.MultiplyDice(d3, 3).ToString();
            string expected = "1/27*X^9 + 1/9*X^8 + 2/9*X^7 + 7/27*X^6 + 2/9*X^5 + 1/9*X^4 + 1/27*X^3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HighestOfSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.HighestOf(d3, d3).ToString();
            string expected = "5/9*X^3 + 1/3*X^2 + 1/9*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HighestOfDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            string actual = Die.HighestOf(d3, d4).ToString();
            string expected = "1/4*X^4 + 5/12*X^3 + 1/4*X^2 + 1/12*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LowestOfSameDice()
        {
            Die d3 = new Die(3);
            string actual = Die.LowestOf(d3, d3).ToString();
            string expected = "1/9*X^3 + 1/3*X^2 + 5/9*X";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LowestOfDifferentDice()
        {
            Die d3 = new Die(3);
            Die d4 = new Die(4);
            string actual = Die.LowestOf(d3, d4).ToString();
            string expected = "1/6*X^3 + 1/3*X^2 + 1/2*X";
            Assert.AreEqual(expected, actual);
        }
    }
}