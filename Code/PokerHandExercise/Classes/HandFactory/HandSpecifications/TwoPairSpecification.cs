using System.Linq;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class TwoPairSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return TwoPairs(pokerHand);
        }

        private bool TwoPairs(PokerHand pokerHand)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Where(g => g.Count() == 2).Count() == 2;
        }
    }
}
