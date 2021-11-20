using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Redi.DigitalTwin.Demo
{
    public static class Api
    {
        public class BottleItem
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }


        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "api")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("recognize")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [SignalR(HubName = "api")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var item = JsonConvert.DeserializeObject<BottleItem>(requestBody);

            if (item.Count == 0)
            {
                item.Count++;
            }

            await signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "onBottleRecognized",
                    Arguments = new object[] { item.Name, item.Count }
                });

            return new OkObjectResult(item);
        }
    }
}
