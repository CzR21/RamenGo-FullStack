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
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public List<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }

        public void SoftRemove(TEntity obj)
        {
            _repositoryBase.SoftRemove(obj);
        }

        public void Delete(TEntity obj)
        {
            _repositoryBase.Delete(obj);
        }
    }
}
