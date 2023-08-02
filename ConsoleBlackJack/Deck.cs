namespace ConsoleBlackJack;

internal class Deck
{
    private List<Card> FullDeck { get; } = new();


    public Deck()
    {
        foreach (var suit in Card.AllSuits)
        {
            foreach (var rank in Card.AllRanks)
            {
                FullDeck.Add(new Card(suit, rank));
            }
        }
    }


    public override string ToString()
    {
        var allCards = "";
        foreach (var card in FullDeck)
        {
            allCards += $"{card} ";
        }

        return allCards;
    }

    public void Shuffle()
    {
        var random = new Random();
        var n = FullDeck.Count;
        while (n > 1)
        {
            n--;
            var k = random.Next(n + 1);
            (FullDeck[k], FullDeck[n]) = (FullDeck[n], FullDeck[k]);
        }
    }

    public Card Deal()
    {
        var singleCard = FullDeck[^1];
        FullDeck.RemoveAt(FullDeck.Count - 1);
        return singleCard;
    }
}