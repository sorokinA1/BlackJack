namespace ConsoleBlackJack;

internal static class Game
{
    private static int _round = 1;
    private const int MaxHandValue = 21;
    private const int DealerMaxRisk = 17;

    public static void Start()
    {
        var playing = true;

        // chips creation
        var playerChips = new Chips();

        Console.WriteLine("Welcome to BLACKJACK 🃏");
        Console.WriteLine("***********************");
        Console.WriteLine("Player chips: " + playerChips.Total);

        while (true)
        {
            // game init
            Console.WriteLine("Round " + _round);
            var deck = new Deck();
            deck.Shuffle();

            var playerHand = new Hand();
            playerHand.AddCard(deck.Deal());
            playerHand.AddCard(deck.Deal());

            var dealerHand = new Hand();
            dealerHand.AddCard(deck.Deal());
            dealerHand.AddCard(deck.Deal());

            // prompt for bet
            GameEvents.TakeBet(playerChips);

            // show cards
            GameEvents.ShowSome(playerHand, dealerHand);

            while (playing)
            {
                // prompt player for hit or stand
                GameEvents.HitOrStand(deck, playerHand, ref playing);

                // show 1 card
                GameEvents.ShowSome(playerHand, dealerHand);

                // check results
                if (playerHand.Value > MaxHandValue)
                {
                    GameEvents.PlayerBusts(playerHand, dealerHand, playerChips);
                    Console.WriteLine("Player's hand: " + playerHand.Value);
                    break;
                }
            }

            if (playerHand.Value <= MaxHandValue)
            {
                while (dealerHand.Value < DealerMaxRisk)
                {
                    GameEvents.Hit(deck, dealerHand);
                }

                GameEvents.ShowAll(playerHand, dealerHand);

                // run winning scenarios
                if (dealerHand.Value > MaxHandValue)
                {
                    GameEvents.DealerBusts(playerHand, dealerHand, playerChips);
                }
                else if (dealerHand.Value > playerHand.Value)
                {
                    GameEvents.DealerWins(playerHand, dealerHand, playerChips);
                }
                else if (dealerHand.Value < playerHand.Value)
                {
                    GameEvents.PlayerWins(playerHand, dealerHand, playerChips);
                }
                else
                {
                    GameEvents.Push(playerHand, dealerHand);
                }
            }

            Console.WriteLine($"\nPlayer's total chips are at: {playerChips.Total}");

            if (playerChips.Total <= 0)
            {
                Console.WriteLine("You are out of chips, thank you for playing!");
                break;
            }

            Console.WriteLine("\n Would you like to play another hand?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                playing = true;
                _round++;
                continue;
            }

            Console.WriteLine("Thank you for playing!");
            break;
        }
    }
}