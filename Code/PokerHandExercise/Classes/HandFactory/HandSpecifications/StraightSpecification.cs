using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class StraightSpecification : IPokerHandSpecification
    {
        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return Utility.UnbrokenSequence(pokerHand);
        }
    }
}
