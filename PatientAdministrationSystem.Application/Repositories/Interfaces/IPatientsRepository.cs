using System.Linq.Expressions;
using PatientAdministrationSystem.Application.Entities;

namespace PatientAdministrationSystem.Application.Repositories.Interfaces;

public interface IPatientsRepository
{

    /// <summary>
    /// Searches for patients in the database based on the provided query string.
    /// </summary>
    /// <param name="searchString">The search query string which can be a patient's first name, last name, or email address.</param>
    /// <returns>A list of patients matching the search criteria.</returns>
    Task<IEnumerable<PatientEntity>> GetAllPatientsAsync();

    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    /// 
    Task<IEnumerable<PatientEntity>> SearchPatientsAsync(string searchString);

}