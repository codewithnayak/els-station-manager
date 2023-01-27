namespace StationManagerApi.Models
{
    public class CreateStationRequest
    {
        public string Name { get; set; }
        public string StateCode { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }

    public class CreateStationResponse
    {
        public Guid StationId { get; set; }
        public string StationCode { get; set; }

    }
}
