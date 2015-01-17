namespace FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class GameLogic
    {
        private const int WindowHeight = 10;
        private const int WindowWidth = 30;
        private const int PlayFieldWidth = WindowWidth;
        private const int LivesCount = 5;
        private const string GameOverMessage = "Game Over";
        private const string PausedMessage = "Paused";
        private static Random random = new Random();

        public static void Main()
        {
            // hide scrollbar and set console width and height
            Console.BufferHeight = Console.WindowHeight = WindowHeight;
            Console.BufferWidth = Console.WindowWidth = WindowWidth;

            ManualResetEvent resetEvent = new ManualResetEvent(false);

            int livesCount = LivesCount;
            int score = 0;
            int chance;
            bool hit;

            char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };

            // create a new instance of a dwarf
            Dwarf dwarf = new Dwarf(PlayFieldWidth / 2, WindowHeight - 1);

            List<Rock> rocks = new List<Rock>();

            // game loop
            while (true)
            {
                hit = false;

                // if key is pressed, get key and move car
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (dwarf.X - 1 >= 0)
                            {
                                dwarf.X--;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (dwarf.X + 1 < PlayFieldWidth)
                            {
                                dwarf.X++;
                            }

                            break;
                        case ConsoleKey.Spacebar:
                            resetEvent.Reset();
                            PrintStringOnPosition((WindowWidth / 2 - GameOverMessage.Length / 2), (WindowHeight / 2 - 1), PausedMessage, ConsoleColor.White);                            
                            Console.ReadKey();
                            resetEvent.Set();
                            break;
                    }
                }

                // create an instance of a rock and add it to the list of rocks - chance added to ensure the number of rocks is not too high
                chance = random.Next(0, 100);
                if (chance > 20)
                {
                    Rock rock = new Rock();
                    rock.X = random.Next(0, PlayFieldWidth);
                    rock.Y = 0;
                    rock.Symbol = rockSymbols[random.Next(0, rockSymbols.Length)];
                    rock.Color = GetRandomLightConsoleColor();
                    rocks.Add(rock);
                }

                // move rocks
                List<Rock> newListOfRocks = new List<Rock>();
                for (int i = 0; i < rocks.Count; i++)
                {
                    Rock oldRock = rocks[i];
                    Rock newRock = new Rock(oldRock.X, oldRock.Y + 1, oldRock.Symbol, oldRock.Color);

                    // if rock collides with dwarf
                    if (newRock.X >= dwarf.X && newRock.X <= dwarf.X + 2 && newRock.Y == dwarf.Y)
                    {
                        hit = true;

                        livesCount--;

                        // game over
                        if (livesCount == 0)
                        {
                            // end game
                            PrintStringOnPosition((WindowWidth / 2 - GameOverMessage.Length / 2 - 1), (WindowHeight / 2 - 1), GameOverMessage, ConsoleColor.White);
                            // reset score
                            score = 0;
                            Console.ReadLine();
                            return;
                        }
                    }

                    if (newRock.Y < WindowHeight)
                    {
                        newListOfRocks.Add(newRock);
                    }
                    else
                    {
                        score += 10;
                    }
                }

                rocks = newListOfRocks;

                // clear the console
                Console.Clear();

                // draw dwarf
                if (hit)
                {
                    rocks.Clear();
                    PrintOnPosition(dwarf.X + 1, dwarf.Y, 'x', ConsoleColor.Red);
                }
                else
                {
                    PrintStringOnPosition(dwarf.X, dwarf.Y, dwarf.Body, dwarf.Color);
                }

                // draw rocks
                foreach (var r in rocks)
                {
                    PrintOnPosition(r.X, r.Y, r.Symbol, r.Color);
                }

                // print game info
                PrintStringOnPosition(WindowWidth - 8, 0, "Lives: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(0, 0, "Score: " + score, ConsoleColor.White);

                // slow game down
                Thread.Sleep(150);
            }
        }

        private static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }

        private static void PrintStringOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        private static ConsoleColor GetRandomLightConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(random.Next(7, consoleColors.Length));
        }
    }
}
