
namespace PokerHandExercise.Classes.Hands
{
    internal class Flush : SpecifiedPokerHand
    {
        public Flush(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 6;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is Flush)
                return base.CompareHighToLowCards(this, other);
            
            else
                return base.CompareTo(other);
        }
    }
}
