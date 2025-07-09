#:sdk Microsoft.NET.Sdk.Web

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var cache = new System.Collections.Concurrent.ConcurrentDictionary<string, CacheEntry>();

app.MapPost("/{key}", async (string key, HttpRequest req) =>
{
    using var ms = new MemoryStream();
    await req.Body.CopyToAsync(ms);
    var data = ms.ToArray();
    var contentType = req.ContentType ?? "application/octet-stream";

    cache[key] = new CacheEntry(data, contentType);
    return Results.Ok($"Stored {ms.Length} bytes under '{key}'");
});

app.MapGet("/{key}", (string key) =>
{
    if (cache.TryGetValue(key, out var entry))
        return Results.File(entry.Data, entry.ContentType);

    return Results.NotFound($"Key '{key}' not found.");
});


app.MapDelete("/{key}", (string key) =>
{
    if (cache.TryRemove(key, out _))
        return Results.Ok($"Removed '{key}'");
    return Results.NotFound($"Key '{key}' not found.");
});

app.Run();

record CacheEntry(byte[] Data, string ContentType);