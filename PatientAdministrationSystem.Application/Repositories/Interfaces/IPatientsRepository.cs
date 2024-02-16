using System.Linq.Expressions;
using PatientAdministrationSystem.Application.Entities;

namespace PatientAdministrationSystem.Application.Repositories.Interfaces;

public interface IPatientsRepository
{
    // Add interfaces here for your repository methods
    public Task<ICollection<PatientEntity>> SearchPatientsAsync(
        Expression<Func<PatientEntity, bool>> constraint, bool trackChanges = false);
}