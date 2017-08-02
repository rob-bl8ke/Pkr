
using System;

namespace PokerHandExercise.Classes
{
    public class Card : IComparable<Card>
    {
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

        public int CompareTo(Card other)
        {
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
