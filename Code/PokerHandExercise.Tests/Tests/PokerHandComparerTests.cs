using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Classes;
using PokerHandExercise.Tests.Classes;

namespace PokerHandExercise.Tests.Tests
{
    [TestClass]
    public class PokerHandComparerTests
    {
        private IPokerHandComparer _comparer;

        [TestInitialize]
        public void Initialise()
        {
            _comparer = new PokerHandComparer();
        }

        [TestMethod]
        public void HighStraightFlushVsLowStraightFlush()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighStraightFlush();
            var pokerHand2 = PokerHandTestHelper.CreateAceLowStraightFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand2 to lose to Hand1");
            result = _comparer.CompareHands(pokerHand2, pokerHand1);
            Assert.AreEqual(-1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void MatchingStraightFlushes()
        {
            var pokerHand1 = PokerHandTestHelper.CreateAceLowStraightFlush();
            var pokerHand2 = PokerHandTestHelper.CreateAceLowStraightFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }


        [TestMethod]
        public void Comparer_WhenComparingHighFourOfAKind_ToLowFourOfAKind_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand2 to lose to Hand1");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowFourOfAKind_ToHighFourOfAKind_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingHighFourOfAKind_ToHighFourOfAKind_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparingHighFullHouse_ToLowFullHouse_EnsuresHigh_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateLowFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowFullHouse_ToHighFullHouse_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingHighFullHouse_ToHighFullHouse_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparingHighFlush_ToLowFlush_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFlush();
            var pokerHand2 = PokerHandTestHelper.CreateLowFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowFlush_ToHighFlush_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowFlush_ToLowFlush_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateLowFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparingHighStraight_ToLowStraight_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighStraight();
            var pokerHand2 = PokerHandTestHelper.CreateLowStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowStraight_ToHighStraight_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateHighStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowStraight_ToLowStraight_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateLowStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }



        [TestMethod]
        public void Comparer_WhenComparingHighThreeOfAKind_ToLowThreeOfAKind_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowThreeOfAKind_ToHighThreeOfAKind_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowThreeOfAKind_ToLowThreeOfAKind_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }
    }
}
