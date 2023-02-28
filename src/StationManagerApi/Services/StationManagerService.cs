using AutoMapper;
using StationManagerApi.Db;
using StationManagerApi.Models;

namespace StationManagerApi.Services
{
    public class StationManagerService : IStationManagerService
    {
        private readonly StationDbContext _stationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<StationManagerService> _logger;
        public StationManagerService(StationDbContext stationDbContext , 
            IMapper mapper,
            ILogger<StationManagerService> logger)
        {
            _stationDbContext = stationDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateStationResponse> CreateStation(CreateStationRequest createStationRequest)
        {
            var station = _mapper.Map<Station>(createStationRequest);
            await _stationDbContext.Stations.AddAsync(station);
            await _stationDbContext.SaveChangesAsync();

            _logger.LogInformation("New station created");

            return new CreateStationResponse
            {
                StationCode = station.StationCode,
                StationId = station.StationIdentifier
            };
            
        }

        public Task<GetStationResponse> GetStation(string id)
        {
            //throw new NotImplementedException();
            return Task.FromResult(new GetStationResponse());
        }
    }
}
