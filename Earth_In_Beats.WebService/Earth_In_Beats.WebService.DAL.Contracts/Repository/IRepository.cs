using Earth_In_Beats.WebService.DAL.Contracts.Models;
using System;

namespace Earth_In_Beats.WebService.DAL.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Add(TEntity entity);

        TEntity Get(Guid id);

        TEntity Update(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(Guid id);

        bool[] RemoveRange(TEntity[] entities);

        bool[] RemoveRange(Guid[] ids);

        TEntity[] GetAll();
    }
}
