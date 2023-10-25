using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/packages")]
[LoggedIn]
public class PackageController : ControllerBase
{
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var packages = await _packageService.GetAsync();
        return Ok(packages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var package = await _packageService.GetAsync(id);
        if (package == null)
        {
            return NotFound();
        }
        return Ok(package);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(PackageDto packageDto)
    {
        var addedPackage = await _packageService.AddAsync(packageDto);
        if (addedPackage != null)
        {
            return Ok(addedPackage);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> Update(int id, PackageDto packageDto)
    {
        /*var updated = await _packageService.UpdateAsync(id, packageDto);
        if (updated)
        {
            return Ok();
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);*/

        return Ok();
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _packageService.DeleteAsync(id);
        if (deleted)
        {
            return Ok("Deleted");
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }
}