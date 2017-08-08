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

            if (cards.First() == 1)
            {
                if (cards.Skip(1).First() == 2)
                    return IsSequenced(cards, 1, 4);
                else
                    return IsSequenced(cards, 1, 4) && cards[4] == 13;
            }
            else
                return IsSequenced(cards, 0, 4);
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

        protected bool IsSequenced(List<int> cards, int start, int end)
        {
            for (int x = start; x < end; x++)
            {
                if (cards[x + 1] != cards[x] + 1)
                    return false;
            }
            return true;
        }
    }
}
