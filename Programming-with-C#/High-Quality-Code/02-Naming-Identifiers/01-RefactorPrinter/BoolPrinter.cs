namespace RefactorPrinter
{
    using System;

    internal class BoolPrinter
    {
        public void PrintBoolean(bool value)
        {
            string toString = value.ToString();
            Console.WriteLine(toString);
        }
    }
}
