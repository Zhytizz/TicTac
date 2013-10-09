using System;

class Program
{
        
    const char player1 = 'X';//Constants to store the mark
    const char player2 = 'O';//of player 1 and 2
    const char empty = ' '; //Char to empty the boarditems
    int boardWidth = 3;
    int boardSize = 9;
    

    static int Main(string[] args)
    {
        Program p = new Program();
        char gameOn = 'y';//keeps track if game is ongoing
        int input;//variable to keep track of players choice of boardsize


        while (gameOn == 'y')
        {
            // get the size of the board that the user wants
            Console.Write("\nWelcome to Tic-Tac-Toe!\n\n");
            Console.Write("1. 3x3 (Standard)\n");
            Console.Write("2. 5x5\n");
            Console.Write("\nWhat size do you want on the board? (3 or 5): ");

            input = Convert.ToInt32(Console.ReadLine());

            // set the board size, based on the user's input
            if (input == 3 || input == 5)
            {
                p.boardWidth = input;
                p.boardSize = p.boardWidth * p.boardWidth;
            }
            else
            {
                Console.WriteLine("\nYou entered an invalid size!Try again! \n\n");
                continue;
                   
            }

           

            // Array for the board
            char[] board = new char[p.boardSize];

            // Set all of the board items to empty
            for (int i = 0; i < p.boardSize; i++)
                board[i] = empty;

            bool win = false;
            int size = p.boardSize;//Varibles for the boardssize to pass as parameters in methodcallings
            int width = p.boardWidth;//pass as parameters in methodcallings

            Console.WriteLine("\nChoose opponent\n");
            Console.WriteLine("1. Human opponent");
            Console.WriteLine("2. Computer ");
            int chosenOpponent = int.Parse(Console.ReadLine());//Player input if they want to play 
                                                                //against another human or the computerplayer
               
            // Draw the board
            Console.WriteLine();
            Console.Write(@"The board looks like this and you choose your position by entering the number
            representing the position you want:");
            Player play = new Player(size,width);
            Board b = new Board(size, width);
            ComputerPlayer cp = new ComputerPlayer(size,width);
            // reset moveCount
            play.moveCount = 0;
            b.DrawBoard(board, true);
            Console.WriteLine("\n\n");

            while (win == false)//While there is no winner
            {
                // Ask player1 for a move
                play.AskForMove(board,player1);

                // Draw the board
                b.DrawBoard(board, false);
                    
                    

                // Check to see if player 1 has won
                win = false;
                win = play.IsWinner(board, player1, size);
                if (win == true)
                {
                    Console.WriteLine("\n\nPlayer X has won!\n\n");
                    break;
                }

                // Check for a draw
                if (play.IsDraw())
                {
                    Console.WriteLine("\n\nIt's a draw!\n\n");
                    break;
                }

                // Ask player2 for a move 
                if (chosenOpponent == 2 && input == 3)//If player wanted computer opponent and a 3x3board
                    cp.AskForComputerMoveThree(board,player2);

                else if (chosenOpponent == 2 && input == 5)//If player wanted computer opponent and a 5x5 board
                    cp.AskForComputerMoveFive(board, player2);

                else
                    play.AskForMove(board, player2);//If player wanted human opponent

                // Draw board again
                b.DrawBoard(board, false);

                // Check to see if player 2 has won
                win = false;
                win = play.IsWinner(board, player2, size);
                if (win == true)
                {
                    Console.Write("\n\nPlayer O has won!\n\n");
                    break;
                }

                // Check for a draw again
                if (play.IsDraw())
                {
                    Console.Write("\n\nIt's a draw!\n\n");
                    break;
                }
            }

            // Ask if player want to play again
            Console.WriteLine("\n\nWould you like to play again? (y/n): ");
            gameOn = Convert.ToChar(Console.ReadLine());

            //If the player don´t want to play again exit the application else start new game
            if (gameOn == 'n')
                Environment.Exit(0);
               
            else
                continue;
            Console.ReadKey();
        }

        return 0;

    }
}


