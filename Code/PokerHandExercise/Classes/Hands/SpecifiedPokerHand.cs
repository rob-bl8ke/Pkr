using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal abstract class SpecifiedPokerHand : IComparable<SpecifiedPokerHand>
    {
        internal readonly int Weighting;
        protected readonly PokerHand pokerHand;

        public SpecifiedPokerHand(PokerHand pokerHand)
        {
            this.pokerHand = pokerHand;
        }

        public abstract int CompareTo(SpecifiedPokerHand other);
    }
}
