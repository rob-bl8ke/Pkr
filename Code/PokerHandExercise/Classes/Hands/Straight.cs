using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class Straight : SpecifiedPokerHand
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

        public Straight(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 5;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is Straight)
            {
                Straight otherStraight = other as Straight;

                if (this.HighCard == CardValue.Ace && otherStraight.HighCard != CardValue.Ace)
                    return 1;

                if (otherStraight.HighCard == CardValue.Ace && this.HighCard != CardValue.Ace)
                    return -1;
                else if (this.HighCard > otherStraight.HighCard)
                    return 1;
                else if (this.HighCard < otherStraight.HighCard)
                    return -1;
                else
                    return 0;
            }
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
