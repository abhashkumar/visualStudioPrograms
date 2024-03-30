public enum Player
{
    X,
    O
}

public enum GameStatus
{
    Playing,
    Draw,
    WinnerX,
    WinnerY,
}
public class TicTacToe
{
    public Player currentPlayer;
    public Dictionary<String, int> map;
    public HashSet<String> availablePlaces;
    public GameStatus gameStatus;

    public TicTacToe()
    {
        currentPlayer = Player.X;
        map = new Dictionary<String, int>();
        
        map.Add("R1X", 0);
        map.Add("R2X", 0);
        map.Add("R3X", 0);
        map.Add("C1X", 0);
        map.Add("C2X", 0);
        map.Add("C3X", 0);
        map.Add("D1X", 0);
        map.Add("D2X", 0);


        map.Add("R1O", 0);
        map.Add("R2O", 0);
        map.Add("R3O", 0);
        map.Add("C1O", 0);
        map.Add("C2O", 0);
        map.Add("C3O", 0);
        map.Add("D1O", 0);
        map.Add("D2O", 0);

        availablePlaces = new HashSet<String> { "R1C1", "R1C2", "R1C3", "R2C1", "R2C2", "R2C3", "R3C1", "R3C2", "R3C3" };
        gameStatus = GameStatus.Playing;
    }

    private bool doWeHaveAWinner(string currentMove)
    {
        char currentChar = currentPlayer == Player.X ? 'X' : 'O';
        var row = currentMove.Substring(0, 2);
        var col = currentMove.Substring(2, 2);
        map[$"{row}{currentChar}"] += 1;
        map[$"{col}{currentChar}"] += 1;

        if ((row == "R1" && col == "C1") || (row == "R3" && col == "C3"))
        {
            map[$"D1{currentChar}"] += 1;
        }
        if ((row == "R1" && col == "C3") || (row == "R3" && col == "C1"))
        {
            map[$"D2{currentChar}"] += 1;
        }
        if (row == "R2" && col == "C2")
        {
            map[$"D1{currentChar}"] += 1;
            map[$"D2{currentChar}"] += 1;
        }
        if (map[$"{row}{currentChar}"] == 3 || map[$"{col}{currentChar}"] == 3 || map[$"D1{currentChar}"] == 3 || map[$"D2{currentChar}"] == 3)
        {
            return true;
        }
        return false;
    }
    
    public void HandlePlayerMove()
    {
        char currentChar = currentPlayer == Player.X ? 'X' : 'O';
        Console.WriteLine($"current player: {currentChar}");
        Console.WriteLine("please choose among these vaccent location :");
        foreach(string places in availablePlaces)
        {
            Console.WriteLine(places);
        }
        Console.WriteLine("=====================================");
        string? selectedPlace = Console.ReadLine();
        if (selectedPlace == null || !availablePlaces.Contains(selectedPlace))
        {
            Console.WriteLine("please select a valid place");
            return;
        }
        else
        {
            availablePlaces.Remove(selectedPlace);
            if (doWeHaveAWinner(selectedPlace))
            {
                gameStatus = currentPlayer == Player.X ? GameStatus.WinnerX : GameStatus.WinnerY;
                return;
            }
            gameStatus = availablePlaces.Count > 0 ? GameStatus.Playing : GameStatus.Draw;
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        }
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Do you want to start a game press y/n for yes or no ");

        string? x = Console.ReadLine();
        
        while(x!= null && x.Equals("y"))
        {
            TicTacToe game = new TicTacToe();
            while (game.gameStatus == GameStatus.Playing)
            {
                game.HandlePlayerMove();
                if (game.gameStatus == GameStatus.WinnerX)
                {
                    Console.WriteLine("Player X won");
                }
                else if(game.gameStatus == GameStatus.WinnerY)
                {
                    Console.WriteLine("Player O won");
                }
                else if(game.gameStatus == GameStatus.Draw)
                {
                    Console.WriteLine("Its a Draw");
                }
            }
            Console.WriteLine("Do you want to start a game press y/n for yes or no ");
            x = Console.ReadLine();
        }
    }
}