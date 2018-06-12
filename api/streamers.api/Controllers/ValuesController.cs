using System;
using System.Collections.Generic;
using System.Linq;
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
            yield return new { name = "item1", description = "description 1" };
            yield return new { name = "item2", description = "description 2" };
            yield return new { name = "item3", description = "description 3" };
            yield return new { name = "item4", description = "description 4" };
            yield return new { name = "item5", description = "description 5" };
            yield return new { name = "item6", description = "description 6" };
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
