using System.Collections.Generic;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class EFPrepartionRepository : IPreparationRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Medicament> Medicaments
        {
            get { return context.Medicaments; }
        }
    }
}
