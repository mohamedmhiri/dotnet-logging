using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;

namespace LoggingExample.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/values
        public IEnumerable<string> Get()
        {
            var values = new string[] { "value11", "value21" };
            for (int i = 0; i < 100; i++)
            {
                log.Info("values: {0} and {1} have been generated", values[0], values[1]);
                log.Error("values: {0} and {1} have been generated", values[0], values[1]);
                log.Warn("values: {0} and {1} have been generated", values[0], values[1]);
                log.Debug("values: {0} and {1} have been generated", values[0], values[1]);
                log.Fatal("values: {0} and {1} have been generated {2}", values[0], values[1], Request.GetCorrelationId());
            }




            var res = Request.CreateResponse(HttpStatusCode.OK, values);
            res.Headers.Add("X_Correlation-Id", Request.GetCorrelationId().ToString());
            return res;
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
