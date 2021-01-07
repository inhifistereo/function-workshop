using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace function
{
    public static class GetProduct
    {
        [FunctionName("GetProduct")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetProduct/{productId}/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: "dpfuncbecuwork",
                collectionName: "productcontainer",
                Id = "{id}",
                PartitionKey = "{productId}",
                ConnectionStringSetting = "CosmosDBConnectionString")] Products product,
            ILogger log)
        {
            log.LogInformation($"Searching for item");
  
            if (product == null)
            {
                log.LogInformation($"product item not found");
                return new OkObjectResult("Product not found");
            }
            else
            {
                log.LogInformation($"Found item, Description={product.productDescription}");
                return new OkObjectResult(product);
            }
        }
    }
}
