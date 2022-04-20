using Shared.Features.Partners;
using Shared.Features.Teams;

namespace Api.IntegrationTests
{
    public static class TestConstants
    {
        public static string TeamGet(int id) => $"Team/{id}";
        public const string TeamGetAll = "Team/GetAll";
        public const string TeamPost = "Team/";
        public const string TeamPut = "Team/";

        public static AddTeamCommand[] HappyAddTeamCommands => new AddTeamCommand[]
        {
            new AddTeamCommand{ Name = "Employee name"},
            new AddTeamCommand{ Name = "Employee name 2"},
        };

        public static UpdateTeamCommand[] HappyUpdateTeamCommands => new UpdateTeamCommand[]
        {
            new UpdateTeamCommand{ Id = 1, Name = "Updated name" },
            new UpdateTeamCommand{ Id = 2, Name = "Updated name" }
        };

        public static string PartnerGet(int id) => $"Team/{id}";
        public const string PartnerGetAll = "Team/GetAll";
        public const string PartnerPost = "Team/";
        public const string PartnerPut = "Team/";

        public static AddPartnerCommand[] HappyAddPartnerCommands => new AddPartnerCommand[]
        {
            new AddPartnerCommand{ Name = "Employee name"},
            new AddPartnerCommand{ Name = "Employee name 2"},
        };

        public static UpdatePartnerCommand[] HappyUpdatePartnerCommands => new UpdatePartnerCommand[]
        {
            new UpdatePartnerCommand{ Id = 1, Name = "Updated name" },
            new UpdatePartnerCommand{ Id = 2, Name = "Updated name" }
        };
    }
}
