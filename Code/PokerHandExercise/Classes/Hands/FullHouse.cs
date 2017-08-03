using System.Linq;

namespace PokerHandExercise.Classes.Hands
{
    internal class FullHouse : SpecifiedPokerHand
    {
        public CardValue HighCard
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 3).FirstOrDefault().Key;
            }
        }

        public FullHouse(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 7;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is FullHouse)
            {
                FullHouse otherFullHouse = other as FullHouse;
                return base.CompareSingleCard(this.HighCard, otherFullHouse.HighCard);
            }
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
