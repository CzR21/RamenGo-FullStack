using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RamenGo_API_Application.Interfaces;
using RamenGo_API_Application.Models;
using RamenGo_API_Domain.Entities;
using RamenGo_API_Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RamenGo_API_Domain.Options;
using static System.Net.Mime.MediaTypeNames;
using RamenGo_API_Domain.Helpers;

namespace RamenGo_API_Application.Implementations
{
    public class RamenAppService : IRamenAppService
    {
        private readonly IBrothService _brothService;
        private readonly IOrderService _orderService;
        private readonly IProteinService _proteinService;
        private readonly APIRedVenturesOption _apiRedVenturesOption;
        private readonly HttpClient _httpClient;

        public RamenAppService(IBrothService brothService, IOrderService orderService, IProteinService proteinService, APIRedVenturesOption apiRedVenturesOption, HttpClient httpClient)
        {
            _brothService = brothService;
            _orderService = orderService;
            _proteinService = proteinService;
            _apiRedVenturesOption = apiRedVenturesOption;
            _httpClient = httpClient;
        }

        public List<BrothModel> GetBrouts()
        {
            try
            {
                List<Broth> broths = _brothService.GetAll();

                if (broths == null)
                {
                    return [];
                }

                var model = broths.Select(x => new BrothModel()
                {
                    Id = x.Id.ToString(),
                    ImageInactive = x.ImageInactive,
                    ImageActive = x.ImageActive,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProteinModel> GetProteins()
        {
            try
            {
                List<Protein> proteins = _proteinService.GetAll();

                if (proteins == null)
                {
                    return [];
                }

                var model = proteins.Select(x => new ProteinModel()
                {
                    Id = x.Id.ToString(),
                    ImageInactive = x.ImageInactive,
                    ImageActive = x.ImageActive,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderResponseModel> AddOrder(OrderRequestModel model)
        {
            try
            {
                Broth broth = _brothService.GetById(int.Parse(model.BrothId)) ?? throw new ArgumentException();
                Protein protein = _proteinService.GetById(int.Parse(model.ProteinId)) ?? throw new ArgumentException();                    

                string orderId = await GetOrderId();

                Order order = new Order()
                {
                    Id = int.Parse(orderId),
                    BrothId = int.Parse(model.BrothId),
                    ProteinId = int.Parse(model.ProteinId),
                };

                _orderService.Add(order);

                string description = $"{broth.Name} and {protein.Name} Ramen";

                return new OrderResponseModel()
                {
                    BrothId = orderId,
                    Description = description,
                    Image = ImageHelper.GetRamenImage(protein.Name),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> GetOrderId()
        {
            string url = _apiRedVenturesOption.Base + _apiRedVenturesOption.GetOrderId;

            //Client
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf");

            //Request
            HttpResponseMessage response = await _httpClient.PostAsync(url, null);

            //Response
            if (response.IsSuccessStatusCode)
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                var orderId = JsonConvert.DeserializeObject<OrderIdModel>(contentResponse);
                Console.WriteLine(orderId?.OrderId);
                return orderId?.OrderId;
            }
            else
            {
                string contentError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro on request GetOrderId = {contentError}");
            };
        }
    }
}
