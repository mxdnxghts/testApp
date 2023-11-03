using System;
using AutoMapper;
using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using testApp.Models;

namespace testApp.Controllers;

[ApiController]
public class AddressController : ControllerBase
{
	private readonly Serilog.ILogger _logger;
    private readonly ICleanClientSync _cleanClient;
    private readonly IMapper _mapper;
    public AddressController(Serilog.ILogger logger, ICleanClientSync cleanClient, IMapper mapper)
    {
        _logger = logger;
        _cleanClient = cleanClient;
        _mapper = mapper;
    }

    [HttpGet("clean-{source}")]
    public IActionResult GetAddressFull(string source)
    {
        Address address = new();
        try
        {
            address = _cleanClient.Clean<Address>(source);
        }
        catch (Exception ex)
        {
            _logger.Error("We catch exception during fetching result from service");
            _logger.Error(ex.Message);
        }

        return Ok(address);
    }
    
    [HttpGet("cleanDto-{source}")]
    public IActionResult GetAddressDto(string source)
    {
        AddressDTO addressDto = new();
        try
        {
            var address = _cleanClient.Clean<Address>(source);
            addressDto = _mapper.Map<AddressDTO>(address);
        }
        catch (Exception ex)
        {
            _logger.Error("We catch exception during fetching result from service");
            _logger.Error(ex.Message);
        }

        return Ok(addressDto);
    }
}

