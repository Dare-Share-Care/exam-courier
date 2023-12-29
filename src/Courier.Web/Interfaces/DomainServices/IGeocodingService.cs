using Courier.Web.Services;

namespace Courier.Web.Interfaces.DomainServices;

public interface IGeocodingService
{
    Task<GeoCoordinates> GetCoordinatesFromAddress(string deliveryAddress);
}