using Desafio1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {

       PaisModel model = new PaisModel();

        // GET: api/<PaisesController>
        [HttpGet]
        public List<Paises> Get()
        {
            return model.GetPaises();
        }

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public Paises Get(string id)
        {
            return model.BuscarPais(id);
        }

        // POST api/<PaisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
