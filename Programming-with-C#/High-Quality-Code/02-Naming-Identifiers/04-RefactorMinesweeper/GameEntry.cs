namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class GameEntry
    {
        public static void Main()
        {
            string command = string.Empty;
            char[,] playingField = DrawField();
            char[,] mines = SetMnes();
            int counter = 0;
            bool isMineClicked = false;
            List<PlayerScore> highScorePlayers = new List<PlayerScore>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            const int MaxCells = 35;
            bool isMaxCells = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Start playing \"Minesweeper\". Try to find fields without mines." +
                    " Commands:\n -'top' shows rating;\n -'restart' start new game;\n -'exit' close program!");
                    UpdatePlayingField(playingField);
                    isNewGame = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playingField.GetLength(0) && column <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rate(highScorePlayers);
                        break;
                    case "restart":
                        playingField = DrawField();
                        mines = SetMnes();
                        UpdatePlayingField(playingField);
                        isMineClicked = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                Turn(playingField, mines, row, column);
                                counter++;
                            }

                            if (MaxCells == counter)
                            {
                                isMaxCells = true;
                            }
                            else
                            {
                                UpdatePlayingField(playingField);
                            }
                        }
                        else
                        {
                            isMineClicked = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isMineClicked)
                {
                    UpdatePlayingField(mines);
                    Console.Write("\nGame over with {0} scores. Enter your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    PlayerScore playerScore = new PlayerScore(nickname, counter);

                    if (highScorePlayers.Count < 5)
                    {
                        highScorePlayers.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScorePlayers.Count; i++)
                        {
                            if (highScorePlayers[i].Score < playerScore.Score)
                            {
                                highScorePlayers.Insert(i, playerScore);
                                highScorePlayers.RemoveAt(highScorePlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    highScorePlayers.Sort((PlayerScore ps1, PlayerScore ps2) => ps2.Name.CompareTo(ps1.Name));
                    highScorePlayers.Sort((PlayerScore ps1, PlayerScore ps2) => ps2.Score.CompareTo(ps1.Score));
                    Rate(highScorePlayers);

                    playingField = DrawField();
                    mines = SetMnes();
                    counter = 0;
                    isMineClicked = false;
                    isNewGame = true;
                }

                if (isMaxCells)
                {
                    Console.WriteLine("\nCongratulations! You open 35 cells and win.");
                    UpdatePlayingField(mines);
                    Console.WriteLine("Enter your nickname: ");
                    string playerName = Console.ReadLine();
                    PlayerScore score = new PlayerScore(playerName, counter);
                    highScorePlayers.Add(score);
                    Rate(highScorePlayers);
                    playingField = DrawField();
                    mines = SetMnes();
                    counter = 0;
                    isMaxCells = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void Rate(List<PlayerScore> scores)
        {
            Console.WriteLine("\nScores:");

            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, scores[i].Name, scores[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No high-scores yet.\n");
            }
        }

        private static void Turn(char[,] field, char[,] mines, int row, int column)
        {
            char numberOfMines = SetNumberOfMines(mines, row, column);
            mines[row, column] = numberOfMines;
            field[row, column] = numberOfMines;
        }

        private static void UpdatePlayingField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] DrawField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetMnes()
        {
            int rows = 5;
            int columns = 10;
            char[,] playingField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);

                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);
                }
            }

            foreach (int num in randomNumbers)
            {
                int column = num / columns;
                int row = num % columns;

                if (row == 0 && num != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                playingField[column, row - 1] = '*';
            }

            return playingField;
        }

        private static void CalcMinesCount(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesCount = SetNumberOfMines(field, i, j);
                        field[i, j] = minesCount;
                    }
                }
            }
        }

        private static char SetNumberOfMines(char[,] cell, int row, int column)
        {
            int count = 0;
            int rows = cell.GetLength(0);
            int columns = cell.GetLength(1);

            if (row - 1 >= 0)
            {
                if (cell[row - 1, column] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (cell[row + 1, column] == '*')
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (cell[row, column - 1] == '*')
                {
                    count++;
                }
            }

            if (column + 1 < columns)
            {
                if (cell[row, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (cell[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (cell[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (cell[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (cell[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
