using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class PairSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.ContainsXofSameKind(pokerHand, 2);
        }
    }
}
