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
            cards.Sort(); // just in case...

            int lowest = cards.First();
            int secondLowest = cards.Skip(1).First();
            int highest = cards.Last();

            if (lowest == 1 && secondLowest == 10 && highest == 13)
                return IsSequenced(cards, 1, 4);

            if (lowest == 1 && secondLowest == 2 && highest == 5)
                return IsSequenced(cards, 0, 4);

            if (lowest > 1 && highest == lowest + 4)
                return IsSequenced(cards, 0, 4);

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

        private bool IsSequenced(List<int> cards, int start, int end)
        {
            for (int x = start; x != end - 1; x++)
            {
                int nextNum = cards[x];
                if (cards[x + 1] != cards[x] + 1)
                    return false;
            }
            return true;
        }
    }
}
