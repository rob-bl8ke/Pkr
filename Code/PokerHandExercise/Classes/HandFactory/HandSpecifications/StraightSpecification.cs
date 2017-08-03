
namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class StraightSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            return base.UnbrokenSequence(pokerHand);
        }
    }
}
