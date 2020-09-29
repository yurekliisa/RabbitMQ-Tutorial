using Newtonsoft.Json;
using RabbitMq.MVC.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RabbitMq.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }

    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;
        public TransferService(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
