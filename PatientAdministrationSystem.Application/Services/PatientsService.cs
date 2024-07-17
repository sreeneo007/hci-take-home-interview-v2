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

    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    public async Task<IEnumerable<PatientEntity>> GetAllPatientsAsync()
    {
        return await _repository.GetAllPatientsAsync();
    }

    /// <summary>
    /// Searches for patients based on the provided query string.
    /// </summary>
    /// <param name="searchString">The search query string which can be a patient's first name, last name, or email address.</param>
    /// <returns>A list of patients matching the search criteria.</returns>
    public async Task<IEnumerable<PatientEntity>> SearchPatientsAsync(string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
        {
            return new List<PatientEntity>();
        }

        return await _repository.SearchPatientsAsync(searchString);
    }
    
}