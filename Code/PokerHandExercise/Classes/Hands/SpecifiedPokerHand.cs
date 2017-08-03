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

        public Card[] Cards
        {
            get { return this.pokerHand.ToArray(); }
        }

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

        //TODO: Note: all comparisons on a card should look only at the card number.
        //  Why? Well a Jack of Spades is comparable to a Jack of Hearts (unless
        // one is interested in sorting by suite - which is not a responsibility
        // of this component.

        // Equals() is different, and if we wanted to look at equality then 
        // suite and number will matter.

        protected int CompareSingleCard(CardValue myValue, CardValue otherValue)
        {
            int myWeighting = GetCardWeighting(myValue);
            int otherWeighting = GetCardWeighting(otherValue);

            return myWeighting.CompareTo(otherWeighting);
        }

        protected int GetCardWeighting(CardValue cardValue)
        {
            if (cardValue == CardValue.Ace)
                return 1000;
            else
                return ((int)cardValue);
        }

        protected int CompareHighToLowCards(Card[] theseCards, Card[] otherCards)
        {
            for (int x = theseCards.Count() - 1; x >= 0; x--)
            {
                int val = CompareSingleCard(theseCards[x].Value, otherCards[x].Value);
                if (val != 0)
                    return val;
            }

            return 0;
        }

        protected int CompareHighToLowCards(SpecifiedPokerHand thisHand, SpecifiedPokerHand otherHand)
        {
            return CompareHighToLowCards(thisHand.Cards, otherHand.Cards);
        }
    }
}
