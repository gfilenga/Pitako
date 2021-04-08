using Microsoft.Extensions.DependencyInjection;
using Pitako.Api.Services;
using Pitako.Domain.Handlers;
using Pitako.Domain.Interfaces;
using Pitako.Domain.Repositories;
using Pitako.Infra.Repositories;

namespace Pitako.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<QuestionHandler, QuestionHandler>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<AnswerHandler, AnswerHandler>();
            services.AddTransient<IAWSS3Service, AWSS3Service>();

            return services;
        }
    }
}