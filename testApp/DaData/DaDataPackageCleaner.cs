using AutoMapper;
using Dadata;
using Dadata.Model;
using testApp.Models;
using ILogger = Serilog.ILogger;

namespace testApp.DaData;

public class DaDataPackageCleaner : ICleaner<DaDataPackageCleaner>
{
    private readonly ILogger _logger;
    private readonly ICleanClientSync _cleanClient;
    private readonly IMapper _mapper;

    public DaDataPackageCleaner(ILogger logger, ICleanClientSync cleanClient, IMapper mapper)
    {
        _logger = logger;
        _cleanClient = cleanClient;
        _mapper = mapper;
    }

    public Task<Address> CleanAsync(string source)
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
            return Task.FromException<Address>(ex);
        }

        return Task.FromResult(address);
    }

    public Task<AddressDTO> CleanDtoAsync(string source)
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
            return Task.FromException<AddressDTO>(ex);
        }

        return Task.FromResult(addressDto);
    }
}