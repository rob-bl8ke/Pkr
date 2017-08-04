
using PokerHandExercise.Classes.Exceptions;
using PokerHandExercise.Classes.HandFactory;
using PokerHandExercise.Classes.Hands;
using System;

namespace PokerHandExercise.Classes
{
    public class PokerHandComparer : IPokerHandComparer
    {
        public int CompareHands(PokerHand hand1, PokerHand hand2)
        {
            try
            {
                //Pre-condition - both hands must have exactly 5 cards!
                if (hand1.Count != 5 || hand2.Count != 5)
                    throw new IllegalNoOfCardsInHandException("An illegal number of cards was assigned to a poker hand. A poker hand must have five cards.");

                // side-effect free (expected post condition)
                PokerHand hand1Copy = CreateCopy(hand1);
                PokerHand hand2Copy = CreateCopy(hand2);

                // rest of the logic assumes above is sorted...
                PokerHandFactory pokerHandFactory = new PokerHandFactory();

                SpecifiedPokerHand specifiedHand1 = pokerHandFactory.Create(hand1Copy);
                SpecifiedPokerHand specifiedHand2 = pokerHandFactory.Create(hand2Copy);

                return specifiedHand1.CompareTo(specifiedHand2);
            }
            catch (IllegalNoOfCardsInHandException)
            {
                // Any necessary logging here...
                throw;
            }
            catch (Exception ex)
            {
                // Any necessary logging here...
                throw new UnknownPokerComparisonException("An unknown exception occurred while trying to compare poker hands.", ex);
            }
        }

        private PokerHand CreateCopy(PokerHand pokerHand)
        {
            Card[] cards = new Card[pokerHand.Count];
            pokerHand.CopyTo(cards);

            PokerHand newPokerHand = new PokerHand();
            newPokerHand.AddRange(cards);
            newPokerHand.Sort();

            return newPokerHand;
        }
    }
}
