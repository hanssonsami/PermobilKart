class Rider
{
    public string RiderName { get; private set; }
    public double RiderSpeedMultiplier { get; private set; }
    public double RiderWeight { get; private set; }
    public double RiderAccelerationMultiplier { get; private set; }

    public Rider(string riderName, double riderSpeedMultiplier, double riderWeight, double riderAccelerationMultiplier)
    {
        RiderName = riderName;
        RiderSpeedMultiplier = riderSpeedMultiplier;
        RiderWeight = riderWeight;
        RiderAccelerationMultiplier = riderAccelerationMultiplier;
    }
}
