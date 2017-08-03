using System.Collections.Generic;
using System.Linq;

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
                    return base.CompareSingleCard(this.HighPairValue, otherPair.HighPairValue);

                else
                {
                    List<Card> theseCards = this.Cards.Where(c => c.Value != this.HighPairValue).ToList();
                    List<Card> otherCards = other.Cards.Where(c => c.Value != otherPair.HighPairValue).ToList();

                    theseCards.Sort(new HighAceCardComparer());
                    otherCards.Sort(new HighAceCardComparer());

                    return base.CompareHighToLowCards(theseCards.ToArray(), otherCards.ToArray());
                }
            }
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
