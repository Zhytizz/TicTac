using System;

class ComputerPlayer : Player
{
    
    
    public ComputerPlayer(int boardSize, int boardWidth)  : base(boardSize, boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }

    //Method that asks the computerplayer for a move in 3x3 game
    public int AskForComputerMoveThree(char[] board, char turn)
    {
        Random rnd = new Random();
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = rnd.Next(0, 8);//Random number for where the computer wan´t to place it´s marker

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                //New random number to pick a new location if space is occupied or invalid
                input = rnd.Next(0, 8);
            }
            else
                break;
        }

        return input;
    }

    //Method that asks the computerplayer for a move in 5x5 game
    public int AskForComputerMoveFive(char[] board, char turn)
    {
        Random rnd = new Random();
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = rnd.Next(0, 24);

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                input = rnd.Next(0, 24);
            }
            else
                break;
        }

        return input;
    }

    new public bool MakeMove(char[] board, char turn, int move)
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

    
    }



