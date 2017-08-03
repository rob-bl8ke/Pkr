using PokerHandExercise.Classes.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes
{
    internal static class Utility
    {
        public static bool ContainsXofSameKind(PokerHand pokerHand, int num)
        {
            var groups = pokerHand.GroupBy(c => c.Value);
            return groups.Any(g => g.Count() == num);
        }

        public static bool SameSuite(PokerHand pokerHand)
        {
            return pokerHand.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public static bool UnbrokenSequence(PokerHand pokerHand)
        {
            List<int> cards = pokerHand.Select(c => c.Value).Cast<int>().ToList();
            cards.Sort();

            int lowest = cards.First();
            int secondLowest = cards.Skip(1).First();
            int highest = cards.Last();

            if (lowest == 1 && secondLowest == 10 && highest == 13)
                return true;

            if (lowest == 1 && secondLowest == 2 && highest == 5)
                return true;

            if (lowest > 1 && highest == lowest + 4)
                return true;

            return false;
        }

        public static int CompareSingleCard(CardValue myValue, CardValue otherValue)
        {
            int myWeighting = GetCardValueWeighting(myValue);
            int otherWeighting = GetCardValueWeighting(otherValue);

            return myWeighting.CompareTo(otherWeighting);
        }

        public static int GetCardValueWeighting(CardValue cardValue)
        {
            if (cardValue == CardValue.Ace)
                return 1000;
            else
                return ((int)cardValue);
        }

        public static int CompareHighToLowCards(SpecifiedPokerHand thisHand, SpecifiedPokerHand otherHand)
        {
            for (int x = 0; x < thisHand.NoOfCards; x++)
            {
                if (thisHand[x].Value == CardValue.Ace && otherHand[x].Value != CardValue.Ace)
                    return 1;
                else if (otherHand[x].Value == CardValue.Ace && thisHand[x].Value != CardValue.Ace)
                    return -1;

                int val = thisHand[x].CompareTo(otherHand[x]);

                if (val != 0)
                    return val;
            }

            return 0;
        }
    }
}
