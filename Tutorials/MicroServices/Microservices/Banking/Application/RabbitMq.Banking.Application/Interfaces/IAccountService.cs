using RabbitMq.Banking.Application.Models;
using RabbitMq.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
