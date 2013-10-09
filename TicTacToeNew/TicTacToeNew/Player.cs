using System;

class Player
{

    public const char empty = ' ';
    public int moveCount = 0;
    public int BoardWidth { get; set; }
    public int BoardSize { get; set; }

    public Player(int boardSize, int boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }

    public int AskForMove(char[] board, char turn)
    {
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = Convert.ToInt32(Console.ReadLine());

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                input = Convert.ToInt32(Console.ReadLine());
            }

            else
                break;
        }

        return input;
    }

    public bool MakeMove(char[] board, char turn, int move)
    {
        // Make sure the user chose a valid tile
        if (move < 0 || move > BoardSize)
        {
            Console.Write("This is not a valid tile.\n");
            return false;
        }

        // If the location is empty...
        if (board[move] == empty)
        {
            // place the user's mark in that location
            board[move] = turn;

            // Keeps track of the number of tiles which have an X or O in them 
            moveCount += 1;

            return true;
        }
        else
        {
            Console.Write("That slot is already taken.\n");
            return false;
        }
    }
    // Method to determine winner by checking diagonal right,diagonal left,across and down (down not yet working for 5X5 game)
    //parameters: board -the tic-tac-toe game board, turn - X or O, arraySize- number of tiles user (X or O) has selected 
    public bool IsWinner(char[] board, char turn, int arraySize)
    {
        // Check for a win across (all game types +1)
        for (int i = 0; i < BoardSize; i += BoardWidth)
        {
            if (CheckForWin(board, turn, 1, i, i + BoardWidth) == true)
            {
                return true;
            }
        }

        // Check for a win diagonal right (standard 3 game, +2 (ex. 2, 4, 6))
        int diagRight = 2 + (BoardWidth - 3);
        if (CheckForWin(board, turn, diagRight, (BoardWidth - 1), (diagRight * BoardWidth) + 1) == true)
        {
            return true;
        }

        // Check for a win down starting at 0, 1, or 2 in standard game (standard 3 game, +3 (ex. 1, 4, 7))
        for (int i = 0; i < BoardWidth; i++)
        {
            if (CheckForWin(board, turn, 3 + (BoardWidth - 3), i, ((BoardWidth * 2) + i) + 1) == true)
            {
                return true;
            }
        }

        // Check for a win diagonal left (standard 3 game, +4 (ex. 0, 3, 8))
        if (CheckForWin(board, turn, 4 + (BoardWidth - 3), 0, BoardSize) == true)
        {
            return true;
        }

        //No win
        return false;
    }

    public bool IsDraw()
    {
        // Check to see if board is full
        if (moveCount >= BoardSize)
            return true;

        return false;
    }

    public bool CheckForWin(char[] board, char turn, int spaceCount, int iStart, int iEnd)
    {
        // Count number of tiles user has in a row. 
        int tileCount = 0;

        // Check for a win
        for (int i = iStart; i < iEnd; i += spaceCount)
        {
            // Check to see if the user's tile is on the board at the specified location
            if (board[i] == turn)
            {
                tileCount += 1;
            }

            // If the user has enough tiles in a row it´s a win
            if (tileCount == BoardWidth)
            {
                return true;
            }
        }

        return false;
    }
}










