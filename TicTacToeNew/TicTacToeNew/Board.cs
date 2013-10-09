using System;

class Board 
{
    int BoardWidth { get; set; }
    int BoardSize { get; set; }

    //Constructor that gets the size and width of the board to use in drawing the board
    public Board(int boardSize,int boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }
    public void DrawBoard(char[] board, bool onlyNums)
    {
        Program p = new Program();
        // Used to create the rows
        int rowCount = 0;

        Console.WriteLine("\n\n");

        // Loop through board pieces and draw what´s is in each slot
        for (int i = 0; i < BoardSize; i++)
        {
            // Draw whats one the board at this place
            if (onlyNums)
            {
                // Display board number
                Console.Write(i);

                // if it's not the last item on the row add a separator bar
                if (rowCount < (BoardWidth))
                {
                    if (i < 10)
                        Console.Write("  |  ");
                    else
                        Console.Write(" |  ");
                }
            }
            else    
            {   //Board without numbers
                // Display the X, O, or ampty from the board
                Console.Write(board[i]);

                // if it's not the last item on the row, add a separator bar
                if (rowCount < (BoardWidth))
                {
                    if (i < 10)
                        Console.Write(" | ");
                    else
                        Console.Write(" | ");
                }
            }

            // Keeps track of how many items are on this row
            rowCount++;

            // if this row is long enough one row is created
            if (rowCount == BoardWidth)
            {
                
                Console.WriteLine(); 

                // determine how many hyphens there should be for the separator bar, based
                // on whether we're showing the number board or the actual tictactoe board.
                int actualWidth;
                if (onlyNums)
                    actualWidth = BoardWidth * 5;
                else
                    actualWidth = BoardWidth * 3;

                // draw the separator bar
                for (int line = 0; line <= actualWidth + 2; line++)
                    Console.Write("-");

                
                Console.WriteLine();

                // reset the row count
                rowCount = 0;
            }
        }

        Console.WriteLine("\n\n");
    }

}

