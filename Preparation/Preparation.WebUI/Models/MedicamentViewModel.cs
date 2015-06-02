using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Preparation.Domain.Entities;

namespace Preparation.WebUI.Models
{
    public class MedicamentViewModel
    {
        public IEnumerable<Medicament> Medicaments { get; set; } 

        public int ID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название препарата")]
        [RegularExpression(@"^[(A-z)\(А-я)\(ё)\(Ё)\s]+$", ErrorMessage = "Введите только буквы")]
        [Display(Name = "Название препарата")]
        public string Name { get; set; }

        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Пожалуйста, введите краткое описание")]
        public string Anotation { get; set; }

        [Display(Name = "Изображение упаковки")]
        [Required(ErrorMessage = "Пожалуйста, выберите изображение")]
        public string Image { get; set; }

        [Display(Name = "Состав")]
        [Required(ErrorMessage = "Пожалуйста, введите состав")]
        public string ActiveSubstance { get; set; }

        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Пожалуйста, введите производителя")]
        public string Producer { get; set; }

        [Display(Name = "Форма выпуска")]
        [Required(ErrorMessage = "Пожалуйста, введите форму выпуска")]
        public string ReleaseForm { get; set; }
    }
}