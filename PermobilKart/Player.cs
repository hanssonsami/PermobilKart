class Player
{
    public Vehicle? PlayerVeichle { get; set; }
    public Rider? PlayerRider { get; set; }
    public string? PlayerName { get; set; }

    public Player(Vehicle playerVehicle, Rider playerRider, string playerName)
    {
        PlayerRider = playerRider;
        PlayerVeichle = playerVehicle;
        PlayerName = playerName;
    }


}
