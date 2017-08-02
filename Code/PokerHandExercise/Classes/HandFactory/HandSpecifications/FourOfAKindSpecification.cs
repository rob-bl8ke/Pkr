using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FourOfAKindSpecification : IPokerHandSpecification
    {
        // 4 of the 5 cards in the hand have the same Value (suit is irrelevant)
        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Any(g => g.Count() == 4);
        }
    }
}
