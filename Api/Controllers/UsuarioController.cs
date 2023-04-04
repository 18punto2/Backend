using Application.Dto;
using DataPersistence.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Api.Util;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public UsuarioController(IUsuarioRepository IUsuarioRepository)
        {
            _IUsuarioRepository = IUsuarioRepository;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _IUsuarioRepository.Listar();
                return Ok(list);
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario item)
        {
            try
            {
                var result = new Mensaje();
                result = _IUsuarioRepository.AddEditItem(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Usuario item)
        {
            try
            {
                var result = new Mensaje();

                var itemEdit = new Usuario()
                {
                    nombre = item.nombre,
                    apePaterno = item.apePaterno,
                    apeMaterno = item.apeMaterno,
                    clave = item.clave,
                    idPerfil = item.idPerfil,
                    flagActivo=item.flagActivo,
                    usuario= id,
                    Accion=1
                };
                result = _IUsuarioRepository.AddEditItem(itemEdit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string usuario,string password)
        {            
            try
            {          
                var user = _IUsuarioRepository.Login(usuario, password);
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
