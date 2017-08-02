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
        public void Factory_WhenPassed_A_HighStraightFlush_Combination_Returns_A_StraightFlush()
        {
            PokerHand pokerHand = PokerHandTestHelper.CreateHighStraightFlush();
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            Assert.IsTrue(specifiedPokerHand is StraightFlush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_MidStraightFlush_Combination_Returns_A_StraightFlush()
        {
            PokerHand pokerHand = PokerHandTestHelper.CreateMidStraightFlush();
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            Assert.IsTrue(specifiedPokerHand is StraightFlush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_AceLowStraightFlush_Combination_Returns_A_StraightFlush()
        {
            PokerHand pokerHand = PokerHandTestHelper.CreateAceLowStraightFlush();
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            Assert.IsTrue(specifiedPokerHand is StraightFlush);
        }

        [TestMethod]
        public void Factory_WhenNotPassed_A_HighThreeOfAKind_Combination_DoesNot_Return_A_StraightFlush()
        {
            PokerHand pokerHand = PokerHandTestHelper.CreateHighThreeOfAKind();
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            Assert.IsFalse(specifiedPokerHand is StraightFlush);
        }
    }
}
