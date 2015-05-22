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



        public Medicament(string Name, string Anotation, string Image, string ActiveSubstance, string Producer, string ReleaseForm)
        {
            this.Name = Name;
            this.Anotation = Anotation;
            this.Image = Image;
            this.ActiveSubstance = ActiveSubstance;
            this.Producer = Producer;
            this.ReleaseForm = ReleaseForm;
        }
        public Medicament() { }
    }
}
