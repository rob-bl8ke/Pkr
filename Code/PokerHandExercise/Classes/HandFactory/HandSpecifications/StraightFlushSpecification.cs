using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class StraightFlushSpecification : PokerHandSpecification
    {
        // All five cards are the same suit, and they are in a value sequence 
        // (with Ace considered either a one (falling below the numeric 2) or a card following the King )

        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.SameSuite(pokerHand) && base.UnbrokenSequence(pokerHand);
        }
    }
}
