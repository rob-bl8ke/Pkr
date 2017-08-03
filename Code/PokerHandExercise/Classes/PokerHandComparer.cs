
using PokerHandExercise.Classes.HandFactory;
using PokerHandExercise.Classes.Hands;

namespace PokerHandExercise.Classes
{
    public class PokerHandComparer : IPokerHandComparer
    {
        public int CompareHands(PokerHand hand1, PokerHand hand2)
        {
            //TODO: Pre-condion - both hands must have exactly 5 cards!

            //Important! : A function like this SHOULD NOT HAVE ANY SIDE-EFFECTS on passed in parameters from the client...
            // the client may be expect a certain state afterwards (post-conditions)... best to make a copy.
            PokerHand hand1Copy = CreateCopy(hand1);
            PokerHand hand2Copy = CreateCopy(hand2);

            // a this point, we know the PokerHand copy has been made, and sorted...
            // the rest of the logic assumes this... could be more defensive at the expense of performance.
            // for now, probably good enough.
            PokerHandFactory pokerHandFactory = new PokerHandFactory();

            SpecifiedPokerHand specifiedHand1 = pokerHandFactory.Create(hand1Copy);
            SpecifiedPokerHand specifiedHand2 = pokerHandFactory.Create(hand2Copy);

            return specifiedHand1.CompareTo(specifiedHand2);
        }

        private PokerHand CreateCopy(PokerHand pokerHand)
        {
            // possibly not the most efficient, however, for now I'm more interested in
            // getting the logic to work! Can always optimize later if necessary.
            Card[] cards = new Card[pokerHand.Count];
            pokerHand.CopyTo(cards);

            PokerHand newPokerHand = new PokerHand();
            newPokerHand.AddRange(cards);
            newPokerHand.Sort();

            return newPokerHand;
        }
    }
}
