using System.Collections.Generic;
using System.Linq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class EFPrepartionRepository : IPreparationRepository
    {
        EFDbContext context = new EFDbContext();

        public ICollection<Medicament> Medicaments
        {
            get { return context.Medicaments.ToList(); }
        }
    }
}
