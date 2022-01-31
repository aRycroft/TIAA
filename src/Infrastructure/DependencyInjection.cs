using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
        }
    }
}
