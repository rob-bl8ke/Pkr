using System.Linq;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FullHouseSpecification : PokerHandSpecification
    {
        // 3 of the cards have same value, and the other 2 have the same value (suit is irrelevant)

        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
        }
    }
}
