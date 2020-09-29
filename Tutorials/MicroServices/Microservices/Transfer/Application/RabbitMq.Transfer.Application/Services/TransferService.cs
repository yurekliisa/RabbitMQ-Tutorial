using RabbitMq.Domain.Core;
using RabbitMq.Transfer.Application.Interfaces;
using RabbitMq.Transfer.Domain.Interfaces;
using RabbitMq.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;
        public TransferService(
                IEventBus bus,
                ITransferRepository transferRepository
            )
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
