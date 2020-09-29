using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Banking.Application.Interfaces;
using RabbitMq.Banking.Application.Services;
using RabbitMq.Banking.Data.Context;
using RabbitMq.Banking.Data.Repository;
using RabbitMq.Banking.Domain.CommandHandlers;
using RabbitMq.Banking.Domain.Commands;
using RabbitMq.Banking.Domain.Interfaces;
using RabbitMq.Domain.Core;
using RabbitMq.Infra.Bus;
using RabbitMq.Transfer.Application.Interfaces;
using RabbitMq.Transfer.Application.Services;
using RabbitMq.Transfer.Data.Context;
using RabbitMq.Transfer.Data.Repository;
using RabbitMq.Transfer.Domain.Events;
using RabbitMq.Transfer.Domain.EventsHandlers;
using RabbitMq.Transfer.Domain.Interfaces;
using System;

namespace RabbitMq.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(sp=>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Doamin Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            //Context
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();

        }
    }
}
