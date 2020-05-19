using Database.Sql.Gym;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Gym;
using Service.Gym.Interfaces;

namespace API.Gym
{
    public static class GymBuilderExtension
    {
        public static IServiceCollection AddGymService(this IServiceCollection services, IConfiguration config)
        {
            // Declare connect to sql server
            services.AddDbContext<GymContext>(options => options.UseSqlServer(config.GetConnectionString("GymConnection")), ServiceLifetime.Scoped);
            // DI services
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IExerciseLevelService, ExerciseLevelService>();
            services.AddScoped<IExerciseResourceService, ExerciseResourceService>();
            services.AddScoped<IMuscleService, MuscleService>();
            return services;
        }
    }
}
