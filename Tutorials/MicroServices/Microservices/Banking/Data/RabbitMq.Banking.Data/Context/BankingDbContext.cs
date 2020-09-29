using Microsoft.EntityFrameworkCore;
using RabbitMq.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public BankingDbContext(
                DbContextOptions<BankingDbContext> options
            ) : base(options)
        {

        }
    }
}
