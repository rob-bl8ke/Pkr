
namespace PokerHandExercise.Classes
{
  public class Card
  {
    public CardSuit Suit { get; set; }
    public CardValue Value { get; set; }

    public Card()
    {
    }

    public Card(CardSuit suit, CardValue value)
    {
      Suit = suit;
      Value = value;
    }
  }
}
