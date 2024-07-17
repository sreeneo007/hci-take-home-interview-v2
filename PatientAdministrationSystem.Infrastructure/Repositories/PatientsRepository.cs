using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Repositories.Interfaces;

namespace PatientAdministrationSystem.Infrastructure.Repositories;

public class PatientsRepository : IPatientsRepository
{
    private readonly HciDataContext _context;

    public PatientsRepository(HciDataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    public async Task<IEnumerable<PatientEntity>> GetAllPatientsAsync()
    {
        return await _context.Patients
             .Include(p => p.PatientHospitals!).ThenInclude(ph => ph.Hospital)
             .Include(p => p.PatientHospitals!).ThenInclude(ph => ph.Visit)
             .ToListAsync();
    }

    /// <summary>
    /// Searches for patients in the database based on the provided query string.
    /// </summary>
    /// <param name="searchString">The search query string which can be a patient's first name, last name, or email address.</param>
    /// <returns>A list of patients matching the search criteria.</returns>
    public async Task<IEnumerable<PatientEntity>> SearchPatientsAsync(string searchString)
    {
        return await _context.Patients
            .Include(p => p.PatientHospitals!).ThenInclude(ph => ph.Hospital)
            .Include(p => p.PatientHospitals!).ThenInclude(ph => ph.Visit)
            .Where(p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString) || p.Email.Contains(searchString))
            .ToListAsync();
    }    
}