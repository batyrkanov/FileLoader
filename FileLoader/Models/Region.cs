using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileLoader.Models
{
    public class Region
    {
        public Guid Id { get; set; }
        [Display(Name = "Наименование области")]
        [RegularExpression(@"^[a-zA-ZЁёӨөҮүҢңА-Яа-я ]+$", ErrorMessage = "Ввод цифр запрещен")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }
        public ICollection<Area> Areas { get; set; }

        public Region()
        {
            Areas = new List<Area>();
        }
    }
}