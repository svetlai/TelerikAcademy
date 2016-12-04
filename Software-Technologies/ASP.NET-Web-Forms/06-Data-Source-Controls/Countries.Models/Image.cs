using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
