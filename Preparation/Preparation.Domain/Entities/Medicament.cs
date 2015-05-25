using System.ComponentModel.DataAnnotations;

namespace Preparation.Domain.Entities
{
    public class Medicament
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Anotation { get; set; }

        public string Image { get; set; }

        public string ActiveSubstance { get; set; }

        public string Producer { get; set; }

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
