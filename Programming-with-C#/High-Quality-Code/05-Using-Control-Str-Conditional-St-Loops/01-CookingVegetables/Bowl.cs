namespace CookingVegetables
{
    using System.Collections.Generic;
    using System.Text;

    public class Bowl
    {
        private List<Vegetable> ingredients;

        public Bowl()
        {
            this.ingredients = new List<Vegetable>();
        }

        public void Add(Vegetable vegetable)
        {
            this.ingredients.Add(vegetable);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Bowl full of: ");

            for (int i = 0; i < this.ingredients.Count; i++)
            {
                sb.AppendLine(this.ingredients[i].ToString());
            }

            return sb.ToString();
        }
    }
}
