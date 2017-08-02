using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class Pair : SpecifiedPokerHand
    {
        public Card HighPair
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 2).Max(g => g.First());
            }
        }

        public Pair(PokerHand pokerHand) : base(pokerHand)
        {
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is Pair)
            {
                Pair otherPair = other as Pair;

                if (this.HighPair.Value != otherPair.HighPair.Value)
                {
                    if (this.HighPair.Value == CardValue.Ace && otherPair.HighPair.Value != CardValue.Ace)
                        return 1;
                    else if (this.HighPair.Value != CardValue.Ace && otherPair.HighPair.Value == CardValue.Ace)
                        return -1;
                    else
                        return this.HighPair.CompareTo(otherPair.HighPair);
                } 
                else
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
