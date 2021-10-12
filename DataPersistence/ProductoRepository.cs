using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto;
using DataPersistence.Contract;
using System.Data;
using System.Data.SqlClient;
using Common;
using Dapper;
using System.Configuration;
using Common.Log;

namespace DataPersistence
{
    public class ProductoRepository : IProductosRepository
    {
        private DbContextConfig _cxnString;
        public ProductoRepository(DbContextConfig cxnString)
        {
            _cxnString = cxnString;
        }
        public IEnumerable<Producto> Listar()
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                try
                {
                    cxn.Open();
                    var list = cxn.Query<Producto>("SP_SEL_PRODUCTOS", null, commandTimeout: 1200, commandType: CommandType.StoredProcedure);
                    cxn.Close();
                    return list;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Producto ListarPorId(int id)
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                var p = new DynamicParameters();
                p.Add("@IdProducto", id, DbType.Int32);
                var doc = cxn.QuerySingleOrDefault<Producto>("SP_SEL_PRODUCTOS_ID", p, commandType: CommandType.StoredProcedure);
                return doc == null ? null : doc;
            }
        }

        public bool AddEditProducto(Producto item)
        {
            bool result = false;
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                cxn.Open();
                using (var tran=cxn.BeginTransaction())
                {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("@IdProducto", item.IdProducto, DbType.Int32);
                        p.Add("@NombreProducto", item.NombreProducto, DbType.String);
                        p.Add("@IdProveedor", item.IdProveedor, DbType.Int32);
                        p.Add("@IdCategoria", item.IdCategoria, DbType.Int32);
                        p.Add("@CantidadPorUnidad", item.CantidadPorUnidad, DbType.String);
                        p.Add("@PrecioUnidad", item.PrecioUnidad, DbType.Decimal);
                        p.Add("@UnidadesEnExistencia", item.UnidadesEnExistencia, DbType.Int32);
                        cxn.Execute("SP_INS_PRODUCTO", p, tran, null, CommandType.StoredProcedure);

                        tran.Commit();
                        result = true;
                    }
                    catch(Exception ex)
                    {                            
                        result = false;
                        tran.Rollback();
                        throw ex;                        
                    }
                    finally
                    {
                        cxn.Close();
                        tran.Dispose();
                        cxn.Dispose();
                    }
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                cxn.Open();
                using (var tran = cxn.BeginTransaction())
                {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("@IdProducto", id, DbType.Int32);             
                        cxn.Execute("SP_DEL_PRODUCTO", p, tran, null, CommandType.StoredProcedure);
                        tran.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        tran.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        cxn.Close();
                        tran.Dispose();
                        cxn.Dispose();
                    }
                }
            }
            return result;
        }
    }
}
