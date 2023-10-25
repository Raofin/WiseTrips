using System.Net;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/agencies")]
public class AgencyController : ControllerBase
{
    private readonly IAgencyService _agencyService;

    public AgencyController(IAgencyService agencyService)
    {
        _agencyService = agencyService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var agencies = await _agencyService.GetAsync();
        return Ok(agencies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var agency = await _agencyService.GetAsync(id);
        if (agency == null)
        {
            return NotFound();
        }
        return Ok(agency);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AgencyDto agencyDto)
    {
        var addedAgency = await _agencyService.AddAsync(agencyDto);
        if (addedAgency != null)
        {
            return Ok(addedAgency);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AgencyDto agencyDto)
    {
        /*await _agencyService.UpdateAsync(id, agencyDto);*/
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _agencyService.DeleteAsync(id);
        if (deleted)
        {
            return Ok("Deleted");
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }
}