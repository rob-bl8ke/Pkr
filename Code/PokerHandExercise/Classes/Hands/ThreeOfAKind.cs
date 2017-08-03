using System.Linq;

namespace PokerHandExercise.Classes.Hands
{
    internal class ThreeOfAKind : SpecifiedPokerHand
    {
        public CardValue HighCardValue
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 3).FirstOrDefault().Key;
            }
        }

        public ThreeOfAKind(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 4;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is ThreeOfAKind)
            {
                ThreeOfAKind otherThreeOfAKind = other as ThreeOfAKind;
                return base.CompareSingleCard(this.HighCardValue, otherThreeOfAKind.HighCardValue);
            }
            else
                return base.CompareTo(other);
        }
    }
}
