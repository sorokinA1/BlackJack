namespace ConsoleBlackJack;

internal class Hand
{
    public List<Card> Cards { get; }
    public int Value { get; set; }
    private int Aces { get; set; }

    public Hand()
    {
        Cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        // from deck.deal
        Cards.Add(card);
        Value += card.Value;

        if (card.Rank == "Ace") Aces++;
    }

    public void AdjustForAce()
    {
        // Ace 11 or 1
        while (Value > 21 && Aces > 0)
        {
            Value -= 10;
            Aces--;
        }
    }

    public override string ToString()
    {
        var allCards = "";
        foreach (var card in Cards)
        {
            allCards += $"{card} ";
        }

        return allCards;
    }
}