using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileLoader.Models
{
    public class Region
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Область")]
        [RegularExpression(@"^[a-zA-ZЁёӨөҮүҢңА-Яа-я ]+$", ErrorMessage = "Ввод цифр запрещен")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
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