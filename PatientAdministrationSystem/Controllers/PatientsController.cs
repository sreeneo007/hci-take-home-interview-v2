using Microsoft.AspNetCore.Mvc;
using PatientAdministrationSystem.Application.Interfaces;
using PatientAdministrationSystem.Application.Services;
using System.ComponentModel.DataAnnotations;

namespace Hci.Ah.Home.Api.Gateway.Controllers.Patients;

[Route("api/patients")]
[ApiExplorerSettings(GroupName = "Patients")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientsService;

    public PatientsController(IPatientsService patientsService)
    {
        _patientsService = patientsService;
    }


    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        try
        {
            var patients = await _patientsService.GetAllPatientsAsync();
            return Ok(patients);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Searches for patients based on the provided query string.
    /// </summary>
    /// <param name="query">The search query string which can be a patient's first name, last name, or email address.</param>
    /// <returns>A list of patients matching the search criteria.</returns>
    [HttpGet("search")]
    public async Task<IActionResult> SearchPatients([FromQuery][Required][MaxLength(100)] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Search query cannot be null or empty.Please serach with valid patient details..!");
        }

        try
        {
            var patients = await _patientsService.SearchPatientsAsync(query);
            return Ok(patients);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}