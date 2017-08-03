using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FlushSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            //TODO: careful! Need to check this against a StraightFlush?
            if (base.SameSuite(pokerHand))
                return true;
            return false;
        }
    }
}
