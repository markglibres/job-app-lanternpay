using Lantern.Core.Serializers;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Lectures;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects;
using Marten;
using Marten.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreOptions = Marten.StoreOptions;

namespace Lantern.Api.DependencyInjection
{
    public static class DocumentStoreServiceExtensions
    {
        public static IServiceCollection ConfigureDocumentStore(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var serializer = new JsonNetSerializer();
            serializer.Customize(c => c.ContractResolver = new ResolvePrivateSetters());
            serializer.EnumStorage = EnumStorage.AsString;

            services.AddSingleton<IDocumentStore>(d => DocumentStore.For(_ =>
            {
                _.Serializer(serializer);
                _.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
                _.DatabaseSchemaName = StoreOptions.DefaultDatabaseSchemaName;
                _.Connection(configuration.GetConnectionString("DefaultConnection"));
                _.Schema.For<Student>().DocumentAlias("Students");
                _.Schema.For<Subject>().DocumentAlias("Subjects");
                _.Schema.For<LectureTheatre>().DocumentAlias("LectureTheatres");
                _.Schema.For<Enrollment>().DocumentAlias("Enrollments")
                    .Index(table => table.StudentId)
                    .Index(table => table.SubjectId)
                    .Index(table => table.ApplicationId);
            }));

            return services;
        }
    }
}