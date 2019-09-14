using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexVM
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        TBMEntities context = new TBMEntities();
        public IEnumerable<Inventory> ListOfProducts { get; set; }
        public HomeIndexVM CreateModel(string search)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IEnumerable<Inventory> data = context.Database.SqlQuery<Inventory>("GetBySearch @search", param).ToList();
            return new HomeIndexVM
            {
                ListOfProducts = data
            };
        }
    }
}