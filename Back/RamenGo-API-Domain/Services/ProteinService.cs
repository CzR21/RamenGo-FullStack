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
    public class ProteinService : ServiceBase<Protein>, IProteinService
    {
        private readonly IProteinRepository _proteinRepository;
        
        public ProteinService(IProteinRepository proteinRepository) : base(proteinRepository)
        {
            _proteinRepository = proteinRepository;
        }
    }
}
