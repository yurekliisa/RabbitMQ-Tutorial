using RabbitMq.Banking.Application.Interfaces;
using RabbitMq.Banking.Application.Models;
using RabbitMq.Banking.Domain.Commands;
using RabbitMq.Banking.Domain.Interfaces;
using RabbitMq.Banking.Domain.Models;
using RabbitMq.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountService(
            IAccountRepository accountRepository,
            IEventBus bus
            )
        {
            _bus = bus;
            _accountRepository = accountRepository;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );
            _bus.SendCommand(createTransferCommand);
        }
    }
}
