using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi0903.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("JsonFormatterSupportedEncodings")]
        public IHttpActionResult Get()
        {
            return Ok(GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedEncodings.ToList());
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
