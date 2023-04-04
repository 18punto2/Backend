using Api.Util;
using DataPersistence.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacimoController : ControllerBase
    {

        private readonly IRacimoRepository _IRacimoRepository;
        public RacimoController(IRacimoRepository IRacimoRepository)
        {
            _IRacimoRepository = IRacimoRepository;
        }

        [Route("ListarRacimos")]
        [HttpGet]
        public IActionResult ListarRacimos(DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                ///fecha_ini = Convert.ToDateTime("1996-10-11");
                //fecha_fin = Convert.ToDateTime("1997-01-11");
                var user = _IRacimoRepository.Listar(fecha_ini, fecha_fin);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
