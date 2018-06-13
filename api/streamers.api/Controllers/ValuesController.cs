using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using streamers.api.Sql;

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
                Thread.Sleep(2);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/stream/database
        [HttpGet("stream/database")]
        public object GetDBStreamValues()
        {
            IEnumerable<object> databaseResult()
            {
                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Accept, Content-Type, Content-Encoding, Server, Transfer-Encoding");

                return StreamBulkData.DataReaderReturnData();
            }
            return new { streamResult = databaseResult() };
        }

        // GET api/values/nonstream/database
        [HttpGet("nonstream/database")]
        public object GetDBValues()
        {
            IEnumerable<object> databaseResult()
            {
                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Accept, Content-Type, Content-Encoding, Server, Transfer-Encoding");

                return StreamBulkData.DataAdapterReturnData();
            }
            return new { nonStreamResult = databaseResult() };
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
