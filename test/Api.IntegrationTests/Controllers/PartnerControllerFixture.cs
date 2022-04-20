using Microsoft.AspNetCore.Mvc.Testing;
using Shared.Features.Partners;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Controllers
{
    public class PartnerControllerFixture
    {
        private WebApplicationFactory<Program> _webApplicationFactory;
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;

        public PartnerControllerFixture()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>();
            _client = _webApplicationFactory.CreateClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        [Fact]
        public async Task PartnerGet()
        {
            var postResponse = await _client.PostAsync(TestConstants.PartnerPost, TestConstants.HappyAddPartnerCommands[0]);
            var id = TestMethods.Deserialise<PartnerDto>(postResponse).Id;

            var response = await _client.GetAsync(TestConstants.PartnerGet(id));
            var dto = TestMethods.Deserialise<PartnerDto>(response);

            Assert.NotNull(dto);
        }

        [Fact]
        public async Task PartnerGetAll()
        {
            foreach (var command in TestConstants.HappyAddPartnerCommands)
                await _client.PostAsync(TestConstants.PartnerPost, command);

            var response = await _client.GetAsync(TestConstants.PartnerGetAll);
            var dtos = JsonSerializer.Deserialize<List<PartnerDto>>(response.Content.ReadAsStream(), _serializerOptions);

            Assert.NotNull(dtos);
            Assert.NotEmpty(dtos);
        }

        [Fact]
        public async Task TeamPost()
        {
            var postResponse = await _client.PostAsync(TestConstants.PartnerPost, TestConstants.HappyAddPartnerCommands[0]);
            var id = TestMethods.Deserialise<PartnerDto>(postResponse).Id;

            var response = await _client.GetAsync(TestConstants.PartnerGet(id));
            var dto = TestMethods.Deserialise<PartnerDto>(response);

            Assert.NotNull(dto);
        }

        [Fact]
        public async Task TeamPut()
        {
            var postResponse = await _client.PostAsync(TestConstants.PartnerPost, TestConstants.HappyAddPartnerCommands[0]);
            var id = TestMethods.Deserialise<PartnerDto>(postResponse).Id;

            var command = TestConstants.HappyUpdatePartnerCommands[0];
            command.Id = id;

            await _client.PutAsync(TestConstants.PartnerPut, command);

            var response = await _client.GetAsync(TestConstants.PartnerGet(id));
            var dto = TestMethods.Deserialise<PartnerDto>(response);

            Assert.NotNull(dto);
            Assert.Equal(command.Id, dto.Id);
            Assert.Equal(command.Name, dto.Name);
        }
    }
}
