using System.Configuration;

namespace Common
{
    public class keys
    {
        public static string GetConexion()
        {
            return ConfigurationManager.ConnectionStrings["Sql_cxn"].ConnectionString;
            //return "Data Source=.;Initial Catalog=NegocioWeb;Persist Security Info=false;User ID=sa;Password=sql";
        }
        public static string sqlCxn = "Data Source=.;Initial Catalog=NegocioWeb;Persist Security Info=false;User ID=sa;Password=sql";
    }
}
