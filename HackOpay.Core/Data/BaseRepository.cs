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

    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private List<object> prms;

        public virtual IDatabase Connection
        {
            get
            {
                return SqlitePoco.DbFactory.GetDatabase();
            }
        }

        public virtual TEntity Update(TEntity obj)
        {
            try
            {
                using (IDatabase db = Connection)
                {
                    obj.UpdatedAt = DateTime.UtcNow;
                    db.Update(obj);
                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity Insert(TEntity obj)
        {
            try
            {
                using (IDatabase db = Connection)
                {
                    obj.UpdatedAt = DateTime.UtcNow;
                    obj.CreatedAt = DateTime.UtcNow;
                    db.Insert(obj);
                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Delete(TEntity obj)
        {
            int i = 0;
            try
            {
                using (IDatabase db = Connection)
                {
                    obj.UpdatedAt = DateTime.UtcNow;
                    obj.RecordStatus = 3;
                    i = db.Update(obj);
                }
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Execute(string sql)
        {
            int i = 0;
            try
            {
                using (IDatabase db = Connection)
                {
                    i = db.Execute(sql, prms.ToArray());
                    prms = null;
                }
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int DeleteFinal(TEntity obj)
        {
            int i = 0;
            try
            {
                using (IDatabase db = Connection)
                {
                    i = db.Delete(obj);
                }
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity Get(TKey id)
        {
            try
            {
                using (IDatabase db = Connection)
                {
                    return db.SingleById<TEntity>(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void AddParam(string key, object obj)
        {
            if (prms == null)
            {
                prms = new List<object>();

            }

            prms.Add(obj);
        }

        public virtual List<TEntity> GetList(string sql)
        {
            using (IDatabase db = Connection)
            {
                try
                {
                    if (prms == null)
                    {
                        return db.Fetch<TEntity>(sql);
                    }
                    var t = db.Fetch<TEntity>(sql, prms.ToArray());
                    prms = null;
                    return t;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public virtual string ApplySort(string sort)
        {
            if (string.IsNullOrEmpty(sort))
            {
                return "";
            }
            var lst = new List<string>();
            var lstSort = sort.Split(',');
            foreach (var sortOption in lstSort.Reverse())
            {
                if (sortOption.StartsWith("-"))
                {
                    lst.Add(sortOption.Remove(0, 1) + " desc");
                }
                else
                {
                    lst.Add(sortOption);
                }
            }
            return " Order by " + string.Join(",", lst);
        }

        public virtual NPoco.Page<TEntity> SearchViewSQL(string sql, long page, long pagesize)
        {
            using (IDatabase db = Connection)
            {
                try
                {
                    if (prms == null)
                    {
                        return db.Page<TEntity>(page, pagesize, sql);
                    }
                    var t = db.Page<TEntity>(page, pagesize, sql, prms.ToArray());
                    prms = null;
                    return t;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public virtual string LikeFilter(string field, string txt)
        {
            return txt;
        }
    }

}