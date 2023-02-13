namespace TicTacToe
{
    internal class Program
    {
        static char[,] board = new char[,]      //Stores the characters displayed on the board
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };
        static char turn = '1';                 //Defines which player's turn it is. '1' -> player1   '2' -> player2
        static char playAgain = 'y';            /*Defines whether to end a program or not
                                                 *'y' -> yes, I want to play again
                                                 *'n' -> no, I want to end game */
        static string winner = "No winner";
        static void Main(string[] args)
        {
            while(playAgain == 'y')
            {
                StartNewGame();
                while (!IsWinner() && !IsTie())      //while there is no winner -> the game continues
                {
                    Game();
                    RefreshBoard();
                }
                if(winner == "No winner")
                    Console.Write("\nTied! There is no winner. Would you like to play again? [y/n]: ");
                else
                    Console.Write("\n{0} is a winner! Would you like to play again? [y/n]: ", winner);
                char input = Console.ReadKey().KeyChar;
                while (Char.ToLower(input) != 'y' && Char.ToLower(input) != 'n')
                {
                    Console.Write("\nPlease enter a correct value. 'y' for yes or 'n' for no: ");
                    input = Console.ReadKey().KeyChar;
                }
                playAgain = Char.ToLower(input);
            }
        }

        /// <summary>
        /// This method prepares the environment for a new game. Sets board and turn to default
        /// and asks which player starts the game.
        /// </summary>
        static void StartNewGame()
        {
            for (int i = 0; i < 3; i++)        //assigning the board with default values
                for (int j = 0; j < 3; j++)
                    board[i, j] = (char)('0' + i * 3 + j + 1);
            turn = '1';
            winner = "No winner";
            Console.Clear();
            Console.WriteLine("Welcome to the game we are all familiar with - Tic Tac Toe! Player1 is 'O' and player2 is 'X");
            Console.Write("Who wants to start? Please enter 1 for player1 or 2 for player2: ");
            char input;
            input = Console.ReadKey().KeyChar;
            while (input != '1' && input != '2')
            {
                Console.Write("\nPlease enter correct value. 1 for player1 or 2 for player2: ");
                input = Console.ReadKey().KeyChar;
            }
            turn = input;
        }

        /// <summary>
        /// This method prints out the current look of the board
        /// </summary>
        static void RefreshBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0], board[0,1], board[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1,0], board[1,1], board[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2,0], board[2,1], board[2,2]);
            Console.WriteLine("     |     |     ");
        }

        /// <summary>
        /// This method checks whether the field has already been selected
        /// </summary>
        /// <param name="row">The row of the field</param>
        /// <param name="col">The colum of the field</param>
        /// <returns>true if the field has already been selected and false if it has not</returns>
        static bool IsOccupied(int row, int col)
        {
            if (board[row, col] == 'O' || board[row, col] == 'X')
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method checks whether there is a winner or not. Calls method IdentifyWinner() if there is a winner
        /// </summary>
        /// <returns>True if there is a winner and false if there is not</returns>
        static bool IsWinner()
        {
            for(int i=0; i<3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i,1] == board[i, 2])    //horizontal check
                {
                    winner = IdentifyWinner(i, 0);
                    return true;
                }
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])   //vertical check
                {
                    winner = IdentifyWinner(0, i);
                    return true;
                }
            }
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])   //diagonal check
            {
                winner = IdentifyWinner(0, 0);
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winner = IdentifyWinner(0, 2);
                return true;
            }
            winner = "No winner";
            return false;
        }

        /// <summary>
        /// This method checks whether the game ended with a Tie
        /// </summary>
        /// <returns>true if there was a tie or false if there was not</returns>
        static bool IsTie()
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (board[i, j] != 'O' && board[i, j] != 'X')
                        return false;
                }
            }
            winner = "No winner";
            return true;
        }

        /// <summary>
        /// This method decides whether the winner is Player1 or Player2
        /// </summary>
        /// <param name="row">Row of first field of the winning sequence</param>
        /// <param name="col">Column of first field of the winning sequence</param>
        /// <returns>"Player1" if in the first field is 'O', "Player2" if 'X' or "No winner" in other cases</returns>
        static string IdentifyWinner(int row, int col)
        {
            if (board[row, col] == 'O')
                return "Player1";
            else if (board[row, col] == 'X')
                return "Player2";
            else
                return "No winner";
        }

        /// <summary>
        /// This method performs actual game. Allows players to select the field they want.
        /// </summary>
        static void Game()
        {
            RefreshBoard();
            char input;
            int inputRow, inputCol;
            bool isOccupied;
            switch (turn)
            {
                case '1':
                    Console.Write("Player1: Choose your field! ");
                    do
                    {
                        input = Console.ReadKey().KeyChar;
                        while (input < '1' || input > '9')
                        {
                            Console.Write("\nPlease, enter a value between 1 and 9!: ");
                            input = Console.ReadKey().KeyChar;
                        }
                        inputRow = (int)(input - '1') / 3;
                        inputCol = (int)(input - '1') - 3 * inputRow;
                        if(isOccupied = IsOccupied(inputRow, inputCol))
                            Console.WriteLine("\nThis field is occupied! Select another one!");
                    } while (isOccupied);
                    board[inputRow, inputCol] = 'O';
                    turn = '2';
                    break;
                case '2':
                    Console.Write("Player2: Choose your field! ");
                    do
                    {
                        input = Console.ReadKey().KeyChar;
                        while (input < '1' || input > '9')
                        {
                            Console.Write("\nPlease, enter a value between 1 and 9!: ");
                            input = Console.ReadKey().KeyChar;
                        }
                        inputRow = (int)(input - '1') / 3;
                        inputCol = (int)(input - '1') - 3 * inputRow;
                        if (isOccupied = IsOccupied(inputRow, inputCol))
                            Console.WriteLine("\nThis field is occupied! Select another one!");
                    } while (isOccupied);
                    board[inputRow, inputCol] = 'X';
                    turn = '1';
                    break;

            }
        }
    }
}