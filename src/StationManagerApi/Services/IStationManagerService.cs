using StationManagerApi.Models;

namespace StationManagerApi.Services
{
    public interface IStationManagerService
    {
        Task<CreateStationResponse> CreateStation(CreateStationRequest createStationRequest);

        Task<GetStationResponse> GetStation(string id);
    }
}