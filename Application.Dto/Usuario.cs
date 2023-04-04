using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string perfil { get; set; }
        public bool flagActivo { get; set; }
        public int idPerfil { get; set; }
        public string clave { get; set; }
        public int Accion { get; set; }
        public DateTime fecharegistro { get; set; }
        public string usuarioregistro { get; set; }        
    }
}
