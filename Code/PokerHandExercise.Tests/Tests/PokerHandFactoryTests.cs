using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Tests.Classes;
using PokerHandExercise.Classes;
using PokerHandExercise.Classes.HandFactory;
using PokerHandExercise.Classes.Hands;

namespace PokerHandExercise.Tests.Tests
{
    [TestClass]
    public class PokerHandFactoryTests
    {
        [TestMethod]
        public void Factory_WhenPassed_A_StraightFlush_Combination_Returns_A_StraightFlush()
        {
            PokerHand pokerHand = PokerHandTestHelper.CreateHighStraightFlush();
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            Assert.IsTrue(specifiedPokerHand is StraightFlush);
        }
    }


}
