 /* TODO:
  * 1. 9 fields - player1 can choose a field then player2 and and so forth
  * 2. If chosen field is already occupied then the player should be able to choose again
  * 3. Message if input is incorrect
  * 4. Check if there is a winner
  * 5. Reset functionality
 */


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
        static void Main(string[] args)
        {
            while(playAgain == 'y')
            {
                StartNewGame();
                /*while ()      //while there is no winner -> the game continues
                { 
                    
                }*/

                Console.Write("\nSomeone is a winner! Would you like to play again? [y/n]: ");
                char input = Console.ReadKey().KeyChar;
                while (Char.ToLower(input) != 'y' && Char.ToLower(input) != 'n')
                {
                    Console.Write("\nPlease enter a correct value. 'y' for yes or 'n' for no: ");
                    input = Console.ReadKey().KeyChar;
                }
                playAgain = Char.ToLower(input);
            }
        }

        static void StartNewGame()
        {
            for (int i = 0; i < 3; i++)        //assigning the board with default values
                for (int j = 0; j < 3; j++)
                    board[i, j] = (char)('0' + i * 3 + j + 1);
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
    }
}