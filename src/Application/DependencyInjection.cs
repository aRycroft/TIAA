using Application.Features.Partners;
using Application.Features.Teams;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IPartnerAdapter, PartnerAdapter>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamAdapter, TeamAdapter>();
            services.AddScoped<IMovePartnerToTeamHandler, MovePartnerToTeamHandler>();
        }
    }
}
