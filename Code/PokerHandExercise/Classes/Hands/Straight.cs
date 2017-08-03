using System.Linq;

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
                return base.CompareSingleCard(this.HighCard, otherStraight.HighCard);
            }
            else
                return base.CompareTo(other);
        }
    }
}
