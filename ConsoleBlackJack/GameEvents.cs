namespace ConsoleBlackJack;

internal static class GameEvents
{
    public static void TakeBet(Chips chip)
    {
        while (true)
        {
            Console.WriteLine("How many chips would you like to bet?");
            try
            {
                chip.Bet = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, please provide an integer");
                continue;
            }

            if (chip.Bet > chip.Total)
                Console.WriteLine($"Sorry, you dont have enough chips. You have {chip.Total} chips");
            else break;
        }
    }

    public static void Hit(Deck deck, Hand hand)
    {
        var singleCard = deck.Deal();
        hand.AddCard(singleCard);
        hand.AdjustForAce();
    }

    public static void HitOrStand(Deck deck, Hand hand, ref bool play)
    {
        while (true)
        {
            Console.WriteLine("\nHit or Stand?");
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Stand");
            var userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Hit(deck, hand);
                Console.WriteLine("Current hand:" + hand);
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("Player Stands. Dealer's turn.");
                play = false;
            }
            else
            {
                Console.WriteLine("Please enter 1 or 2");
                continue;
            }

            break;
        }
    }

    public static void ShowSome(Hand player, Hand dealer)
    {
        Console.WriteLine("Dealer's hand: ");
        Console.WriteLine("First card hidden!");
        Console.WriteLine(dealer.Cards[1]);
        Console.WriteLine("");
        Console.WriteLine("Player's hand: ");
        foreach (var card in player.Cards)
        {
            Console.Write(card + " ");
        }
    }

    public static void ShowAll(Hand player, Hand dealer)
    {
        Console.WriteLine("\nDealer's hand: ");
        foreach (var card in dealer.Cards)
        {
            Console.Write(card + " ");
        }

        Console.WriteLine($"\nValue of dealer hand is: {dealer.Value}");

        Console.WriteLine("\nPlayer's hand: ");
        foreach (var card in player.Cards)
        {
            Console.Write(card + " ");
        }

        Console.WriteLine("");

        Console.WriteLine($"Value of player hand is: {player.Value}");
    }

    public static void PlayerBusts(Hand player, Hand dealer, Chips chips)
    {
        Console.WriteLine("\nBUST Player!");
        chips.LoseBet();
    }

    public static void PlayerWins(Hand player, Hand dealer, Chips chips)
    {
        Console.WriteLine("Player WINS!");
        chips.WinBet();
    }

    public static void DealerBusts(Hand player, Hand dealer, Chips chips)
    {
        Console.WriteLine("BUST Dealer!");
        chips.WinBet();
    }

    public static void DealerWins(Hand player, Hand dealer, Chips chips)
    {
        Console.WriteLine("Dealer wins!");
        chips.LoseBet();
    }

    public static void Push(Hand player, Hand dealer)
    {
        Console.WriteLine("Dealer and Player tie! PUSH");
    }
}