namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste, IProduct
    {
        private const int MinIngredientLength = 4;
        private const int MaxIngredientLength = 12;

        private const string IngredientsProperty = "Ingredients";
        private const string IngredientsLengthExcMsg = "Each ingredient must be between {0} and {1} symbols long!";

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredientsList)
            : base(name, brand, price, gender)
        {
            this.SetIngredients(ingredientsList);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.Append(base.Print())
                .AppendFormat("  * Ingredients: {0}", this.Ingredients);

            return sb.ToString();
        }

        private void SetIngredients(IList<string> ingredientsList)
        {
            Validator.CheckIfNull(ingredientsList, string.Format(GlobalErrorMessages.ObjectCannotBeNull, IngredientsProperty));

            foreach (var ingredient in ingredientsList)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientLength, MinIngredientLength, string.Format(IngredientsLengthExcMsg, MinIngredientLength, MaxIngredientLength));
            }

            this.ingredients = string.Join(", ", ingredientsList);
        }
    }
}
