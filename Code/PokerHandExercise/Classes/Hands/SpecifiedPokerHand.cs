using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal abstract class SpecifiedPokerHand : IComparable<SpecifiedPokerHand>
    {
        public int Weighting { get; protected set; }
        protected readonly PokerHand pokerHand;

        public int NoOfCards
        {
            get
            {
                if (pokerHand == null)
                    return 0;
                return pokerHand.Count();
            }
        }

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

        public virtual int CompareTo(SpecifiedPokerHand other)
        {
            if (this.Weighting > other.Weighting)
                return 1;
            else if (this.Weighting < other.Weighting)
                return -1;
            else
                return 0;
        }

        protected int CompareSingleCard(CardValue myValue, CardValue otherValue)
        {
            int myWeighting = GetCardValueWeighting(myValue);
            int otherWeighting = GetCardValueWeighting(otherValue);

            return myWeighting.CompareTo(otherWeighting);
        }

        protected int GetCardValueWeighting(CardValue cardValue)
        {
            if (cardValue == CardValue.Ace)
                return 1000;
            else
                return ((int)cardValue);
        }

        protected int CompareHighToLowCards(SpecifiedPokerHand thisHand, SpecifiedPokerHand otherHand)
        {
            for (int x = 0; x < thisHand.NoOfCards; x++)
            {
                if (thisHand[x].Value == CardValue.Ace && otherHand[x].Value != CardValue.Ace)
                    return 1;
                else if (otherHand[x].Value == CardValue.Ace && thisHand[x].Value != CardValue.Ace)
                    return -1;

                int val = thisHand[x].CompareTo(otherHand[x]);

                if (val != 0)
                    return val;
            }

            return 0;
        }
    }
}
