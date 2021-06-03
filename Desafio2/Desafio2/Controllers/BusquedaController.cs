using Desafio2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        ResultModel model = new ResultModel();
        // GET: api/<BusquedaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BusquedaController>/5
        [HttpGet("{term}")]
        public List<Results> Get(string term)
        {
            return model.BuscarTermino(term);
        }

        // POST api/<BusquedaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusquedaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusquedaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
