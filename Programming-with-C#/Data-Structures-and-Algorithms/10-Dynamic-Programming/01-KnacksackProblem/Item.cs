namespace Knacksack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Item
    {
        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = value;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Cost { get; private set; }
    }
}
