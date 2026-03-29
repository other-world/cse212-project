using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> features { get; set; } // a Feature is like a list of earthquakes
}

public class Feature
{
   public Properties properties { get; set; }
}


public class Properties
{
    public double mag { get; set; }
    public String place {get; set; }

    public string getEarthquake()
{
    return $"{place} - Mag {mag}";
}
}
