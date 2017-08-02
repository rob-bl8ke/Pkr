using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                FullHouse fullHouse = other as FullHouse;

                if (this.HighCard == CardValue.Ace && fullHouse.HighCard != CardValue.Ace)
                    return 1;
                if (fullHouse.HighCard == CardValue.Ace && this.HighCard != CardValue.Ace)
                    return -1;
                else if (this.HighCard > fullHouse.HighCard)
                    return 1;
                else if (this.HighCard < fullHouse.HighCard)
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
