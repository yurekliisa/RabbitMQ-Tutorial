using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMq.Banking.Application.Interfaces;
using RabbitMq.Banking.Application.Models;
using RabbitMq.Banking.Domain.Models;

namespace RabbitMq.Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public BankingController(
                IAccountService accountService
            )
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok(_accountService.GetAccounts());
        }


        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
