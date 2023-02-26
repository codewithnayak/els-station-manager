using StationManagerApi.Models;

namespace StationManagerApi.Models
{
    public class GetStationResponse
    {
        public Guid StationIdentifier { get; set; }
        public string Name { get; set; }
        public string StationCode { get; set; }
        public string StateCode { get; set; }
        
        public Address Address { get; set; }

    }
}