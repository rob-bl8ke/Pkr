using System.Linq;

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
            base.Weighting = 9;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is StraightFlush)
            {
                StraightFlush otherStraightFlush = other as StraightFlush;
                return base.CompareSingleCard(this.HighCard, otherStraightFlush.HighCard);
            }
            else
                return base.CompareTo(other);
        }
    }
}
