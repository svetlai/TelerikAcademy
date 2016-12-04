using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Models
{
    public class Town
    {
        public Town()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public long Population { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
