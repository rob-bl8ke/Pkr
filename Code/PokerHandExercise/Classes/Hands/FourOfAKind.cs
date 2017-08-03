using System.Linq;

namespace PokerHandExercise.Classes.Hands
{
    internal class FourOfAKind : SpecifiedPokerHand
    {
        public CardValue HighCard
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 4).FirstOrDefault().Key;
            }
        }

        public FourOfAKind(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 8;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is FourOfAKind)
            {
                FourOfAKind fourOfAKind = other as FourOfAKind;
                return base.CompareSingleCard(this.HighCard, fourOfAKind.HighCard);
            }
            else
                return base.CompareTo(other);
        }
    }
}
