
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

    public class Card : IEquatable<Card>, IComparable<Card>
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
            // Note: only compare in values, as suite doesn't change
            // precedence...
            if (this.Equals(other))
                return 0;

            int thisVal = (int)this.Value;
            int otherVal = (int)other.Value;

            if (thisVal > otherVal)
                return 1;
            else if (thisVal < otherVal)
                return -1;
            else
                return 0;
        }

        public bool Equals(Card other)
        {
            if (other != null)
            {
                if (this.Suit == other.Suit && this.Value == other.Value)
                    return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            // this object is no longer equal on its memory address, so must override GetHashCode().
            return this.Equals(obj as Card);
        }

        public override int GetHashCode()
        {
            // if two things are equal (Equals(...) == true) then they must return the same value for GetHashCode()
            // however, this object's properties can change and so it is not immutable. Any change to its properties
            // could make it that it cannot be found in a dictionary or hashtable.

            //left as is, because it was one of the original classes and i can only extend...

            unchecked
            {
                // use a prime numbers to improve uniqueness and avoid collisions
                int hash = 23;
                hash = hash * 31 + this.Suit.GetHashCode();
                hash = hash * 31 + this.Value.GetHashCode();
                return hash;
            }
        }
    }
}
