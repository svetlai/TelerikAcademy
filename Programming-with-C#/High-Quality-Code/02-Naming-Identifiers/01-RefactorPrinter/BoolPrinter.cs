namespace RefactorPrinter
{
    using System;

    public class BoolPrinter
    {
        public void PrintBoolean(bool value)
        {
            string toString = value.ToString();
            Console.WriteLine(toString);
        }
    }
}
