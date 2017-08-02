using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class TwoPair : SpecifiedPokerHand
    {
        public Card HighestPair
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 2).Max(g => g.First());
            }
        }

        public Card LowestPair
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 2).Min(g => g.First());
            }
        }

        public Card FifthCard
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 1).Single().First();
            }
        }

        public TwoPair(PokerHand pokerHand) : base(pokerHand)
        {
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is TwoPair)
            {
                TwoPair otherTwoPair = other as TwoPair;

                if (this.HighestPair.Value != otherTwoPair.HighestPair.Value)
                {
                    return this.HighestPair.CompareTo(otherTwoPair.HighestPair);
                }
                else if (this.LowestPair.Value != otherTwoPair.LowestPair.Value)
                {
                    return this.LowestPair.CompareTo(otherTwoPair.LowestPair);
                }
                else if (this.FifthCard.Value != otherTwoPair.FifthCard.Value)
                {
                    if (this.FifthCard.Value == CardValue.Ace && otherTwoPair.FifthCard.Value != CardValue.Ace)
                        return 1;
                    else if (this.FifthCard.Value != CardValue.Ace && otherTwoPair.FifthCard.Value == CardValue.Ace)
                        return -1;
                    else
                        return this.FifthCard.CompareTo(otherTwoPair.FifthCard);
                }
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
