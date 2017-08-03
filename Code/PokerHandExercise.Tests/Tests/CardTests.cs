using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandExercise.Classes;

namespace PokerHandExercise.Tests.Tests
{
    [TestClass]
    public class CardTests
    {
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
    }
}
