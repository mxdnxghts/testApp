using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ForeignApp.Controllers;

[ApiController]
public class AddressCleanerController : ControllerBase
{
    private readonly HttpClient _client;

    public AddressCleanerController(HttpClient client)
    {
        _client = client;
    }

    [HttpGet("clean-{source}")]
    public async Task<IActionResult> GetAddress(string source)
    {
        var request = await _client.GetStringAsync($"https://localhost:44360/clean-{source}");
        return Ok(request);
    }
}

