
using System;
using System.Collections;
using System.Collections.Generic;

namespace PokerHandExercise.Classes
{
    public class HighAceCardComparer : IComparer<Card>, IComparer
    {
        public int Compare(Card x, Card y)
        {
            int myWeighting = Card.GetCardWeight(x.Value);
            int otherWeighting = Card.GetCardWeight(y.Value);

            return myWeighting.CompareTo(otherWeighting);
        }

        int IComparer.Compare(object x, object y)
        {
            return Compare((Card)x, (Card)y);
        }
    }

    public class Card : IComparable<Card>
    {
        public static int GetCardWeight(CardValue cardValue)
        {
            if (cardValue == CardValue.Ace)
                return 1000;
            else
                return ((int)cardValue);
        }

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card()
        {
        }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        // Note: all comparisons on a card should look only at the card number.
        //  Why? Well a Jack of Spades is comparable to a Jack of Hearts (unless
        // one is interested in sorting by suite - which is not a responsibility
        // of this component.

        // Equals() is different, and if we wanted to look at equality then 
        // suite and number will matter.

        public int CompareTo(Card other)
        {
            // Note: CompareTo != Equals() in this case. Equals is always more specific.
            int thisVal = (int)this.Value;
            int otherVal = (int)other.Value;

            if (thisVal > otherVal)
                return 1;
            else if (thisVal < otherVal)
                return -1;
            else
                return 0;
        }
    }
}
