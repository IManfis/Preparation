using System.Collections.Generic;
using System.Linq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class EFPrepartionRepository : IPreparationRepository
    {
        readonly EFDbContext _context = new EFDbContext();

        public ICollection<Medicament> Medicaments
        {
            get { return _context.Medicaments.ToList(); }
        }
    }
}
