using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (this.HighCard == CardValue.Ace && fourOfAKind.HighCard != CardValue.Ace)
                    return 1;
                if (fourOfAKind.HighCard == CardValue.Ace && this.HighCard != CardValue.Ace)
                    return -1;
                else if (this.HighCard > fourOfAKind.HighCard)
                    return 1;
                else if (this.HighCard < fourOfAKind.HighCard)
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
