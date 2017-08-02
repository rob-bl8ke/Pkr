using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FourOfAKindSpecification : IPokerHandSpecification
    {
        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            //.Select(n => n).OrderBy(n => n.);

            return groups.Any(g => g.Count() == 4);
            //return groups.Max() == 4;
            //return false;
        }
    }
}
