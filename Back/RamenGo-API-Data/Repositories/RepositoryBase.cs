using Microsoft.EntityFrameworkCore;
using RamenGo_API_Data.Context;
using RamenGo_API_Domain.Entities;
using RamenGo_API_Domain.Enums;
using RamenGo_API_Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly RamenContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(RamenContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id && x.TypeStatus == TypeStatus.Active);
        }

        public virtual List<TEntity> GetAll()
        {
            return _dbSet.Where(x => x.TypeStatus == TypeStatus.Active).ToList();
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                _dbSet.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                _dbSet.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void SoftRemove(TEntity obj)
        {
            try
            {
                obj.TypeStatus = TypeStatus.Inactive;

                _dbSet.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity obj)
        {
            try
            {
                _dbSet.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
