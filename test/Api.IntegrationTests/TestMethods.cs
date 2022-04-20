using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests
{
    public static class TestMethods
    {
        private static JsonSerializerOptions _serializerOptions => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };    

        public static async Task<HttpResponseMessage?> PostAsync<T>(this HttpClient client, string route, T Data)
        {
            var response = await client.PostAsync(route, JsonContent.Create(Data));
            response.EnsureSuccessStatusCode();
            return response;
        }

        public static async Task<HttpResponseMessage?> PutAsync<T>(this HttpClient client, string route, T Data)
        {
            var response = await client.PutAsync(route, JsonContent.Create(Data));
            response.EnsureSuccessStatusCode();
            return response;
        }

        public static T Deserialise<T>(HttpResponseMessage message)
        {
            Assert.NotNull(message.Content);
            var returnEntity = JsonSerializer.Deserialize<T>(message.Content.ReadAsStream(), _serializerOptions);
            Assert.NotNull(returnEntity);
            return returnEntity;
        }
    }
}
