using RamenGo_API_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void SoftRemove(TEntity obj);
        void Delete(TEntity obj);
    }
}
