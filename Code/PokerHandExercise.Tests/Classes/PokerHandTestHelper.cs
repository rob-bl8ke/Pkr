using System;
using PokerHandExercise.Classes;

namespace PokerHandExercise.Tests.Classes
{
    public static class PokerHandTestHelper
    {
        public static PokerHand CreateHighStraightFlush()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Queen),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.King),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Jack)
            );
        }

        public static PokerHand CreateMidStraightFlush()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Four));
        }

        public static PokerHand CreateAceLowStraightFlush()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Four));
        }

        public static PokerHand CreateHighFourOfAKind()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten));
        }

        public static PokerHand CreateLowFourOfAKind()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Nine));
        }

        public static PokerHand CreateHighFullHouse()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Jack),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Jack));
        }

        public static PokerHand CreateLowFullHouse()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Eight),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Eight));
        }

        public static PokerHand CreateHighFlush()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Eight),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Jack),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten)
            );
        }

        public static PokerHand CreateLowFlush()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Eight),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Four)
            );
        }

        public static PokerHand CreateHighStraight()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Jack),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Queen),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.King)
            );
        }

        public static PokerHand CreateMidStraight()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Jack),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Nine),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Eight)
            );
        }

        public static PokerHand CreateLowStraight()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Three)
            );
        }

        public static PokerHand CreateHighThreeOfAKind()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.King),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.King),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.King)
            );
        }

        public static PokerHand CreateLowThreeOfAKind()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.King),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Four)
            );
        }

        public static PokerHand CreateLowTwoPairs()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Two)
            );
        }

        public static PokerHand CreateMidTwoPairs()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Five)
            );
        }

        public static PokerHand CreateSameTwoPairsDifferentFifthCard(CardValue fifthCardValue)
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, fifthCardValue),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Seven),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Five)
            );
        }

        public static PokerHand CreatePairDifferentNonPairCardValue(CardValue thirdCard, CardValue fourthCard, CardValue fifthCard)
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, thirdCard),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, fourthCard),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, fifthCard)
            );
        }

        public static PokerHand CreateHighTwoPairs()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Nine),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Queen),
              new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Queen),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Ace)
            );
        }

        public static PokerHand CreateLowPair()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Four),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Seven)
            );
        }

        public static PokerHand CreateMidPair()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Eight),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Eight),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Ace)
            );
        }

        public static PokerHand CreateHighPair()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Three)
            );
        }

        public static PokerHand CreateLowHighCard()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Five),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Six),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Seven)
            );
        }

        public static PokerHand CreateHighHighCard()
        {
            return CreateHand(new Tuple<CardSuit, CardValue>(CardSuit.Heart, CardValue.Three),
              new Tuple<CardSuit, CardValue>(CardSuit.Club, CardValue.Ten),
              new Tuple<CardSuit, CardValue>(CardSuit.Spade, CardValue.Two),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Ace),
              new Tuple<CardSuit, CardValue>(CardSuit.Diamond, CardValue.Seven)
            );
        }

        public static PokerHand CreateHand(params Tuple<CardSuit, CardValue>[] cards)
        {
            var result = new PokerHand();
            foreach (var card in cards)
            {
                result.Add(new Card() { Suit = card.Item1, Value = card.Item2 });
            }
            return result;
        }

        public static PokerHand CreateHand(params Card[] cards)
        {
            var result = new PokerHand();
            result.AddRange(cards);

            return result;
        }
    }
}
