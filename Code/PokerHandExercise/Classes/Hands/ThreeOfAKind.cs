using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class ThreeOfAKind : SpecifiedPokerHand
    {
        public CardValue HighCard
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 3).FirstOrDefault().Key;
            }
        }

        public ThreeOfAKind(PokerHand pokerHand) : base(pokerHand)
        {
        }


        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is ThreeOfAKind)
            {
                ThreeOfAKind threeOfAKind = other as ThreeOfAKind;

                if (this.HighCard == CardValue.Ace && threeOfAKind.HighCard != CardValue.Ace)
                    return 1;
                if (threeOfAKind.HighCard == CardValue.Ace && this.HighCard != CardValue.Ace)
                    return -1;
                else if (this.HighCard > threeOfAKind.HighCard)
                    return 1;
                else if (this.HighCard < threeOfAKind.HighCard)
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
