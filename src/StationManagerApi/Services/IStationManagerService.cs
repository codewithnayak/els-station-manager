using StationManagerApi.Models;

namespace StationManagerApi.Services
{
    public interface IStationManagerService
    {
        Task<CreateStationResponse> CreateStation(CreateStationRequest createStationRequest);

        GetStationResponse GetStation(string id);
    }
}