using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileLoader.Models
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public Area()
        {
            Users = new List<ApplicationUser>();
        }
    }
}