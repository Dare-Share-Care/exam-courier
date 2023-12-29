using Courier.Web.Interfaces.DomainServices;

namespace Courier.Web.Services;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class GeocodingService : IGeocodingService
{
    private readonly string _locationIqToken;
    private readonly HttpClient _httpClient;

    public GeocodingService(string locationIqToken, HttpClient httpClient)
    {
        _locationIqToken = locationIqToken;
        _httpClient = httpClient;
    }

    public async Task<GeoCoordinates> GetCoordinatesFromAddress(string address)
    {
        var url = $"https://us1.locationiq.com/v1/search.php?key={_locationIqToken}&q={Uri.EscapeDataString(address)}&format=json";
        var response = await _httpClient.GetStringAsync(url);
        var geocodeResponse = JsonConvert.DeserializeObject<List<LocationIqResponse>>(response);
        var location = geocodeResponse[0];
        return new GeoCoordinates(location.lat, location.lon);
    }
}

public class GeoCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public GeoCoordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}

public class LocationIqResponse
{
    public double lat { get; set; }
    public double lon { get; set; }
}
