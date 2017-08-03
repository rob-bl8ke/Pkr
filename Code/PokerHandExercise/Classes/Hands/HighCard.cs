using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class HighCard : SpecifiedPokerHand
    {
        public HighCard(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 1;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is HighCard)
                return Utility.CompareHighToLowCards(this, other);

            else
                return base.CompareTo(other);
        }
    }
}
