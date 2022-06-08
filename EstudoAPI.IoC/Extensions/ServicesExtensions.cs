using EstudoAPI.Application.Services;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoAPI.IoC.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IBoletimEscolarService, BoletimEscolarService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            return services;
        }
    }
}
