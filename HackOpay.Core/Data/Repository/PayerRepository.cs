using HackOpay.Core.Domain;
using NPoco;

namespace HackOpay.Core.Data.Repository
{

    public class PayerRepository : BaseOpayRepository<Payer, int>
    {
        public Page<Payer> Search(string name = "", string mobile = "",
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var sql = "where Id > 0 and recordstatus in (0,1,2) ";
            var c = 0;
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and " + repo.LikeFilter("Name", name);
            }
            if (!string.IsNullOrEmpty(mobile))
            {
                sql += $" and Mobile = @{c} ";
                repo.AddParam("mobile", mobile);
                c++;
            }
             

            if (page <= 0)
            {
                var l = repo.GetList(sql);
                return new Page<Payer>()
                {
                    CurrentPage = 0,
                    Items = l,
                    ItemsPerPage = 0,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }


            sql += repo.ApplySort(sort);
            var k = repo.SearchViewSQL(sql, page, pageSize);
            return new Page<Payer>()
            {
                CurrentPage = k.CurrentPage,
                Items = k.Items,
                ItemsPerPage = k.ItemsPerPage,
                TotalItems = k.TotalItems,
                TotalPages = k.TotalPages
            };
        }


    }

    public class BankRepository : BaseOpayRepository<Bank, int>
    {
        public Page<Bank> Search(string name = "",
            long page = 1, long pageSize = 10, string sort = "Id")
        {
            var sql = "where Id > 0 and recordstatus in (0,1,2) ";
            //var c = 0;
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and " + repo.LikeFilter("Name", name);
            } 


            if (page <= 0)
            {
                var l = repo.GetList(sql);
                return new Page<Bank>()
                {
                    CurrentPage = 0,
                    Items = l,
                    ItemsPerPage = 0,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }


            sql += repo.ApplySort(sort);
            var k = repo.SearchViewSQL(sql, page, pageSize);
            return new Page<Bank>()
            {
                CurrentPage = k.CurrentPage,
                Items = k.Items,
                ItemsPerPage = k.ItemsPerPage,
                TotalItems = k.TotalItems,
                TotalPages = k.TotalPages
            };
        }


    }


}