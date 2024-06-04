using RamenGo_API_Domain.Entities;
using RamenGo_API_Domain.Interfaces.Repositories;
using RamenGo_API_Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Services
{
    public class BrothService : ServiceBase<Broth>, IBrothService
    {
        private readonly IBrothRepository _brothRepository;
        
        public BrothService(IBrothRepository brothRepository) : base(brothRepository)
        {
            _brothRepository = brothRepository;
        }
    }
}
