using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class StraightFlush : SpecifiedPokerHand
    {
        public CardValue HighCard
        {
            get
            {
                if (pokerHand.First().Value == CardValue.Ace && pokerHand.Last().Value == CardValue.King)
                    return CardValue.Ace;

                else
                    return pokerHand.Last().Value;
            }
        }

        public StraightFlush(PokerHand pokerHand) : base(pokerHand)
        {
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is StraightFlush)
            {
                StraightFlush otherStraightFlush = other as StraightFlush;

                if (this.HighCard == CardValue.Ace && otherStraightFlush.HighCard != CardValue.Ace)
                    return 1;

                if (otherStraightFlush.HighCard == CardValue.Ace && this.HighCard != CardValue.Ace)
                    return -1;
                else if (this.HighCard > otherStraightFlush.HighCard)
                    return 1;
                else if (this.HighCard < otherStraightFlush.HighCard)
                    return -1;
                else
                    return 0;
            }
            else
            {
                if (this.Weighting > other.Weighting)
                    return 1;
                else if (this.Weighting < other.Weighting)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
