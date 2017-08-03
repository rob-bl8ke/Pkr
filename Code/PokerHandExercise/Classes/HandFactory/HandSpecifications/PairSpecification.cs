
namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class PairSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.ContainsXofSameKind(pokerHand, 2);
        }
    }
}
