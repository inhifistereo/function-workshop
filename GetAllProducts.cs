using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace function
{
    public static class GetAllProducts
    {
        [FunctionName("GetAllProducts")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "dpfuncbecuwork",
                collectionName: "productcontainer",
                ConnectionStringSetting = "CosmosDBConnectionString",
                SqlQuery = "SELECT * FROM c")] 
                IEnumerable<Products> products,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(products);

        }
    }
}
