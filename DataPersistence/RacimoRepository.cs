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
    public class RacimoRepository: IRacimoRepository
    {
        private DbContextConfig _cxnString;
        public RacimoRepository(DbContextConfig cxnString)
        {
            _cxnString = cxnString;
        }

        public IEnumerable<Racimo> Listar(DateTime fecha_ini, DateTime fecha_fin)
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("@FECHA_INI", fecha_ini, DbType.DateTime);
                    p.Add("@FECHA_FIN", fecha_fin, DbType.DateTime);
                    var list = cxn.Query<Racimo>("SP_S_ListarRacimos", p, commandType: CommandType.StoredProcedure);                    
                    cxn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
