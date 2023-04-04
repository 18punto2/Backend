using Application.Dto;
using Dapper;
using DataPersistence.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataPersistence
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DbContextConfig _cxnString;
        public UsuarioRepository(DbContextConfig cxnString)
        {
            _cxnString = cxnString;
        }
        public Mensaje AddEditItem(Usuario item)
        {
            Mensaje result = new Mensaje();
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {               
                try
                {
                    cxn.Open();
                    var p = new DynamicParameters();
                    p.Add("@Usuario", item.usuario, DbType.String);
                    p.Add("@Nombre", item.nombre, DbType.String);
                    p.Add("@Apellido", item.apePaterno, DbType.String);
                    p.Add("@ApeMaterno", item.apeMaterno, DbType.String);
                    p.Add("@FlagActivo", item.flagActivo, DbType.Boolean);
                    p.Add("@Id_Perfil", item.idPerfil, DbType.Int32);
                    p.Add("@Clave", item.clave, DbType.String);
                    p.Add("@TIPO", item.Accion, DbType.Int32);
                    //p.Add("@UsuarioRegistro", item.usuarioregistro, DbType.String);
                    var list = cxn.Query<Mensaje>("SP_INS_USP_Usuario", p, commandType: CommandType.StoredProcedure);
                    if (list != null && list.Count() > 0)
                    {
                        foreach (var _item in list)
                        {
                            result.errNumber = _item.errNumber;
                            result.errMessage = _item.errMessage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cxn.Close();
                }

            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Listar()
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                try
                {
                    cxn.Open();
                    var list = cxn.Query<Usuario>("Ext_SP_S_ListaUsuarios", null, commandTimeout: 1200, commandType: CommandType.StoredProcedure);
                    cxn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Usuario ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Login(string usuario, string password)
        {
            using (IDbConnection cxn = new SqlConnection(_cxnString.Connection))
            {
                try
                {
                    cxn.Open();
                    var p = new DynamicParameters();
                    p.Add("@Usuario", usuario, DbType.String);
                    p.Add("@Clave", password, DbType.String);
                    var list = cxn.Query<Usuario>("Ext_SP_S_Validar_Usuario", p, commandType: CommandType.StoredProcedure);                    
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
