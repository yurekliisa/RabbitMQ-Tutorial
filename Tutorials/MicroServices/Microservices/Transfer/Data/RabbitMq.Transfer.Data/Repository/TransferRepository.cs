using RabbitMq.Transfer.Data.Context;
using RabbitMq.Transfer.Domain.Interfaces;
using RabbitMq.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Transfer.Data.Repository
{
    public class TransferRepository:ITransferRepository
    {
        private readonly TransferDbContext _context;
        public TransferRepository(
                TransferDbContext context
            )
        {
            _context = context;
        }

        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }
    }
}
