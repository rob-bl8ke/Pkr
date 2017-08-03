
namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FourOfAKindSpecification : PokerHandSpecification
    {
        // 4 of the 5 cards in the hand have the same Value (suit is irrelevant)
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.ContainsXofSameKind(pokerHand, 4);
        }
    }
}
