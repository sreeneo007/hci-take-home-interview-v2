using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Repositories.Interfaces;

namespace PatientAdministrationSystem.Application.Interfaces;

public interface IPatientsService
{

    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    Task<IEnumerable<PatientEntity>> GetAllPatientsAsync();

    /// <summary>
    /// Searches for patients based on the provided query string.
    /// </summary>
    /// <param name="searchString">The search query string which can be a patient's first name, last name, or email address.</param>
    /// <returns>A list of patients matching the search criteria.</returns>
    Task<IEnumerable<PatientEntity>> SearchPatientsAsync(string searchString);

}