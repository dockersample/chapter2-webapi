using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace chapter1_webapi
{
    public class JsonHelper
    {
        public static string ToJson(object data)
        {
            var jsonSerializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            var jsonWriter = new JsonTextWriter(stringWriter);
            jsonSerializer.Serialize(jsonWriter, data);

            return stringWriter.ToString();

        }
    }
}