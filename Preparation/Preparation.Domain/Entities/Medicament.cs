using System.ComponentModel.DataAnnotations;

namespace Preparation.Domain.Entities
{
    public class Medicament
    {
        public int ID { get; set; }

        [Display(Name = "Название препарата")]
        [Required(ErrorMessage = "Пожалуйста, введите название препарата")]
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


        public Medicament(string name, string anotation, string image, string activeSubstance, string producer, string releaseForm)
        {
            this.Name = name;
            this.Anotation = anotation;
            this.Image = image;
            this.ActiveSubstance = activeSubstance;
            this.Producer = producer;
            this.ReleaseForm = releaseForm;
        }
        public Medicament() { }
    }
}
