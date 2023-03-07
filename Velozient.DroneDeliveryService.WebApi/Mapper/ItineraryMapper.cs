using AutoMapper;
using DroneDeliveryService.Domain;
using DroneDeliveryService.WebApi.Response;

namespace DroneDeliveryService.WebApi.Mapper
{
    public class ItineraryMapper : Profile
    {
        public ItineraryMapper()
        {
            CreateMap<Delivery, DeliveryResponse>();
            CreateMap<Trip, TripResponse>();
            CreateMap<Drone, DroneResponse>();
            CreateMap<Itinerary, ItineraryResponse>();
        }
    }
}
