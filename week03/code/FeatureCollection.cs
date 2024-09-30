public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature {
    public Dictionary<string, dynamic> Properties { get; set; }
}