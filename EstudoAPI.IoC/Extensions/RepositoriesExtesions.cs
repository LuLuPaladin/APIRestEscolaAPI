using EstudoAPI.Data.Repositories;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoAPI.IoC.Extensions
{
    public static class RepositoriesExtesions
    {
        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IBoletimEscolarRepository, BoletimEscolarRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            return services;
        }
    }
}
