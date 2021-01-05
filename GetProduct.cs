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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "dpfuncbecuwork",
                collectionName: "productcontainer",
                Id = "Query.id",
                PartitionKey = "/productId",
                ConnectionStringSetting = "CosmosDBConnectionString")] Products product,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string productId = req.Query["productId"];

            if (product == null)
            {
                log.LogInformation($"product item not found");
            }
            else
            {
                log.LogInformation($"Found item, Description={product.productDescription}");
            }
            return new OkResult();

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //productId = productId ?? data?.productId;

            //string responseMessage = string.IsNullOrEmpty(productId)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"The product name for your product id {productId} is Starfruit Explosion.";

            //return new OkObjectResult(responseMessage);
        }
    }
}
