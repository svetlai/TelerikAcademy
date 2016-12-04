namespace _5._1.Cars.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Producer
    {
        private ICollection<CarModel> carModels;

        public Producer()
        {
            this.carModels = new HashSet<CarModel>();
        }

        public Producer(string name)
        {
            this.Name = name;
            this.carModels = new HashSet<CarModel>();
        }

        public Producer(string name, ICollection<CarModel> carModels)
        {
            this.Name = name;
            this.CarModels = carModels;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}