using System;
using System.Linq;
using System.Collections.Generic;
using HackOpay.Core.Domain;
using NPoco;
using NPoco.FluentMappings;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Data.Repository
{

    public class BaseOpayRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected IBaseRepository<TEntity, TKey> repo;
        public BaseOpayRepository()
        {
            repo = new BaseSqliteRepository<TEntity, TKey>();
        }

        public virtual void AddParam(string key, object obj)
        {
            repo.AddParam(key, obj);
        }

        public virtual string ApplySort(string sort)
        {
            return repo.ApplySort(sort);
        }

        public virtual int Delete(TEntity obj)
        {
            return repo.Delete(obj);
        }

        public virtual int DeleteFinal(TEntity obj)
        {
            return repo.DeleteFinal(obj);
        }

        public virtual int Execute(string sql)
        { 
            return repo.Execute(sql);
        }

        public virtual TEntity Get(TKey id)
        {
            return repo.Get(id);
        }

        public virtual List<TEntity> GetList(string sql)
        { 
            return repo.GetList(sql);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            return repo.Insert(obj);
        }

        public virtual NPoco.Page<TEntity> SearchViewSQL(string sql, long page, long pagesize)
        { 
            return repo.SearchViewSQL(sql, page, pagesize);
        }

        public virtual TEntity Update(TEntity obj)
        {
            return repo.Update(obj);
        }

        public virtual string LikeFilter(string field, string txt)
        {
            return repo.LikeFilter(field, txt);
        }
    }


}