using System;
using System.Collections.Generic;
using System.Fabric;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using ConfigManager;

namespace ConfigMgmtSvc.Controllers
{
    public class ConfigController : ApiController
    {
        
        public IEnumerable<string> Get(string key)

        {
            return new string[] { "value1asas", "value2" };
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

        
        [Route("api/config/{appKey}/get")]
        [HttpGet]
        public async Task<IHttpActionResult> getconfig([FromUri] string appKey)
        {
            /*
             * 
             * IMyService helloWorldClient = ServiceProxy.Create<IMyService>(new Uri("fabric:/MyApplication/MyHelloWorldService"));

                string message = await helloWorldClient.GetHelloWorld();
             */
            try
            {
                var config =
                    ServiceProxy.Create<IConfigManager>(
                        new Uri("fabric:/ConfigurationManagementService/ConfigManager"));
                var result = await config.GetApplicationConfiguration(appKey);
                return Ok(result);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.ToString());
            }  
            return Ok();
        }
    }
}
