using System.Collections.Generic;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Abstract
{
    public interface IPreparationStore
    {
        List<Medicament> GetAll();

        Medicament GetById(int id);

        List<Medicament> FilterMedicaments(string filter,string value);

        void Save(Medicament medicament);

        void Delete(int id);
    }
}