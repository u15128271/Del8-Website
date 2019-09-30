using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexVM
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        TBmEntities context = new TBmEntities();
        public IPagedList<Inventory> ListOfProducts { get; set; }
        public HomeIndexVM CreateModel(string search,int pageSize, int? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Inventory> data = context.Database.SqlQuery<Inventory>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexVM
            {
                ListOfProducts = data
            };
        }
    }
}