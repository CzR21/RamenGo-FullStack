using RamenGo_API_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Application.Interfaces
{
    public interface IRamenAppService
    {
        List<BrothModel> GetBrouts();
        List<ProteinModel> GetProteins();
        Task<OrderResponseModel> AddOrder(OrderRequestModel model);
    }
}
