using System.Collections.Generic;
using System.Linq;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal abstract class PokerHandSpecification
    {
        public abstract bool IsSatisfiedBy(PokerHand pokerHand);

        protected bool UnbrokenSequence(PokerHand pokerHand)
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

        protected bool ContainsXofSameKind(PokerHand pokerHand, int num)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Any(g => g.Count() == num);
        }

        protected bool SameSuite(PokerHand pokerHand)
        {
            return pokerHand.Select(c => c.Suit).Distinct().Count() == 1;
        }
    }
}
