<Query Kind="Program" />

// Usage
void Main()
{
    var counsel = new JediCounsel();

    counsel.WelcomeIn("Plo Koon", "blue");
    counsel.WelcomeIn("Mace Windu", "purple");
    counsel.WelcomeIn("Shaak Ti", "blue");
    counsel.WelcomeIn("Yoda", "green");
    counsel.WelcomeIn("Ki-Adi-Mundi", "purple");
    counsel.WelcomeIn("Saesee Tiin", "green");
}

public class JediCounsel
{
    public List<Jedi> Council = new List<Jedi>();

    public void WelcomeIn(string name, string lightsaberColor)
    {
        var lightsaberType = LightsaberFactory.GetLightsaberType(lightsaberColor);
        lightsaberType.Dump($"Given to {name}");
        Council.Add(new Jedi(name, lightsaberType));
    }
}


// Flyweight objects' pool - Creates the flyweight items and caches them
public static class LightsaberFactory
{
    private static IDictionary<string, LightsaberType> _cache
        = new Dictionary<string, LightsaberType>();

    public static LightsaberType GetLightsaberType(string color)
    {
        if (!_cache.ContainsKey(color))
        {
            $"Creating a {color} lightsaber".Dump();
            _cache.Add(color, new LightsaberType(color));
        }

        return _cache[color];
    }
}


// Flyweight object - Manages its intrinsic state, must be immutable
public record LightsaberType(string Color);


// Context object - Depends on a flyweight item and providing an extrinsic state that
// can vary independently of the flyweight object
public class Jedi
{
    string _name;
    LightsaberType _type;

    public Jedi(string name, LightsaberType type)
        => (_name, _type) = (name, type);
}
