using HepsiBuradaApi.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HepsiBuradaApi.Infrastructure.RedisCache;

public class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer _redisConnection;
    private readonly IDatabase _database;
    private readonly RedisCacheSettings _settings;

    public RedisCacheService(IOptions<RedisCacheSettings> settings)
    {
        _settings = settings.Value;
        var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
        _redisConnection = ConnectionMultiplexer.Connect(opt);
        _database = _redisConnection.GetDatabase();
    }

    public async Task<T> GetAsync<T>(string key)
    {
        RedisValue value = await _database.StringGetAsync(key);
        return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
    }

    public async Task SetAsync<T>(string key, T value, DateTime? expirationDate = null)
    {
        TimeSpan? expirationTimeSpan = expirationDate.Value - DateTime.UtcNow;
        await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), expirationTimeSpan);
    }
}
