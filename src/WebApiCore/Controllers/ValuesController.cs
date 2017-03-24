using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    //[Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        { 
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        { 
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(Value))]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            value.Text += "ok";
            return CreatedAtAction("Get", new Value() {Id = value.Id}, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class Value
        {
            public int Id { get; set; }
            [Required]
            public string Text { get; set; }
        }
    }
}
