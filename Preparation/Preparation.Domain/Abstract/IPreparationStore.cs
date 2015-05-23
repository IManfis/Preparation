using System.Collections.Generic;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Abstract
{
    public interface IPreparationStore
    {
        List<Medicament> GetAll();

        Medicament Get(int id);

        List<Medicament> FilterMedicaments(string filter,string value);
    }
}