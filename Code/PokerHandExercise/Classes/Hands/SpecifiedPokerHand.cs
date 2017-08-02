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

        public Card this[int x]
        {
            //TODO: thinks about what happens when this is out of bounds!
            // Throw custom exception?
            get { return pokerHand[x]; }
        }

        public SpecifiedPokerHand(PokerHand pokerHand)
        {
            this.pokerHand = pokerHand;
        }

        public abstract int CompareTo(SpecifiedPokerHand other);
    }
}
