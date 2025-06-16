namespace Noxy.NET.Test.Presentation.Services;

public class TextService(DataAPIService serviceDataAPI)
{
    private readonly Dictionary<string, (string Value, DateTime? TimeResolved)> _collection = [];

    public string Get(string identifier)
    {
        if (_collection.TryGetValue(identifier, out (string Value, DateTime? TimeResolved) item) && item.TimeResolved != null)
        {
            return item.Value;
        }

        _collection[identifier] = (string.Empty, null);
        return _collection[identifier].Value;
    }

    public async Task Resolve()
    {
        IEnumerable<string> request = _collection
            .Where(x => x.Value.TimeResolved == null)
            .Select(x => x.Key);

        Dictionary<string, string> result = await serviceDataAPI.ResolveTextParameterList(request);
        UpdateCollection(result);
    }

    public async Task Refresh(DateTime? timeDeadline = null, bool useOnlyResolved = false)
    {
        timeDeadline ??= DateTime.UtcNow;
        IEnumerable<KeyValuePair<string, (string Value, DateTime? TimeResolved)>> request = _collection.Where(x => x.Value.TimeResolved <= timeDeadline);
        if (useOnlyResolved)
        {
            request = request.Where(x => x.Value.TimeResolved != null);
        }

        Dictionary<string, string> result = await serviceDataAPI.ResolveTextParameterList(request.Select(x => x.Key));
        UpdateCollection(result);
    }

    private void UpdateCollection(Dictionary<string, string> collection)
    {
        DateTime now = DateTime.UtcNow;
        foreach (KeyValuePair<string, string> item in collection)
        {
            _collection[item.Key] = (item.Value, now);
        }
    }
}
