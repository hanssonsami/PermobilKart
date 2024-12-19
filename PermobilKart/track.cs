class Track
{
    public string TrackName { get; private set; }
    public int TrackLength { get; private set; }

    public Track(string trackName, int trackLength)
    {
        TrackName = trackName;
        TrackLength = trackLength;
    }
}
