using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinhaAPICore.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos() {
            var valores = new string[] { "value1", "value2", "value3" };

            if (valores.Length < 5000)
                return BadRequest();

            return valores;
        }

        [HttpGet]
        public ActionResult ObterResultado() {
            var valores = new string[] { "value1", "value2", "value3" };

            if (valores.Length < 5000)
                return BadRequest();

            return Ok(valores);
        }

        [HttpGet("obter-valores")]
        public IEnumerable<string> ObterValores() {
            var valores = new string[] { "value1", "value2", "value3" };

            if (valores.Length < 5000)
                return null;

            return valores;
        }

        // GET api/values/obter-por-id/5
        [HttpGet("obter-por-id/{id:int}")]
        public ActionResult<string> Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult Post([FromBody] Product product) {

            if (product.Id == 0) return BadRequest();

            // add no banco
            //return Ok(product);
            return CreatedAtAction(nameof(Post), product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromForm] Product product) {

            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return BadRequest();

            // add no banco
            return Ok(product);
            //return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromQuery] int id) {
        }
    }

    public class Product {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
