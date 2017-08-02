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
            return Utility.SameSuite(pokerHand) && Utility.UnbrokenSequence(pokerHand);
        }

        private bool SameSuite(PokerHand pokerHand)
        {
            return pokerHand.Select(c => c.Suit).Distinct().Count() == 1;
        }
    }
}
