# Drone Delivery Service
This service will calculate the necessary trips to deliver all the packages.

## Running the service

This service requires .Net Core 6 version to run.

Clone the project, build, and run the service.

```sh
git clone https://github.com/andreguardia/DeliveryDroneService
dotnet build
dotnet run --project Velozient.DroneDeliveryService.WebApi --urls=http://localhost:5001/
```

## Testing the service

- Open in the browser: http://localhost:5001/swagger/index.html
- Request the route POST /Itinerary informing the file containing the Drones and Deliveries. There are some input files in the Samples folder
