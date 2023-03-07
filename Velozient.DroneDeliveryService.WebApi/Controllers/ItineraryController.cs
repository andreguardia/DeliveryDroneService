using AutoMapper;
using DroneDeliveryService.Domain;
using DroneDeliveryService.WebApi.Extensions;
using DroneDeliveryService.WebApi.Response;
using Microsoft.AspNetCore.Mvc;

namespace DroneDeliveryService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly ILogger<ItineraryController> _logger;
        private readonly IMapper _mapper;

        public ItineraryController(ILogger<ItineraryController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItinerary(IFormFile file)
        {
            try
            {
                var content = await file.ReadAsStringAsync();
                var itinerary = Itinerary.Parse(content);
                var response = _mapper.Map<ItineraryResponse>(itinerary);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred while processing {nameof(CreateItinerary)}");
                return BadRequest();
            }
        }
    }
}
