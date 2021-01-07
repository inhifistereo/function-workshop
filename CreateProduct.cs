using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace inhifistereo.httptrigger1
{
    public static class CreateProduct
    {
        [FunctionName("CreateProduct")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "dpfuncbecuwork",
                collectionName: "productcontainer",
                ConnectionStringSetting = "CosmosDBConnectionString")]out dynamic document,
            ILogger log)
        {
             
            document = new { productDescription = "This starfruit ice cream is out of this world!", productId = "2424", productName = "Starfruit Explosion", timestamp = DateTime.Now };

            log.LogInformation($"C# Queue trigger function inserted one row");
        }
    }
}
