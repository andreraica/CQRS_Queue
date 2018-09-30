using Application.Sales.Services;
using Domain.General.Events;
using Domain.General.Interfaces;
using Domain.General.Mediator;
using Domain.General.Notifications;
using Domain.General.Queue;
using Domain.Sales.Commands;
using Domain.Sales.Interfaces.Repository;
using Infrastructure.Data.General.Context;
using Infrastructure.Data.General.EventSourcing;
using Infrastructure.Data.General.UoW;
using Infrastructure.Data.Sales.Repositories;
using Infrastructure.IoC.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryMediator>();

            RegisterAppService(services);
            RegisterRepositories(services);
            RegisterEventsDomain(services);
            RegisterCommandsDomain(services);
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<SalesContext>();

            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreContext>();

            RegisterBusService(services);
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            services.AddScoped<ISalesAppService, SalesAppService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ISalesRepository, SalesRepository>();
        }

        private static void RegisterEventsDomain(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterCommandsDomain(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<MakeSellCommand>, SalesHandler>();
        }

        private static void RegisterBusService(IServiceCollection services)
        {
            services.AddScoped<ISender, Sender>();
        }
    }
}

