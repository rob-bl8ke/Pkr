using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal interface IPokerHandSpecification
    {
        bool IsSatisfiedBy(PokerHand pokerHand);
    }
}
