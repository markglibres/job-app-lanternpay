using Lantern.Core.SeedWork;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Lectures;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Lantern.Api.DependencyInjection
{
    public static class ConfigureLanternServicesExtensions
    {
        public static IServiceCollection ConfigureLanternServices(this IServiceCollection services)
        {
            services
                .AddTransient<IRepository<Student>, Repository<Student>>()
                .AddTransient<IRepository<Subject>, Repository<Subject>>()
                .AddTransient<IRepository<LectureTheatre>, Repository<LectureTheatre>>()
                .AddTransient<IRepository<Enrollment>, Repository<Enrollment>>();

            return services;
        }
    }
}