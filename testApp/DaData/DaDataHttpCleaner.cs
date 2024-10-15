using Dadata.Model;
using testApp.Models;

namespace testApp.DaData;

public class DaDataHttpCleaner : ICleaner<DaDataHttpCleaner>
{
    public async Task<Address> CleanAsync(string source)
    {
        throw new NotImplementedException();
    }

    public Task<AddressDTO> CleanDtoAsync(string source)
    {
        throw new NotImplementedException();
    }
}