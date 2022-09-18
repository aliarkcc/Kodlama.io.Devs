using Application.Features.GithubProfiles.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Features.Users.Rules;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguagesBusinessRules>();
            services.AddScoped<ProgrammingLanguageTechnologiesBusinessRules>();
            services.AddScoped<GithubProfileBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<ITokenHelper,JwtHelper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            return services;
        }
    }
}
