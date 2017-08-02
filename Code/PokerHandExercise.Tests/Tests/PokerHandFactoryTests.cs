using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Tests.Classes;
using PokerHandExercise.Classes;
using PokerHandExercise.Classes.HandFactory;
using PokerHandExercise.Classes.Hands;

namespace PokerHandExercise.Tests.Tests
{

    // In line with the conceptual design lets first comment out the original comparer tests, and use InternalsVisibleTo to
    // ensure that the internal abstract factory returns us the correct "specified poker hand". It's a good starting
    // point and sanity check. Once done, one can concentrate on the comparisons.

    // Apply test driven-development by using the UML class diagram design as a basis for the expected class structure.
    // Write the test -> Get it to fail -> Implement the code -> Pass the test -> Refactor -> begin again...

    [TestClass]
    public class PokerHandFactoryTests
    {
        [TestMethod]
        public void Factory_WhenPassed_A_LowHighCard_Combination_Returns_A_HighCard()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowHighCard()) is HighCard);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighHighCard_Combination_Returns_A_HighCard()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighHighCard()) is HighCard);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowPair_Combination_Returns_A_Pair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowPair()) is Pair);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighPair_Combination_Returns_A_Pair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighPair()) is Pair);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowTwoPair_Combination_Returns_A_TwoPair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowTwoPairs()) is TwoPair);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighTwoPair_Combination_Returns_A_TwoPair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighTwoPairs()) is TwoPair);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowThreeOfAKind_Combination_Returns_A_ThreeOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowThreeOfAKind()) is ThreeOfAKind);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighThreeOfAKind_Combination_Returns_A_ThreeOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighThreeOfAKind()) is ThreeOfAKind);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowStraight_Combination_Returns_A_Straight()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowStraight()) is Straight);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighStraight_Combination_Returns_A_Straight()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighStraight()) is Straight);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowFlush_Combination_Returns_A_Flush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFlush()) is Flush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighFlush_Combination_Returns_A_Flush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighFlush()) is Flush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowFullHouse_Combination_Returns_A_FullHouse()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFullHouse()) is FullHouse);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighFullHouse_Combination_Returns_A_FullHouse()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighFullHouse()) is FullHouse);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_LowFourOfAKind_Combination_Returns_A_FourOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFourOfAKind()) is FourOfAKind);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_StraightFlush_Combination_DoesNot_Return_A_FourOfAKind()
        {
            Assert.IsFalse(SpecifiedPokerHand(PokerHandTestHelper.CreateAceLowStraightFlush()) is FourOfAKind);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighStraightFlush_Combination_Returns_A_StraightFlush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighStraightFlush()) is StraightFlush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_MidStraightFlush_Combination_Returns_A_StraightFlush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateMidStraightFlush()) is StraightFlush);
        }

        [TestMethod]
        public void Factory_WhenPassed_A_AceLowStraightFlush_Combination_Returns_A_StraightFlush()
        {
            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(PokerHandTestHelper.CreateAceLowStraightFlush()), typeof(StraightFlush));
        }

        [TestMethod]
        public void Factory_WhenPassed_A_HighThreeOfAKind_Combination_DoesNot_Return_A_StraightFlush()
        {
            Assert.IsFalse(SpecifiedPokerHand(PokerHandTestHelper.CreateHighThreeOfAKind()) is StraightFlush);
        }

        private SpecifiedPokerHand SpecifiedPokerHand(PokerHand pokerHand)
        {
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            return specifiedPokerHand;
        }
    }
}
