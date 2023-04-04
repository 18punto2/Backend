using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPersistence.Contract
{
    public interface IRacimoRepository
    {
        IEnumerable<Racimo> Listar(DateTime fecha_ini,DateTime fecha_fin);
    }
}
