using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Mappers.Services;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Core.SeedWork;
using Lantern.Core.Services.Lectures;
using Lantern.Core.Services.Subjects;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects;
using Lantern.Domain.Subjects.Services;
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
                .AddTransient<IRepository<Enrollment>, Repository<Enrollment>>()
                .AddTransient<ISubjectService, SubjectService>();

            services.AddTransient<ILectureTheatreService, LectureTheatreService>();

            services
                .AddTransient<IEntityMapperService<LectureResponseModel>, LectureEntityMapperService>()
                .AddTransient<IEntityMapperService<SubjectResponseModel>, SubjectEntityMapperService>();

            return services;
        }
    }
}