using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ForeignApp.Controllers;

[ApiController]
public class AddressCleanerController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AddressCleanerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("clean-{source}")]
    public async Task<IActionResult> GetAddress(string source)
    {
        var httpClient = _httpClientFactory.CreateClient("CleanerFull");
        var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{source}");
        var response = await httpResponseMessage.Content.ReadAsStringAsync();
        return Ok(response);
    }

    [HttpGet("cleanDto-{source}")]
    public async Task<IActionResult> GetAddressDto(string source)
    {
        var httpClient = _httpClientFactory.CreateClient("CleanerDto");
        var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{source}");
        var response = await httpResponseMessage.Content.ReadAsStringAsync();
        return Ok(response);
    }
}

