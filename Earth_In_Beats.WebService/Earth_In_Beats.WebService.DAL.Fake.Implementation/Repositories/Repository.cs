using System;
using System.Collections.Generic;
using System.Linq;
using Earth_In_Beats.WebService.DAL.Contracts.Models;
using Earth_In_Beats.WebService.DAL.Contracts.Repository;

namespace Earth_In_Beats.WebService.DAL.Fake.Implementation.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
	{
		protected static List<TEntity> Data = new List<TEntity>();

		public TEntity Add(TEntity entity)
		{
			entity.Id = Guid.NewGuid();
			Data.Add(entity);

			return entity;
		}

		public TEntity Get(Guid id)
		{
			return Data.SingleOrDefault(o => o.Id == id);
		}

		public TEntity Update(TEntity entity)
		{
			return entity;
		}

		public bool Remove(TEntity entity)
		{
			Data.Remove(entity);
			return true;
		}

		public bool Remove(Guid id)
		{
			Data.RemoveAll(o => o.Id == id);
			return true;
		}

		public int RemoveRange(TEntity[] entities)
		{
			return Data.RemoveAll(entities.Contains);
		}

		public TEntity[] GetAll()
		{
			return Data.ToArray();
		}

		public void Save()
		{
		}
	}
}