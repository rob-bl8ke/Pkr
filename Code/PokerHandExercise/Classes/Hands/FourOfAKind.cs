using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class FourOfAKind : SpecifiedPokerHand
    {
        public FourOfAKind(PokerHand pokerHand) : base(pokerHand)
        {
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            throw new NotImplementedException();
        }
    }
}
