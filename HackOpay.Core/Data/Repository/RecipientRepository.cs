using System;
using System.Linq;
using System.Collections.Generic;
using HackOpay.Core.Domain;
using NPoco;

namespace HackOpay.Core.Data.Repository
{

    public class RecipientRepository : BaseOpayRepository<Recipient, int>
    {
        public Page<Recipient> Search(string name = "", string mobile = "", string email = "",
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


            if (!string.IsNullOrEmpty(email))
            {
                sql += $" and Email = @{c} ";
                repo.AddParam("email", email);
                c++;
            }


            if (page <= 0)
            {
                var l = repo.GetList(sql);
                return new Page<Recipient>()
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
            return new Page<Recipient>()
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