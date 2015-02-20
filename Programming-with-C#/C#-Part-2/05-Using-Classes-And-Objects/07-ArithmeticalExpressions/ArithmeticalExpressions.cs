namespace ArithmeticalExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Problem 7.* Arithmetical expressions
    /// Write a program that calculates the value of given arithmetical expression.
    /// The expression can contain the following elements only:
    /// Real numbers, e.g. `5`, `18.33`, `3.14159`, `12.6`
    /// Arithmetic operators: `+`, `-`, `*`, `/` (standard priorities)
    /// Mathematical functions: `ln(x)`, `sqrt(x)`, `pow(x,y)`
    /// Brackets (for changing the default priorities): `(`, `)`
    /// Examples:
    /// |                        input                       | output |
    /// |----------------------------------------------------|--------|
    /// | (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)            | ~10.6  |
    /// | pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) | ~21.22 |
    /// Hint: Use the classical [Shunting-yard algorithm](http://en.wikipedia.org/wiki/Shunting-yard_algorithm) and [Reverse Polish notation](http://en.wikipedia.org/wiki/Reverse_Polish_notation).
    /// </summary>
    public class ArithmeticalExpressions
    {
        public static void Main()
        {
            // TODO
        }
    }
}
