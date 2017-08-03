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
                    return Utility.CompareHighToLowCards(this, other);
            }
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
