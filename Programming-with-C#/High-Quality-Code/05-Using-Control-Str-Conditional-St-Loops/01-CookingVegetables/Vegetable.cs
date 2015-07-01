namespace CookingVegetables
{
    using System;
    using System.Text;

    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsNotRotten = true;
        }

        public bool IsPeeled { get; set; }

        public bool IsNotRotten { get; set; }

        public bool IsCut { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsPeeled)
            {
                sb.Append("Peeled ");
            }

            if (IsCut)
            {
                sb.Append("Cut ");
            }

            if (!IsNotRotten)
            {
                sb.Append("Rotten ");
            }

            return sb.ToString();
        }
    }
}
