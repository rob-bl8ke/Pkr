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
    }
}
