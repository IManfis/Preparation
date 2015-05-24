using System;
using System.Collections.Generic;
using System.Linq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class PreparationStore : IPreparationStore
    {

        private readonly IPreparationRepository _repository;
        private EFDbContext context = new EFDbContext();

        public PreparationStore(IPreparationRepository repository)
        {
            _repository = repository;
        }

        public List<Medicament> GetAll()
        {
            return _repository.Medicaments.ToList();
        }

        public Medicament Get(int id)
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
                    break;
                case "ReleaseForm":
                    return _repository.Medicaments.Where(p => p.ReleaseForm == value).OrderBy(p => p.ID).ToList();
                    break;
                case "ActionSubstance":
                    return _repository.Medicaments.Where(p => p.ActiveSubstance == value).OrderBy(p => p.ID).ToList();
                    break;
                default:
                    return _repository.Medicaments.OrderBy(p => p.ID).ToList();
                    break;
            }
        }

        public void Save(Medicament medicament)
        {
            if (medicament.ID == 0)
            {
                context.Medicaments.Add(medicament);
            }
            else
            {
                Medicament dbEntry = context.Medicaments.First(p => p.ID == medicament.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = medicament.Name;
                    dbEntry.Anotation = medicament.Anotation;
                    dbEntry.Image = medicament.Name;
                    dbEntry.ActiveSubstance = medicament.ActiveSubstance;
                    dbEntry.Producer = medicament.Producer;
                    dbEntry.ReleaseForm = medicament.ReleaseForm;
                }
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Medicament dbEntry = context.Medicaments.Find(id);
            if (dbEntry != null)
            {
                context.Medicaments.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}