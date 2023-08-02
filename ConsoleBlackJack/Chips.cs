namespace ConsoleBlackJack;

internal class Chips
{
    public int Total { get; private set; } = 100;
    public int Bet { get; set; } = 0;

    public void WinBet()
    {
        Total += Bet;
    }

    public void LoseBet()
    {
        Total -= Bet;
    }
}