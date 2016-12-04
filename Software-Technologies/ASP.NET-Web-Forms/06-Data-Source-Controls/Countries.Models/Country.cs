namespace Countries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        private ICollection<Town> towns;
        private ICollection<Image> images;

        public Country()
        {
            this.towns = new HashSet<Town>();
            this.images = new HashSet<Image>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public long Population { get; set; }

        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual ICollection<Town> Towns
        {
            get
            {
                return this.towns;
            }
            set
            {
                this.towns = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}
