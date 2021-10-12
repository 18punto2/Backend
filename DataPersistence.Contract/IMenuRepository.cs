using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPersistence.Contract
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> Listar();
    }
}
