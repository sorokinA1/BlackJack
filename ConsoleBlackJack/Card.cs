namespace ConsoleBlackJack;

public class Card
{
    public static readonly string[] AllRanks =
        { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

    public static readonly string[] AllSuits = { "♠️", "♣️", "♦️", "♥️" };

    private static readonly Dictionary<string, int> AllValues = new()
    {
        { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
        { "Jack", 10 }, { "Queen", 10 }, { "King", 10 }, { "Ace", 11 }
    };

    public string Rank { get; }
    public string Suit { get; }
    public int Value { get; }

    public Card(string cardSuit, string cardRank)
    {
        Suit = cardSuit;
        Rank = cardRank;
        Value = AllValues[cardRank];
    }

    public override string ToString()
    {
        return $"[{Suit}{Rank}]";
    }
}