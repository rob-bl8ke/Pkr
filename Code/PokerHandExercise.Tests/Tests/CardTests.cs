using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Classes;
using System.Collections.Generic;

namespace PokerHandExercise.Tests.Tests
{
    [TestClass]
    public class CardTests
    {
        #region Equality

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Equality")]
        public void Ensure_CardsEqualThemselves()
        {
            Card kingOfSpadesCard_1 = new Card(CardSuit.Spade, CardValue.King);
            Card kingOfSpadesCard_2 = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreEqual(kingOfSpadesCard_1, kingOfSpadesCard_2);
            Assert.IsTrue(kingOfSpadesCard_1.Equals(kingOfSpadesCard_2));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Equality")]
        public void Ensure_CardNotEqualToOtherCard_WhenSuitesAreDifferent()
        {
            Card kingOfSpadesCard_1 = new Card(CardSuit.Heart, CardValue.King);
            Card kingOfSpadesCard_2 = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreNotEqual(kingOfSpadesCard_1, kingOfSpadesCard_2);
            Assert.IsFalse(kingOfSpadesCard_1.Equals(kingOfSpadesCard_2));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Equality")]
        public void Ensure_CardNotEqualToOtherCard_WhenValueIsDifferent()
        {
            Card kingOfSpadesCard_1 = new Card(CardSuit.Spade, CardValue.Queen);
            Card kingOfSpadesCard_2 = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreNotEqual(kingOfSpadesCard_1, kingOfSpadesCard_2);
            Assert.IsFalse(kingOfSpadesCard_1.Equals(kingOfSpadesCard_2));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Equality")]
        public void Ensure_CardNotEqualToOtherCard_WhenSuiteAndValueIsDifferent()
        {
            Card kingOfSpadesCard_1 = new Card(CardSuit.Heart, CardValue.Queen);
            Card kingOfSpadesCard_2 = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreNotEqual(kingOfSpadesCard_1, kingOfSpadesCard_2);
            Assert.IsFalse(kingOfSpadesCard_1.Equals(kingOfSpadesCard_2));
        }

        #endregion

        #region Comparability

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_KingOfDiamonds_Comparables_As_EquivalentTo_KingOfSpades()
        {
            Card kingOfDiamondsCard = new Card(CardSuit.Diamond, CardValue.King);
            Card kingOfSpadesCard = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreEqual(0, kingOfDiamondsCard.CompareTo(kingOfSpadesCard));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_KingOfDiamonds_GreaterThan_QueenOfSpades()
        {
            Card kingOfDiamondsCard = new Card(CardSuit.Diamond, CardValue.King);
            Card queenOfSpadesCard = new Card(CardSuit.Spade, CardValue.Queen);

            Assert.AreEqual(1, kingOfDiamondsCard.CompareTo(queenOfSpadesCard));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_QueenOfDiamonds_LessThan_KingOfSpades()
        {
            Card queenOfDiamondsCard = new Card(CardSuit.Diamond, CardValue.Queen);
            Card kingOfSpadesCard = new Card(CardSuit.Spade, CardValue.King);

            Assert.AreEqual(-1, queenOfDiamondsCard.CompareTo(kingOfSpadesCard));
        }
        
        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_AceOfDiamonds_Comparables_As_EquivalentTo_AceOfSpades()
        {
            Card aceOfDiamondsCard = new Card(CardSuit.Diamond, CardValue.Ace);
            Card aceOfSpadesCard = new Card(CardSuit.Spade, CardValue.Ace);

            Assert.AreEqual(0, aceOfDiamondsCard.CompareTo(aceOfDiamondsCard));
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_AceOfDiamonds_GreaterThan_QueenOfSpades_When_HighAceCard()
        {
            Card highAce = new Card(CardSuit.Diamond, CardValue.Ace);
            Card kingOfSpades = new Card(CardSuit.Spade, CardValue.King);

            List<Card> cards = new List<Card> { highAce, kingOfSpades };

            cards.Sort(new HighAceCardComparer());

            Assert.AreSame(cards[0], kingOfSpades);
            Assert.AreSame(cards[1], highAce);
        }

        [TestMethod]
        [TestCategory("Card")]
        [TestCategory("Comparable")]
        public void Ensure_AceOfDiamonds_GreaterThan_QueenOfSpades_When_LowAceCard()
        {
            Card highAce = new Card(CardSuit.Diamond, CardValue.Ace);
            Card kingOfSpades = new Card(CardSuit.Spade, CardValue.King);

            List<Card> cards = new List<Card> { kingOfSpades, highAce};

            cards.Sort();

            Assert.AreSame(cards[0], highAce);
            Assert.AreSame(cards[1], kingOfSpades);
        }

        #endregion
    }
}
