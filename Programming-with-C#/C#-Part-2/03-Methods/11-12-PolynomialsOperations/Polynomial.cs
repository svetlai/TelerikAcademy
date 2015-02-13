namespace Polynomials
{
    using System;

    /// <summary>
    /// ax^2 + bx + c
    /// </summary>
    public class Polynomial
    {
        private int[] coefficients;

        public Polynomial()
            : this(new int[] { 0 })
        {
        }

        /// <summary>
        /// Create an instance of a polynomial
        /// </summary>
        /// <param name="coefficients">An integer array of the polynom's coefficients, starting from x^0. Example: ax^2 + bx + c --> { c, b, a };</param>
        public Polynomial(int[] coefficients)
        {
            this.Coefficients = coefficients;
        }

        // ax^2 + bx + c --> { c, b, a };
        public int[] Coefficients
        {
            get
            {
                return this.coefficients;
            }

            private set
            {
                this.coefficients = value;
            }
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int[] longest = first.Coefficients.Length > second.Coefficients.Length ? first.Coefficients : second.Coefficients;
            int[] shortest = first.Coefficients.Length > second.Coefficients.Length ? second.Coefficients : first.Coefficients;

            Array.Resize(ref shortest, longest.Length);

            int[] resultCoefficients = new int[longest.Length];

            Polynomial result = new Polynomial(resultCoefficients);

            for (int i = 0; i < longest.Length; i++)
            {
                result.Coefficients[i] = longest[i] + shortest[i];
            }

            return result;
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            int maxLen = Math.Max(first.Coefficients.Length, second.Coefficients.Length);
            
            int[] firstCoefficients = first.Coefficients;
            int[] secondCoefficients = second.Coefficients;

            if (first.Coefficients.Length > second.Coefficients.Length)
            {
                Array.Resize(ref secondCoefficients, firstCoefficients.Length);
            }
            else
            {
                Array.Resize(ref firstCoefficients, secondCoefficients.Length);
            }

            int[] resultCoefficients = new int[maxLen];

            Polynomial result = new Polynomial(resultCoefficients);

            for (int i = 0; i < maxLen; i++)
            {
                result.Coefficients[i] = firstCoefficients[i] - secondCoefficients[i];
            }

            return result;
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int[] longest = first.Coefficients.Length > second.Coefficients.Length ? first.Coefficients : second.Coefficients;
            int[] shortest = first.Coefficients.Length > second.Coefficients.Length ? second.Coefficients : first.Coefficients;

            Array.Resize(ref shortest, longest.Length);

            int[] resultCoefficients = new int[longest.Length];

            Polynomial result = new Polynomial(resultCoefficients);

            for (int i = 0; i < longest.Length; i++)
            {
                result.Coefficients[i] = longest[i] * shortest[i];
            }

            return result;
        }

        public override string ToString()
        {
            int degree = this.Coefficients.Length - 1;
            string result = string.Empty;

            for (int i = this.Coefficients.Length - 1; i >= 0; i--)
            {
                if (this.Coefficients[i] != 0)
                {
                    result += this.Coefficients[i];

                    if (i > 0)
                    {
                        result += "x";

                        if (degree > 1)
                        {
                            result += "^" + degree;
                        }

                        result += " + ";
                    }
                }

                degree--;
            }

            return result;
        }
    }
}
