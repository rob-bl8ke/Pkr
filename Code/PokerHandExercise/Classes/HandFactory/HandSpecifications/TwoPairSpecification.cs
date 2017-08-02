using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class TwoPairSpecification : IPokerHandSpecification
    {
        public bool IsSatisfiedBy(PokerHand pokerHand)
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
