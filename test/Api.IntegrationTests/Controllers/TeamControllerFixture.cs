using Microsoft.AspNetCore.Mvc.Testing;
using Shared.Features.Teams;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Controllers
{
    public class TeamControllerFixture
    {
        private WebApplicationFactory<Program> _webApplicationFactory;
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;

        public TeamControllerFixture()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>();
            _client = _webApplicationFactory.CreateClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        [Fact]
        public async Task TeamGet()
        {
            var postResponse = await _client.PostAsync(TestConstants.TeamPost, TestConstants.HappyAddTeamCommands[0]);
            var id = TestMethods.Deserialise<TeamDto>(postResponse).Id;

            var response = await _client.GetAsync(TestConstants.TeamGet(id));
            var dto = TestMethods.Deserialise<TeamDto>(response);

            Assert.NotNull(dto);
        }

        [Fact]
        public async Task TeamGetAll()
        {
            foreach (var command in TestConstants.HappyAddTeamCommands)
                await _client.PostAsync(TestConstants.TeamPost, command);

            var response = await _client.GetAsync(TestConstants.TeamGetAll);
            var dtos = JsonSerializer.Deserialize<List<TeamDto>>(response.Content.ReadAsStream(), _serializerOptions);

            Assert.NotNull(dtos);
            Assert.NotEmpty(dtos);
        }

        [Fact]
        public async Task TeamPost()
        {
            var postResponse = await _client.PostAsync(TestConstants.TeamPost, TestConstants.HappyAddTeamCommands[0]);
            var id = TestMethods.Deserialise<TeamDto>(postResponse).Id;

            var response = await _client.GetAsync(TestConstants.TeamGet(id));
            var dto = TestMethods.Deserialise<TeamDto>(response);

            Assert.NotNull(dto);
        }

        [Fact]
        public async Task TeamPut()
        {
            var postResponse = await _client.PostAsync(TestConstants.TeamPost, TestConstants.HappyAddTeamCommands[0]);
            var id = TestMethods.Deserialise<TeamDto>(postResponse).Id;

            var command = TestConstants.HappyUpdateTeamCommands[0];
            command.Id = id;

            await _client.PutAsync(TestConstants.TeamPut, command);

            var response = await _client.GetAsync(TestConstants.TeamGet(id));
            var dto = TestMethods.Deserialise<TeamDto>(response);

            Assert.NotNull(dto);
            Assert.Equal(command.Id, dto.Id);
            Assert.Equal(command.Name, dto.Name);
        }
    }
}
