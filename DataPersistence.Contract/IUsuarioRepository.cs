using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPersistence.Contract
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> Listar();
        Usuario ListarPorId(int id);
        Mensaje AddEditItem(Usuario item);
        bool Delete(int id);
        IEnumerable<Usuario> Login(string usuario, string password);
    }
}
