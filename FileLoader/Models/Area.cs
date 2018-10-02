using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileLoader.Models
{
    public class Area
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Район")]
        [RegularExpression(@"^[a-zA-ZЁёӨөҮүҢңА-Яа-я ]+$", ErrorMessage = "Ввод цифр запрещен")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
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