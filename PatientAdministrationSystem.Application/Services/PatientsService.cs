using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Interfaces;
using PatientAdministrationSystem.Application.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PatientAdministrationSystem.Application.Services;

public class PatientsService : IPatientsService
{
    private readonly IPatientsRepository _repository;

    public PatientsService(IPatientsRepository repository)
    {
        _repository = repository;
    }

    // Define your patient search logic here based on the interface method definition

    public async Task<string> SearchPatientsAsync(string? search = null)
    {
        Expression<Func<PatientEntity, bool>> constraint = p => true;

        if (!string.IsNullOrEmpty(search))
            constraint = p => p.Email.Contains(search) || p.FirstName.Contains(search) || p.LastName.Contains(search);

        var entities = await _repository.SearchPatientsAsync(constraint, false);

        string s = "[" + string.Join(", ", entities
                     .Select(i => i.FirstName.ToString()).ToArray()) + "]";

        return s;
    }
}