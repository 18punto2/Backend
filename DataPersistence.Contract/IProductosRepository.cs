using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto;

namespace DataPersistence.Contract
{
    public interface IProductosRepository
    {
        IEnumerable<Producto> Listar();
        Producto ListarPorId(int id);
        bool AddEditProducto(Producto item);
        bool Delete(int id);
    }
}
