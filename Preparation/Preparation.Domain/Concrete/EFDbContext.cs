using System.Data.Entity;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; } 
    }
}