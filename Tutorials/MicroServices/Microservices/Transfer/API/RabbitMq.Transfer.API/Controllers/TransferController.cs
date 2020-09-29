using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMq.Transfer.Application.Interfaces;

namespace RabbitMq.Transfer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(
            ITransferService transferService
            )
        {
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult GetTransfers()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
