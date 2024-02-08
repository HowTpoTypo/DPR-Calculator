using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPRCalculator;
using ExtendedNumerics;

namespace DPRCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {

        [TestMethod]
        public void CalculateHitCrit_0AC_0mod_20critrange()
        {
            Die d20 = new Die(20);
            Die d0 = new Die();
            (BigRational,BigRational) actual = Calculator.CalculateHitCritChance(d20, d0, 0, 20);
            (BigRational, BigRational) expected = (new BigRational(18,20), new BigRational(1,20));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_0AC_0mod_3critrange()
        {
            Die d20 = new Die(20);
            Die d0 = new Die();
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(d20, d0, 0, 3);
            (BigRational, BigRational) expected = (new BigRational(1,20), new BigRational(18, 20));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_11AC_0mod_20critrange()
        {
            Die d20 = new Die(20);
            Die d0 = new Die();
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(d20, d0, 11, 20);
            (BigRational, BigRational) expected = (new BigRational(9, 20), new BigRational(1, 20));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_11AC_2mod_20critrange()
        {
            Die d20 = new Die(20);
            Die single2 = new Die([2]);
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(d20, single2, 11, 20);
            (BigRational, BigRational) expected = (new BigRational(11, 20), new BigRational(1, 20));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_11AC_1d4mod_20critrange()
        {
            Die d20 = new Die(20);
            Die d4 = new Die(4);
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(d20, d4, 11, 20);
            (BigRational, BigRational) expected = (new BigRational(23, 40), new BigRational(1, 20));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_11AC_0mod_20critrange_adv()
        {
            Die d20 = new Die(20);
            Die adv = Die.HighestOf(d20, d20);
            Die d0 = new Die();
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(adv, d0, 11, 20);
            (BigRational, BigRational) expected = (new BigRational(261, 400), new BigRational(39, 400));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHitCrit_11AC_0mod_20critrange_eadv()
        {
            Die d20 = new Die(20);
            Die adv = Die.HighestOf(d20, d20);
            Die eadv = Die.HighestOf(adv, d20);
            Die d0 = new Die();
            (BigRational, BigRational) actual = Calculator.CalculateHitCritChance(eadv, d0, 11, 20);
            (BigRational, BigRational) expected = (new BigRational(5859, 8000), new BigRational(1141, 8000));
            Assert.AreEqual(expected, actual);
        }
    }
}
