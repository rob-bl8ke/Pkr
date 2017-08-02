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

            FourOfAKindSpecification fourOfAKindSpecification = new FourOfAKindSpecification();
            if (fourOfAKindSpecification.IsSatisfiedBy(pokerHand))
                return new FourOfAKind(pokerHand);

            FullHouseSpecification fullHouseSpecification = new FullHouseSpecification();
            if (fullHouseSpecification.IsSatisfiedBy(pokerHand))
                return new FullHouse(pokerHand);

            FlushSpecification flushSpecification = new FlushSpecification();
            if (flushSpecification.IsSatisfiedBy(pokerHand))
                return new Flush(pokerHand);

            StraightSpecification straightSpecification = new StraightSpecification();
            if (straightSpecification.IsSatisfiedBy(pokerHand))
                return new Straight(pokerHand);

            ThreeOfAKindSpecification threeOfAKindSpecification = new ThreeOfAKindSpecification();
            if (threeOfAKindSpecification.IsSatisfiedBy(pokerHand))
                return new ThreeOfAKind(pokerHand);

            TwoPairSpecification twoPairSpecification = new TwoPairSpecification();
            if (twoPairSpecification.IsSatisfiedBy(pokerHand))
                return new TwoPair(pokerHand);

            PairSpecification pairSpecification = new PairSpecification();
            if (pairSpecification.IsSatisfiedBy(pokerHand))
                return new Pair(pokerHand);

            return null;
        }
    }
}
