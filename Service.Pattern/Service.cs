﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

#endregion

namespace Service.Pattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : IObjectState
    {
        private readonly IRepository<TEntity> _repository;

        protected Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _repository.SelectQuery(query, parameters).AsQueryable();
        }

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertRange(entities);
        }

        public virtual void InsertGraph(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertGraphRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(object id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public IQueryFluent<TEntity> Query()
        {
            return _repository.Query();
        }

        public virtual IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject)
        {
            return _repository.Query(queryObject);
        }

        public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            return _repository.Query(query);
        }

		//public virtual async Task<TEntity> FindAsync(params object[] keyValues)
		//{
		//	return await _repository.FindAsync(keyValues);
		//}

		//public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
		//{
		//	return await _repository.FindAsync(cancellationToken, keyValues);
		//}

		//public virtual async Task<bool> DeleteAsync(params object[] keyValues)
		//{
		//	return await DeleteAsync(CancellationToken.None, keyValues);
		//}

		//public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
		//{
		//	return await DeleteAsync(cancellationToken, keyValues);
		//}

        public IQueryable ODataQueryable(ODataQueryOptions<TEntity> oDataQueryOptions)
        {
            return _repository.Queryable(oDataQueryOptions);
        }

        public IQueryable<TEntity> ODataQueryable()
        {
            return _repository.Queryable();
        }
    }
}