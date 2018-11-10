using System;
using System.Linq;
using System.Collections.Generic;
using HackOpay.Core.Domain;
using NPoco;
using NPoco.FluentMappings;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Data
{

    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        void AddParam(string key, object obj);
        string ApplySort(string sort);
        int Delete(TEntity obj);
        int DeleteFinal(TEntity obj);
        int Execute(string sql);
        TEntity Get(TKey id);
        List<TEntity> GetList(string sql);
        TEntity Insert(TEntity obj);
        Page<TEntity> SearchViewSQL(string sql, long page, long pagesize);
        TEntity Update(TEntity obj);
        string LikeFilter(string field, string txt);
    }

}