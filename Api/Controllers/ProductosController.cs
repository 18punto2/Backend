using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPersistence.Contract;
using System.Net;
using System.Configuration;
using Application.Dto;
using Api.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _IProductosRepository;
        public ProductosController(IProductosRepository IProductosRepository)
        {
            _IProductosRepository = IProductosRepository;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _IProductosRepository.Listar();
                return Ok(list);
            }
            catch(Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}",Name ="GetItem")]
        public IActionResult GetProducto(int id)
        {
            try
            {
                var list = _IProductosRepository.ListarPorId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return null;
            }
        }

        // POST api/<ProductosController>
   
        [HttpPost]
        public IActionResult Post([FromBody] Producto item)
        {            
            try
            {
                string msje = string.Empty;
                var result = _IProductosRepository.AddEditProducto(item);
                return Ok(item);
            }
            catch(Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto item)
        {
            try
            {
                var result = _IProductosRepository.AddEditProducto(item);
                return Ok(new { mensaje = "Item actualizado" }); 
            }
            catch(Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _IProductosRepository.Delete(id);
                return Ok(new { mensaje = "Item Eliminado" });
            }
            catch (Exception ex)
            {
                Log.logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
