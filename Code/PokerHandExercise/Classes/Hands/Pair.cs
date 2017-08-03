using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class Pair : SpecifiedPokerHand
    {
        public CardValue HighPairValue
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 2).Max(g => g.First()).Value;
            }
        }

        public Pair(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 2;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is Pair)
            {
                Pair otherPair = other as Pair;

                if (this.HighPairValue != otherPair.HighPairValue)
                    return Utility.CompareSingleCard(this.HighPairValue, otherPair.HighPairValue);

                else
                    return CompareHighToLowCards(other);
            }
            else
            {
                return base.CompareTo(other);
            }
        }

        private int CompareHighToLowCards(SpecifiedPokerHand other)
        {
            for (int x = 0; x < this.pokerHand.Count; x++)
            {
                if (this[x].Value == CardValue.Ace && other[x].Value != CardValue.Ace)
                    return 1;
                else if (other[x].Value == CardValue.Ace && this[x].Value != CardValue.Ace)
                    return -1;

                int val = this[x].CompareTo(other[x]);

                if (val != 0)
                    return val;
            }

            return 0;
        }
    }
}
