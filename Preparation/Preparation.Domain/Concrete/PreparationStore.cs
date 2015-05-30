using System.Collections.Generic;
using System.Linq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class PreparationStore : IPreparationStore
    {
        private readonly IPreparationRepository _repository;
        private readonly EFDbContext _context = new EFDbContext();

        public PreparationStore(IPreparationRepository repository)
        {
            _repository = repository;
        }

        public List<Medicament> GetAll()
        {
            return _repository.Medicaments.ToList();
        }

        public Medicament GetById(int id)
        {
            Medicament modelMedicament = null;
            foreach (var item in _repository.Medicaments.Where(p => p.ID == id))
            {
                modelMedicament = new Medicament
                {
                    Name = item.Name,
                    ActiveSubstance = item.ActiveSubstance, 
                    Anotation = item.Anotation,
                    Image = item.Image,
                    Producer = item.Producer,
                    ReleaseForm = item.ReleaseForm
                };
            }
            return (modelMedicament);
        }

        public List<Medicament> FilterMedicaments(string filter, string value)
        {
            switch (filter)
            {
                case "Producer":
                   return _repository.Medicaments.Where(p => value == null || p.Producer == value).OrderBy(p => p.ID).ToList();
                case "ReleaseForm":
                    return _repository.Medicaments.Where(p => p.ReleaseForm == value).OrderBy(p => p.ID).ToList();
                case "ActionSubstance":
                    return _repository.Medicaments.Where(p => p.ActiveSubstance == value).OrderBy(p => p.ID).ToList();
                default:
                    return _repository.Medicaments.OrderBy(p => p.ID).ToList();
            }
        }

        public void Save(Medicament medicament)
        {
            if (medicament.ID == 0)
            {
                _context.Medicaments.Add(medicament);
            }
            else
            {
                Medicament dbEntry = _context.Medicaments.First(p => p.ID == medicament.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = medicament.Name;
                    dbEntry.Anotation = medicament.Anotation;
                    dbEntry.Image = medicament.Image;
                    dbEntry.ActiveSubstance = medicament.ActiveSubstance;
                    dbEntry.Producer = medicament.Producer;
                    dbEntry.ReleaseForm = medicament.ReleaseForm;
                }
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Medicament dbEntry = _context.Medicaments.Find(id);
            if (dbEntry != null)
            {
                _context.Medicaments.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}