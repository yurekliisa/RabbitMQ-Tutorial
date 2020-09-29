using RabbitMq.Banking.Data.Context;
using RabbitMq.Banking.Domain.Interfaces;
using RabbitMq.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMq.Banking.Data.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly BankingDbContext _context;
        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
