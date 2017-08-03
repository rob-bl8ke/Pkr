using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Classes;
using PokerHandExercise.Classes.Exceptions;
using PokerHandExercise.Tests.Classes;

namespace PokerHandExercise.Tests.Tests
{
    // Apply test driven-development by using the UML class diagram design as a basis for the expected class structure.
    // Write the test -> Get it to fail -> Implement the code -> Pass the test -> Refactor -> begin again...

    [TestClass]
    public class PokerHandComparerTests
    {
        private IPokerHandComparer _comparer;

        [TestInitialize]
        public void Initialise()
        {
            _comparer = new PokerHandComparer();
        }

        #region General

        [TestMethod]
        [TestCategory("General")]
        [ExpectedException(typeof(IllegalNoOfCardsInHandException))]
        public void Comparer_PokerHands_NotHaving_FiveCards_ThrowsException()
        {
            var pokerHand1 = new PokerHand() { new Card(CardSuit.Club, CardValue.Nine) };
            var pokerHand2 = new PokerHand() { new Card(CardSuit.Spade, CardValue.Queen) };

            _comparer.CompareHands(pokerHand1, pokerHand2);
        }

        #endregion

        #region High Straight Flush Tests

        [TestMethod]
        [TestCategory("Straight Flush")]
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
        [TestCategory("Straight Flush")]
        public void MatchingStraightFlushes()
        {
            var pokerHand1 = PokerHandTestHelper.CreateAceLowStraightFlush();
            var pokerHand2 = PokerHandTestHelper.CreateAceLowStraightFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        public void Comparer_LowerStraightFlush_Loses_To_HigherStraightFlush()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Diamond, CardValue.Six),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Four)
                );

            var pokerHand2 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Heart, CardValue.Five),
                new Card(CardSuit.Heart, CardValue.Six),
                new Card(CardSuit.Heart, CardValue.Seven),
                new Card(CardSuit.Heart, CardValue.Eight),
                new Card(CardSuit.Heart, CardValue.Nine)
                );

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        public void Comparer_HigherStraightFlush_Beats_LowerStraightFlush_Spec_Example_1()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Diamond, CardValue.Queen)
                );

            var pokerHand2 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Six),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Ten)
                );

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand2 to lose to Hand1");
        }

        #endregion

        #region Four of a Kind Tests

        [TestMethod]
        [TestCategory("Four of a Kind")]
        public void Comparer_WhenComparingHighFourOfAKind_ToLowFourOfAKind_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand2 to lose to Hand1");
        }

        [TestMethod]
        [TestCategory("Four of a Kind")]
        public void Comparer_WhenComparingLowFourOfAKind_ToHighFourOfAKind_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Four of a Kind")]
        public void Comparer_WhenComparingHighFourOfAKind_ToHighFourOfAKind_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        #endregion

        #region Full House Tests

        [TestMethod]
        [TestCategory("Full House")]
        public void Comparer_WhenComparingHighFullHouse_ToLowFullHouse_EnsuresHigh_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateLowFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Full House")]
        public void Comparer_WhenComparingLowFullHouse_ToHighFullHouse_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Full House")]
        public void Comparer_WhenComparingHighFullHouse_ToHighFullHouse_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Straight Flush")]
        public void Comparer_HigherFullHouse_Beats_LowerFullHouse_Spec_Example_1()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Queen),
                new Card(CardSuit.Diamond, CardValue.Queen)
                );

            var pokerHand2 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Four),
                new Card(CardSuit.Diamond, CardValue.Four),
                new Card(CardSuit.Diamond, CardValue.Four)
                );

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand2 to lose to Hand1");
        }

        #endregion

        #region Flush Tests

        [TestMethod]
        [TestCategory("Flush")]
        public void Comparer_WhenComparingHighFlush_ToLowFlush_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighFlush();
            var pokerHand2 = PokerHandTestHelper.CreateLowFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void Comparer_WhenComparingLowFlush_ToHighFlush_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void Comparer_WhenComparing_LowFlush_ToLowFlush_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateLowFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        #endregion

        #region Straight Tests

        [TestMethod]
        [TestCategory("Straight")]
        public void Comparer_WhenComparingHighStraight_ToLowStraight_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighStraight();
            var pokerHand2 = PokerHandTestHelper.CreateLowStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Straight")]
        public void Comparer_WhenComparingLowStraight_ToHighStraight_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateHighStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Straight")]
        public void Comparer_WhenComparing_LowStraight_ToLowStraight_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateLowStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Straight")]
        public void Comparer_WhenComparing_2ndHighest_High_CardStraight_To_2ndHighest_Low_CardStraight_Ensure_High_Wins()
        {
            var pokerHand1 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.King },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Club, Value = CardValue.Nine }
            };

            var pokerHand2 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.King },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Nine },
                new Card { Suit = CardSuit.Club, Value = CardValue.Eight }
            };

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Straight")]
        public void Comparer_WhenComparing_OneCardAceStraight_To_HigherStraight_Ensure_OneCardAceStraight_Loses()
        {
            // This is a test build specifically on the first paragraph in "Appendix: Poker hands and their precedence".
            var pokerHand1 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Two },
                new Card { Suit = CardSuit.Club, Value = CardValue.Three },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Four },
                new Card { Suit = CardSuit.Club, Value = CardValue.Five }
            };

            var pokerHand2 = new PokerHand()
            {
                new Card { Suit = CardSuit.Club, Value = CardValue.Nine },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Club, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Club, Value = CardValue.King }
            };

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        #endregion

        #region Three Of A Kind Tests

        [TestMethod]
        [TestCategory("Three of a Kind")]
        public void Comparer_WhenComparingHighThreeOfAKind_ToLowThreeOfAKind_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Three of a Kind")]
        public void Comparer_WhenComparingLowThreeOfAKind_ToHighThreeOfAKind_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Three of a Kind")]
        public void Comparer_WhenComparing_LowThreeOfAKind_ToLowThreeOfAKind_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateLowThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        #endregion

        #region Two Pair Tests

        [TestMethod]
        [TestCategory("Two Pair")]
        public void Comparer_WhenComparingHighTwoPair_ToLowTwoPair_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateLowTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Two Pair")]
        public void Comparer_WhenComparingLowTwoPair_ToHighTwoPair_EnsuresLow_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateHighTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Two Pair")]
        public void Comparer_WhenComparing_LowTwoPair_ToLowTwoPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateLowTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Two Pair")]
        public void Comparer_WhenComparing_MidTwoPair_ToMidTwoPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateMidTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateMidTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Two Pair")]
        public void Comparer_WhenComparing_TwoPairWithHighFifth_ToTwoPairWithLowFifth_EnsuresHigh_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateSameTwoPairsDifferentFifthCard(CardValue.Ace);
            var pokerHand2 = PokerHandTestHelper.CreateSameTwoPairsDifferentFifthCard(CardValue.Eight);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Two Pair")]
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
        [TestCategory("Two Pair")]
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
        [TestCategory("Two Pair")]
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

        #endregion

        #region Pair Tests

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_HighPair_ToLowPair_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighPair();
            var pokerHand2 = PokerHandTestHelper.CreateLowPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_LowPair_ToHighPair_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateHighPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_LowPair_ToLowPair_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateLowPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairHigh1stCard_ToSamePairLow1stCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.Ace, CardValue.Jack, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairHigh2ndCard_ToSamePairLow2ndCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairHigh3rdCard_ToSamePairLow3rdCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Nine);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairLow1stCard_ToSamePairHigh1stCard_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.Ace, CardValue.Jack, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairLow2ndCard_ToSamePairHigh2ndCard_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Jack, CardValue.Ten);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);


            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("Pair")]
        public void Comparer_WhenComparing_SamePairLow3rdCard_ToSamePairHigh3rdCard_Ensures_Low_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Nine);
            var pokerHand2 = PokerHandTestHelper.CreatePairDifferentNonPairCardValue(CardValue.King, CardValue.Queen, CardValue.Ten);

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        #endregion

        #region High Card

        [TestMethod]
        [TestCategory("High Card")]
        public void Comparer_WhenComparing_1stHigh_HighCard_ToLowerHighCard_Ensures_High_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighHighCard();
            var pokerHand2 = PokerHandTestHelper.CreateLowHighCard();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("High Card")]
        public void Comparer_WhenComparing_1stLow_HighCard_ToHigherHighCard_Ensures_Lower_Loses()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowHighCard();
            var pokerHand2 = PokerHandTestHelper.CreateHighHighCard();


            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(-1, result, "Expected Hand1 to lose to Hand2");
        }

        [TestMethod]
        [TestCategory("High Card")]
        public void Comparer_WhenComparing_MatchingHighCard_ToMatchHighCard_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHighHighCard();
            var pokerHand2 = PokerHandTestHelper.CreateHighHighCard();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        [TestMethod]
        [TestCategory("High Card")]
        public void Comparer_WhenComparing_MatchingHighCard_ToMatchHighCard_DifferentOrder_Ensures_A_Tie()
        {
            var pokerHand1 = PokerHandTestHelper.CreateHand(
                
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.King)
                );

            var pokerHand2 = PokerHandTestHelper.CreateHand(
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Nine)
                );

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(0, result, "Expected Hand1 and Hand2 be equivalent");
        }

        #endregion

        #region Weighting (Tests on Hand-vs-Hand Precedence)

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_StraightFlush_To_FourOfAKind_StraightFlush_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateAceLowStraightFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighFourOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_FourOfAKind_To_FullHouse_FourOfAKind_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFourOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighFullHouse();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_FullHouse_To_Flush_FullHouse_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFullHouse();
            var pokerHand2 = PokerHandTestHelper.CreateHighFlush();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_Flush_To_Straight_Flush_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowFlush();
            var pokerHand2 = PokerHandTestHelper.CreateHighStraight();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_Straight_To_ThreeOfAKind_Straight_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowStraight();
            var pokerHand2 = PokerHandTestHelper.CreateHighThreeOfAKind();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_ThreeOfAKind_To_TwoPair_ThreeOfAKind_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowThreeOfAKind();
            var pokerHand2 = PokerHandTestHelper.CreateHighTwoPairs();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_TwoPair_To_Pair_TwoPair_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowTwoPairs();
            var pokerHand2 = PokerHandTestHelper.CreateHighPair();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        [TestMethod]
        [TestCategory("Hand vs Hand")]
        public void Comparer_WhenComparing_Pair_To_HighCard_Pair_Wins()
        {
            var pokerHand1 = PokerHandTestHelper.CreateLowPair();
            var pokerHand2 = PokerHandTestHelper.CreateHighHighCard();

            var result = _comparer.CompareHands(pokerHand1, pokerHand2);
            Assert.AreEqual(1, result, "Expected Hand1 to beat Hand2");
        }

        #endregion
    }
}
