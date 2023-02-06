namespace Games
{
    public class Class1
    {
        IGame game = null;
        if (menuCode == XXX.Blackjack) 
        {
        game = new BlackJack();
        } 
        else if (menuCode == XXX.XO)
        {
        game = new XO();
        }

        return game;
    }
}