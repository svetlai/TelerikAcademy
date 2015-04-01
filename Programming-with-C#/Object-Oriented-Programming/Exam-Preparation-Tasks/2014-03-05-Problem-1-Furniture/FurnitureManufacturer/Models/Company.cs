namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private const string EmptyNameExcMsg = "Name cannot be null or empty.";
        private const string NameLengthExcMsg = "Name cannot be less than 5 characters.";
        private const string EmptyRegNumExcMsg = "Registration number cannot be null or empty.";
        private const string RegNumLengthExcMsg = "Registration number must be exactly 10 characters long.";
        private const string RegNumDigitsExcMsg = "Registration number must contain only digits.";
        private const string FurnitureListNullExcMsg = "List of furniture cannot be null.";
        private const string FurnitureNullExcMsg = "Furniture cannot be null.";
        private const string NoFurnitureInListExcMsg = "The list of furniture does not contain this exact piece.";
        
        private readonly ICollection<IFurniture> furnitures;
        
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExcMsg);
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException(NameLengthExcMsg);
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyRegNumExcMsg);
                }

                if (value.Length != 10)
                {
                    throw new ArgumentException(RegNumLengthExcMsg);
                }

                foreach (var symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException(RegNumDigitsExcMsg);
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException(FurnitureNullExcMsg);
            }

            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException(FurnitureNullExcMsg);
            }

            // if (!this.Furnitures.Contains(furniture))
            // {
            //     throw new ArgumentNullException(NoFurnitureInListExcMsg);
            // }

            this.furnitures.Remove(furniture);         
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(m => m.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            if (this.Furnitures.Count > 0)
            {
                var sorted = this.Furnitures
                    .OrderBy(f => f.Price)
                    .ThenBy(f => f.Model);

                foreach (var furniture in sorted)
                {
                    result.AppendLine(furniture.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
