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
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Area> Areas { get; set; }

        public Region()
        {
            Users = new List<ApplicationUser>();
            Areas = new List<Area>();
        }
    }
}