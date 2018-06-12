using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace streamers.api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public object Get()
        {
            return new { resultset = getItems() };
        }

        IEnumerable<object> getItems()
        {
            
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Accept, Content-Type, Content-Encoding, Server, Transfer-Encoding");

            for (var i = 0; i < 10000; i++)
            {
                yield return new { name = "item" + i, description = "description " + i };
                Thread.Sleep(10);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
    }
}
