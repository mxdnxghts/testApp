using Dadata.Model;
using testApp.Models;

namespace testApp.DaData;

public interface ICleaner<TCleaner>
{
    public Task<Address> CleanAsync(string source);
    public Task<AddressDTO> CleanDtoAsync(string source);
}