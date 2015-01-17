namespace FallingRocks
{
    using System;

    internal struct Rock
    {
        public Rock(int x, int y, char symbol = '*', ConsoleColor color = ConsoleColor.Green)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
            this.Color = color;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public char Symbol { get; set; }

        public ConsoleColor Color { get; set; }
    }
}
