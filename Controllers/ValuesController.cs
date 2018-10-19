using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace chapter1_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        ILogger<ValuesController> _logger;
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ContentResult Get(
            [FromServices]IConfiguration config)
        {


            using (SqlConnection connection = new SqlConnection(
                config.GetConnectionString("Dapper_SQLServer")))
            {   
                object data = "";

                try
                {
                        data = connection.Query<userdata>(
                        "SELECT id " +
                              ",name " +
                              ",sex " +
                        "FROM dbo.userdata " +
                        "ORDER BY id "
                        );

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ur code iz buggy.");
                }
                return Content(JsonHelper.ToJson(data), "application/json");
            }
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
