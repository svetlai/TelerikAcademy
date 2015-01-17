namespace FallingRocks
{
    using System;

    internal struct Dwarf
    {
        public Dwarf(int x, int y, string body = "(0)", ConsoleColor color = ConsoleColor.Yellow)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Body = body;
            this.Color = color;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Body { get; set; }

        public ConsoleColor Color { get; set; }
    }
}
