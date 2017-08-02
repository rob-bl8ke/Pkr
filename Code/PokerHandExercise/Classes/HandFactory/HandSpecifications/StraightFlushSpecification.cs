using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class StraightFlushSpecification : IPokerHandSpecification
    {
        // All five cards are the same suit, and they are in a value sequence 
        // (with Ace considered either a one (falling below the numeric 2) or a card following the King )

        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return SameSuite(pokerHand) && UnbrokenSequence(pokerHand);
        }

        private bool SameSuite(PokerHand pokerHand)
        {
            return pokerHand.Select(c => c.Suit).Distinct().Count() == 1;
        }

        private bool UnbrokenSequence(PokerHand pokerHand)
        {
            List<int> cards = pokerHand.Select(c => c.Value).Cast<int>().ToList();
            cards.Sort();

            int lowest = cards.First();
            int secondLowest = cards.Skip(1).First();
            int highest = cards.Last();

            if (lowest == 1 && secondLowest == 10 && highest == 13)
                return true;

            if (lowest == 1 && secondLowest == 2 && highest == 5)
                return true;

            if (lowest > 1 && highest == lowest + 4)
                return true;

            return false;
        }
    }
}
