using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileLoader.Models
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Area> Areas { get; set; }

        public Region()
        {
            Areas = new List<Area>();
        }
    }
}