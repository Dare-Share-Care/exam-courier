using System.Text.Json.Serialization;

namespace Courier.Web.Models.Dto;

public class ClaimOrderDto
{
    [JsonPropertyName("to")]
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public string DeliveryAddress { get; set; }
}