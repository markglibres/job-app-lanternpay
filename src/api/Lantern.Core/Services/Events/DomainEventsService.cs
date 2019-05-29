using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lantern.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Lantern.Core.Services.Events
{
    public class DomainEventsService : IDomainEventsService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
       
        public DomainEventsService(
            IServiceScopeFactory serviceScopeFactory
            )
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        
        public async Task Publish(IEnumerable<IDomainEvent> domainEvents)
        {
            if(!domainEvents?.Any() ?? true) return;
            
            var events = domainEvents.ToList();

            using (var service = _serviceScopeFactory.CreateScope())
            {
                var mediator = service.ServiceProvider.GetService<IMediator>();
                
                foreach (var domainEvent in events)
                {
                    await mediator.Publish(domainEvent);
                }
            }
           
            
        }
    }
}