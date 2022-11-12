using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoApi.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static Task SetAsync<T>(this IDistributedCache cache, string key, T value)
        {
            var optionsCahe = new DistributedCacheEntryOptions();
            optionsCahe.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(1));
            return SetAsync(cache, key, value, optionsCahe);
        }

        public static Task SetAsync<T>(this IDistributedCache cache, string key, T value, DistributedCacheEntryOptions options)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, GetJsonSerializerOptions()));
            return cache.SetAsync(key, bytes, options);
        }

        public static async Task<T?> TryGetValueAsync<T>(this IDistributedCache cache, string key)
        {
            var val = await cache.GetAsync(key);
            if(val == null) return default(T);
            return JsonSerializer.Deserialize<T>(val, GetJsonSerializerOptions());
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions()
            {
                PropertyNamingPolicy = null,
                WriteIndented = true,
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        }
    }
}
