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

        [TestMethod]
        public void Comparer_WhenComparingHighTwoPair_ToLowTwoPair_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateLowTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingLowTwoPair_ToHighTwoPair_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateHighTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowTwoPair_ToLowTwoPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateLowTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparing_MidTwoPair_ToMidTwoPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateMidTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateMidTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparing_TwoPairWithHighFifth_ToTwoPairWithLowFifth_EnsuresHigh_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateSameTwoPairsDifferentFifthCard(CardValue.Ace);
            var pokerHand2 = PokerHandTestHelper.CreateSameTwoPairsDifferentFifthCard(CardValue.Eight);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_HighPair_ToLowPair_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighPair();
            var pokerHand2 = PokerHandTestHelper.CreateLowPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowPair_ToHighPair_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateHighPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_LowPair_ToLowPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateLowPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        public void Comparer_WhenComparing_SamePairHigh3rdCard_ToSamePairLow3rdCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.Ace, CardValue.Jack, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_SamePairHigh4thCard_ToSamePairLow4thCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_SamePairHigh5thCard_ToSamePairLow5thCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.King, CardValue.Queen, CardValue.Jack);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentThirdCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_1stHigh_HighCard_ToLowerHighCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighHighCard();
            var pokerHand2 = PokerHandTestHelper.CreateLowHighCard();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_StraightFlush_To_FourOfAKind_StraightFlush_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateAceLowStraightFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        #region Weighting (Tests on Hand Precedence)

        [TestMethod]
        public void Comparer_WhenComparing_FourOfAKind_To_FullHouse_FourOfAKind_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_FullHouse_To_Flush_FullHouse_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_Flush_To_Straight_Flush_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_Straight_To_ThreeOfAKind_Straight_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateHighThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_ThreeOfAKind_To_TwoPair_ThreeOfAKind_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_TwoPair_To_Pair_TwoPair_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateHighPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparing_Pair_To_HighCard_Pair_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateHighHighCard();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        #endregion

        //private PokerHand GetAceHighTwoPair()
        //{
        //    return new PokerHand()
        //    {
        //        new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
        //        new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
        //        new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
        //        new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
        //        new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
        //    };
        //}

        [TestMethod]
        public void Comparer_WhenComparingSecondKingTwoPair_ToSecondJackTwoPair_KingTwoPair_Wins()
        {
            var pokerHand1 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.King },
                new Card { Suit = CardSuit.Heart, Value = CardValue.King },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var pokerHand2 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingAceTwoPair_ToKingTwoPair_AceTwoPair_Wins()
        {
            var pokerHand1 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var pokerHand2 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.King },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.King },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        public void Comparer_WhenComparingKingTwoPair_ToAceTwoPair_Ensure_KingTwoPair_Loses()
        {
            var pokerHand1 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.King },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.King },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var pokerHand2 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten }
            };

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }
    }
}
