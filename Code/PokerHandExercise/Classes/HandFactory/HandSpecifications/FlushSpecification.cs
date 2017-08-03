
namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FlushSpecification : PokerHandSpecification
    {
        public override bool IsSatisfiedBy(PokerHand pokerHand)
        {
            if (base.SameSuite(pokerHand))
                return true;
            return false;
        }
    }
}
