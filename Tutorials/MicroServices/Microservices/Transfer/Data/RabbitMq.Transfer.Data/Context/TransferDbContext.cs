using Microsoft.EntityFrameworkCore;
using RabbitMq.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Transfer.Data.Context
{
    public class TransferDbContext:DbContext
    {
        public TransferDbContext(
                DbContextOptions<TransferDbContext> options
            ):base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
