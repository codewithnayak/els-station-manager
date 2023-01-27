﻿using Microsoft.AspNetCore.Mvc;
using StationManagerApi.Models;
using StationManagerApi.Services;

namespace StationManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationManagerService _stationManagerService;
        public StationController(IStationManagerService stationManagerService)
        {
            _stationManagerService = stationManagerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationRequest createStationRequest)
        {
            var createStationResponse = await _stationManagerService.CreateStation(createStationRequest);
            var routeValues = new
            {
                action = nameof(StationController.GetStation),
                id = createStationResponse.StationId
            };

            return CreatedAtRoute(routeValues, createStationResponse);
        }

        [HttpGet("{id}",Name ="GetStation")]
        public async Task<IActionResult> GetStation(string id)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}