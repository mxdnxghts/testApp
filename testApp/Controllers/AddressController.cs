using System;
using AutoMapper;
using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using testApp.DaData;
using testApp.Models;

namespace testApp.Controllers;

[ApiController]
public class AddressController : ControllerBase
{
	private readonly Serilog.ILogger _logger;
    private readonly ICleanClientSync _cleanClient;
    private readonly IMapper _mapper;
    private readonly ICleaner<DaDataPackageCleaner> _cleanerPackage;
    public AddressController(Serilog.ILogger logger, ICleanClientSync cleanClient, IMapper mapper, ICleaner<DaDataPackageCleaner> cleanerPackage)
    {
        _logger = logger;
        _cleanClient = cleanClient;
        _mapper = mapper;
        _cleanerPackage = cleanerPackage;
    }

    [HttpGet("clean-{source}")]
    public IActionResult GetAddressFull(string source)
    {
        var address = _cleanerPackage.CleanAsync(source).Result;

        return Ok(JsonConvert.SerializeObject(address));
    }
    
    [HttpGet("cleanDto-{source}")]
    public IActionResult GetAddressDto(string source)
    {
        var addressDto = _cleanerPackage.CleanDtoAsync(source);

        return Ok(JsonConvert.SerializeObject(addressDto));
    }
}

