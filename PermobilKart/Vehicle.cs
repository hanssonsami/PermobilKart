class Vehicle
{
    public int VehicleSpeed { get; set; }
    public int VehicleAcceleration { get; set; }
    public int VehicleWeight { get; set; }
    public int VehicleHandling { get; set; }
    public string VehicleName { get; set; }

    public Vehicle(string vehicleName, int vehicleSpeed, int vehicleHandling, int vehicleWeight, int vehicleAcceleration)
    {
        VehicleSpeed = vehicleSpeed;
        VehicleAcceleration = vehicleAcceleration;
        VehicleWeight = vehicleWeight;
        VehicleHandling = vehicleHandling;
        VehicleName = vehicleName;
    }
}
