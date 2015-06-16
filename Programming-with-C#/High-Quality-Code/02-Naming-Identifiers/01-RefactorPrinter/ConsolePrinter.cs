namespace RefactorPrinter
{
    using System;

    public class ConsolePrinter
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            BoolPrinter printer = new BoolPrinter();
            printer.PrintBoolean(true);
        }
    }
}
