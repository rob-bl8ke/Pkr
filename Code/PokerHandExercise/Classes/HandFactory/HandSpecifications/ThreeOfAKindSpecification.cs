
namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class ThreeOfAKindSpecification : PokerHandSpecification
    {
        // 3 of the 5 cards in the hand have the same Value (suit is irrelevant)
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.ContainsXofSameKind(pokerHand, 3);
        }
    }
}
