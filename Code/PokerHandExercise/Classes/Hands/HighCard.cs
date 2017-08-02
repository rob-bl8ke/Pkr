using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class HighCard : SpecifiedPokerHand
    {
        public HighCard(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 1;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is HighCard)
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
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
