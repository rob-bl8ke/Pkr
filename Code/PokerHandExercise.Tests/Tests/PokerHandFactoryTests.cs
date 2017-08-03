using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Tests.Classes;
using PokerHandExercise.Classes;
using PokerHandExercise.Classes.HandFactory;
using PokerHandExercise.Classes.Hands;

namespace PokerHandExercise.Tests.Tests
{

    // In line with the conceptual design, first comment out the original comparer tests, and use InternalsVisibleTo to
    // ensure that the internal abstract factory returns us the correct "specified poker hand". It's a good starting
    // point and sanity check. Once done, one can concentrate on the comparisons.

    // Apply test driven-development by using the UML class diagram design as a basis for the expected class structure.
    // Write the test -> Get it to fail -> Implement the code -> Pass the test -> Refactor -> begin again...

    [TestClass]
    public class PokerHandFactoryTests
    {
        #region High Card Tests

        [TestMethod]
        [TestCategory("High Card")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowHighCard_Combination_Returns_A_HighCard()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowHighCard()) is HighCard);
        }

        [TestMethod]
        [TestCategory("High Card")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighHighCard_Combination_Returns_A_HighCard()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighHighCard()) is HighCard);
        }

        #endregion

        #region Pair Tests

        [TestMethod]
        [TestCategory("Pair")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowPair_Combination_Returns_A_Pair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowPair()) is Pair);
        }

        [TestMethod]
        [TestCategory("Pair")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighPair_Combination_Returns_A_Pair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighPair()) is Pair);
        }

        #endregion

        #region Two Pair Tests

        [TestMethod]
        [TestCategory("Two Pair")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowTwoPair_Combination_Returns_A_TwoPair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowTwoPairs()) is TwoPair);
        }

        [TestMethod]
        [TestCategory("Two Pair")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighTwoPair_Combination_Returns_A_TwoPair()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighTwoPairs()) is TwoPair);
        }

        #endregion

        #region Three of a Kind Tests

        [TestMethod]
        [TestCategory("Three of a Kind")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowThreeOfAKind_Combination_Returns_A_ThreeOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowThreeOfAKind()) is ThreeOfAKind);
        }

        [TestMethod]
        [TestCategory("Three of a Kind")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighThreeOfAKind_Combination_Returns_A_ThreeOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighThreeOfAKind()) is ThreeOfAKind);
        }

        #endregion

        #region Straight Tests

        [TestMethod]
        [TestCategory("Straight")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowStraight_Combination_Returns_A_Straight()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowStraight()) is Straight);
        }

        [TestMethod]
        [TestCategory("Straight")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighStraight_Combination_Returns_A_Straight()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighStraight()) is Straight);
        }

        #endregion

        #region Flush Tests

        [TestMethod]
        [TestCategory("Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowFlush_Combination_Returns_A_Flush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFlush()) is Flush);
        }

        [TestMethod]
        [TestCategory("Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighFlush_Combination_Returns_A_Flush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighFlush()) is Flush);
        }

        #endregion

        #region Full House Tests

        [TestMethod]
        [TestCategory("Full House")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowFullHouse_Combination_Returns_A_FullHouse()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFullHouse()) is FullHouse);
        }

        [TestMethod]
        [TestCategory("Full House")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_FullHouse_Spec_Example_1_Returns_FullHouse()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Three),
                new Card(CardSuit.Heart, CardValue.Three)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(FullHouse));
        }

        [TestMethod]
        [TestCategory("Full House")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_FullHouse_Spec_Example_2_Returns_FullHouse()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(FullHouse));
        }

        [TestMethod]
        [TestCategory("Full House")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighFullHouse_Combination_Returns_A_FullHouse()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighFullHouse()) is FullHouse);
        }

        #endregion

        #region Four of a Kind Tests

        [TestMethod]
        [TestCategory("Four of a Kind")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_LowFourOfAKind_Combination_Returns_A_FourOfAKind()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateLowFourOfAKind()) is FourOfAKind);
        }

        #endregion

        #region Straight Flush Tests

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_StraightFlush_Combination_DoesNot_Return_A_FourOfAKind()
        {
            Assert.IsFalse(SpecifiedPokerHand(PokerHandTestHelper.CreateAceLowStraightFlush()) is FourOfAKind);
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_HighStraightFlush_Combination_Returns_A_StraightFlush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateHighStraightFlush()) is StraightFlush);
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_MidStraightFlush_Combination_Returns_A_StraightFlush()
        {
            Assert.IsTrue(SpecifiedPokerHand(PokerHandTestHelper.CreateMidStraightFlush()) is StraightFlush);
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_A_AceLowStraightFlush_Combination_Returns_A_StraightFlush()
        {
            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(PokerHandTestHelper.CreateAceLowStraightFlush()), typeof(StraightFlush));
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_StraightFlush_Spec_Example_1_Returns_StraightFlush()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Ten),
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Queen),
                new Card(CardSuit.Heart, CardValue.King)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(StraightFlush));
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_StraightFlush_Spec_Example_2_Returns_StraightFlush()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Three),
                new Card(CardSuit.Diamond, CardValue.Four),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Six),
                new Card(CardSuit.Diamond, CardValue.Seven)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(StraightFlush));
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_StraightFlush_Spec_Example_3_Returns_StraightFlush()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
                new Card(CardSuit.Club, CardValue.Four),
                new Card(CardSuit.Club, CardValue.Five)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(StraightFlush));
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        [TestCategory("PokerHandFactory Tests")]
        public void Factory_WhenPassed_StraightFlush_Spec_Example_4_Returns_StraightFlush()
        {
            var pokerHand = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Spade, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Jack),
                new Card(CardSuit.Spade, CardValue.Queen),
                new Card(CardSuit.Spade, CardValue.King),
                new Card(CardSuit.Spade, CardValue.Ace)
                );

            // could use this assertion, but i prefer the "IsTrue" which I feel is more readable.
            Assert.IsInstanceOfType(SpecifiedPokerHand(pokerHand), typeof(StraightFlush));
        }

        #endregion

        private SpecifiedPokerHand SpecifiedPokerHand(PokerHand pokerHand)
        {
            PokerHandFactory pokerHandFactory = new PokerHandFactory();
            SpecifiedPokerHand specifiedPokerHand = pokerHandFactory.Create(pokerHand);

            return specifiedPokerHand;
        }
    }
}
