using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Configuration;


namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"CloudResume", containerName:"Counter", Connection = "CloudResumeConnectionString", Id ="1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"CloudResume", containerName:"Counter", Connection = "CloudResumeConnectionString", Id ="1", PartitionKey = "1")] out Counter updatedCounter,
            ILogger log)
        {
            // This is where the counter is updated.
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count +=1;

            var jsonToReturn = JsonConvert.SerializeObject(counter); 

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
