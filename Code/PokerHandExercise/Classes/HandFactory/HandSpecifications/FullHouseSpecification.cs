using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FullHouseSpecification : IPokerHandSpecification
    {
        // 3 of the cards have same value, and the other 2 have the same value (suit is irrelevant)

        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            // yes, another layer of indirection... and yet, i want to make it quite
            // explicit as to what this rule does.
            return ThreeAndTwoOfSameValue(pokerHand);
        }

        private bool ThreeAndTwoOfSameValue(PokerHand pokerHand)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
        }
    }
}
