using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public  GetStationResponse GetStation(string id)
        {

            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Station id can not be null or empty");

            var station =  _stationDbContext.Stations
                           .Include(_ => _.Address)
                           .FirstOrDefault(_ => _.StationIdentifier == Guid.Parse(id));

            return _mapper.Map<GetStationResponse>(station);
        }
    }
}
