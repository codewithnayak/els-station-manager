using AutoMapper;
using StationManagerApi.Db;
using StationManagerApi.Models;

namespace StationManagerApi.Services
{
    public class StationManagerService : IStationManagerService
    {
        private readonly StationDbContext _stationDbContext;
        private readonly IMapper _mapper;
        public StationManagerService(StationDbContext stationDbContext , IMapper mapper)
        {
            _stationDbContext = stationDbContext;
            _mapper = mapper;
        }

        public async Task<CreateStationResponse> CreateStation(CreateStationRequest createStationRequest)
        {
            var station = _mapper.Map<Station>(createStationRequest);
            await _stationDbContext.Stations.AddAsync(station);
            await _stationDbContext.SaveChangesAsync();

            return new CreateStationResponse
            {
                StationCode = station.StationCode,
                StationId = station.StationIdentifier
            };
            
        }
    }
}
