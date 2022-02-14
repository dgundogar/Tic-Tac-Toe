using System;

namespace Collections
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int turn = 0, counter = 0;
            string selection, symbol = "X";
            string[] selectedArray = new string[10];
            string [,] matrix1 =
                {
                    { "1","2","3"},
                    { "4","5","6"},
                    { "7","8","9"}
               };

            displayAll(matrix1);

            while (ChecksWinner(matrix1) == false && counter <= 9)
                {
                    if (turn == 0)
                    {
                        Console.WriteLine("\nPlayer 1: Choose your field!");
                        selection = Console.ReadLine();
                        if(NumberChecker(selection) == true && IsFirst(selectedArray, selection) == true)
                        {
                            symbol = "O";
                            board(matrix1, selection, symbol);
                            turn = 1;
                            selectedArray[counter] = selection;
                            counter++;

                        }
                        else
                        {
                            Console.WriteLine("Enter a number between 0 and 9! ");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 2: Choose your field!");
                        selection = Console.ReadLine();
                        if (NumberChecker(selection) == true && IsFirst(selectedArray, selection) == true)
                        {
                            symbol = "X";
                            board(matrix1, selection, symbol);
                            turn = 0;
                            selectedArray[counter] = selection;
                            counter++;
                    }
                        else
                        {
                            Console.WriteLine("Enter a different place and a number between 0 and 9! ");
                        }
                        
                    }
                Console.WriteLine();
                displayAll(matrix1);
                }

            displayAll(matrix1);
            Console.WriteLine("Congratulations!");


        }

        // displays board
        public static void displayAll(string[,] matrix1)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                Console.WriteLine("   |   |   \n {0} | {1} | {2} \n___|___|___", matrix1[i, 0], matrix1[i, 1], matrix1[i, 2]);
            }
        }

        // changes the player's selected part
        public static void board(string[,] matrix1, string selection, string symbol)
        {
            switch (selection)
            {
                case "1":
                    matrix1[0, 0] = symbol;
                    break;
                case "2":
                    matrix1[0, 1] = symbol;
                    break;
                case "3":
                    matrix1[0, 2] = symbol;
                    break;
                case "4":
                    matrix1[1, 0] = symbol;
                    break;
                case "5":
                    matrix1[1, 1] = symbol;
                    break;
                case "6":
                    matrix1[1, 2] = symbol;
                    break;
                case "7":
                    matrix1[2, 0] = symbol;
                    break;
                case "8":
                    matrix1[2, 1] = symbol;
                    break;
                case "9":
                    matrix1[2, 2] = symbol;
                    break;
            }
        }


        // checks if the input is a valid number or not 
        public static bool NumberChecker(string selection)
        {
            int numericValue;
            bool isNumber = int.TryParse(selection, out numericValue);
            if (isNumber == true)
            {
                if(numericValue >= 0 && numericValue <= 9)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool ChecksWinner(string[,] matrix1)
        {
            for(int i = 0; i < 3; i++)
            {
                if(matrix1[i, 0].Equals(matrix1[i, 1]) && matrix1[i, 0].Equals(matrix1[i, 2]))
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (matrix1[0, i].Equals(matrix1[1, i]) && matrix1[0, i].Equals(matrix1[2, i]))
                {
                    return true;
                }
            }

            if ((matrix1[1, 1].Equals(matrix1[0, 0]) == true) && matrix1[0, 0].Equals(matrix1[2, 2]))
            {
                return true;
            }

            return false;

        }

        public static bool IsFirst(string[] selectedArray, string selection)
        {
            foreach(string c in selectedArray)
            {
                if (selection.Equals(c))
                {
                    return false;
                }
               
            }

            return true;
        }

    }
}
 