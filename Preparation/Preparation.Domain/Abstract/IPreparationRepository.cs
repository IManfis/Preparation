using System.Collections.Generic;
using Preparation.Domain.Entities;

namespace Preparation.Domain.Abstract
{
    public interface IPreparationRepository
    {
        ICollection<Medicament> Medicaments { get; }  
    }
}