using Newtonsoft.Json;

namespace Biller.Shared.ExtensionMethods;

public static class Object
{
    public static T CastTo<T>(this object source) 
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        var json = JsonConvert.SerializeObject(source, settings);
        return JsonConvert.DeserializeObject<T>(json!);
    }
}
