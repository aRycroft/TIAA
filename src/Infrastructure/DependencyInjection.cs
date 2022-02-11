using Application.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(opts => opts.UseInMemoryDatabase("TIAA"));
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
        }
    }
}
