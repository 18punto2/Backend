using Application.Dto;
using Dapper;
using DataPersistence.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataPersistence
{
    public class MenuRepository : IMenuRepository
    {
        private DbContextConfig _cxnString;
        public MenuRepository(DbContextConfig cxnString)
        {
            _cxnString = cxnString;
        }

        public IEnumerable<Menu> Listar()
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                try
                {
                    cxn.Open();
                    var list = cxn.Query<Menu>("SP_SEL_MENU", null, commandTimeout: 1200, commandType: CommandType.StoredProcedure);
                    cxn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
