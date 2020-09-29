using RabbitMq.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
