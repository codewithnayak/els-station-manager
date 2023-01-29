using FluentValidation;
using HttpUtility;
using HttpUtility.Response;
using Microsoft.AspNetCore.Mvc;
using StationManagerApi.Models;
using StationManagerApi.Services;

namespace StationManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationManagerService _stationManagerService;
        private readonly ILogger<StationController> _logger;
        private readonly IValidator<CreateStationRequest> _validator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationManagerService"></param>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
        public StationController(IStationManagerService stationManagerService
            , ILogger<StationController> logger,
            IValidator<CreateStationRequest> validator)
        {
            _stationManagerService = stationManagerService;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createStationRequest"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationRequest createStationRequest)
        {
            var modelState = _validator.Validate(createStationRequest);
            if (!modelState.IsValid)
            {

                var response = new ResponseBase<Nothing>()
                {
                    Errors = modelState.Errors.Select(e => new Error
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    })
                };

                return BadRequest(response);
            }

            var createStationResponse = await _stationManagerService.CreateStation(createStationRequest);
            var routeValues = new
            {
                action = nameof(StationController.GetStation),
                id = createStationResponse.StationId
            };

            return CreatedAtRoute(routeValues, new ResponseBase<CreateStationResponse>
            {
                Data = createStationResponse
            });
        }

        [HttpGet("{id}", Name = "GetStation")]
        public async Task<IActionResult> GetStation(string id)
        {
            //will be implemented next 
            await Task.CompletedTask;
            return Ok();
        }
    }
}
