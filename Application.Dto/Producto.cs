using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal UnidadesEnExistencia { get; set; }
        public int TotalRows { get; set; }
        
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
    }
}
