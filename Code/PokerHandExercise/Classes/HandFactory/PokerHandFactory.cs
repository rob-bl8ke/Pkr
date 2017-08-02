using PokerHandExercise.Classes.HandFactory.HandSpecifications;
using PokerHandExercise.Classes.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory
{
    internal class PokerHandFactory
    {
        internal SpecifiedPokerHand Create(PokerHand pokerHand)
        {
            StraightFlushSpecification straightFlushSpecification = new StraightFlushSpecification();
            if (straightFlushSpecification.IsSatisfiedBy(pokerHand))
                return new StraightFlush(pokerHand);

            return null;
        }
    }
}
