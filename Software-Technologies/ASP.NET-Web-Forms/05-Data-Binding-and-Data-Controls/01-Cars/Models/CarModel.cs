namespace _5._1.Cars.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CarModel
    {
        public CarModel()
        {
        }

        public CarModel(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}