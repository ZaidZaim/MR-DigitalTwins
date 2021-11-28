// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Azure.DigitalTwins.Core;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Core.Pipeline;
using System.Threading.Tasks;
using Azure.Messaging.EventGrid;
using Azure;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Ltwlf.DigitalTwin
{
    public class CustomDigitalTwin
    {
        [JsonPropertyName("$dtId")]
        public string Id { get; set; }

        [JsonPropertyName("$etag")]
        public string ETag { get; set; }

        [JsonPropertyName("storage")]
        public Dictionary<string, Int32> Storage { get; set; }
    }

    public class TwinsFunction
    {
        //Your Digital Twins URL is stored in an application setting in Azure Functions.
        private static readonly string adtInstanceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("TwinsFunction")]
        public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
            if (adtInstanceUrl == null) log.LogError("Application setting \"ADT_SERVICE_URL\" not set");
            try
            {
                var cred = new DefaultAzureCredential();

                //Authenticate with Digital Twins.
                //ManagedIdentityCredential cred = new ManagedIdentityCredential("https://digitaltwins.azure.net");
                DigitalTwinsClient client = new DigitalTwinsClient(new Uri(adtInstanceUrl), cred, new DigitalTwinsClientOptions { Transport = new HttpClientTransport(httpClient) });
                log.LogInformation($"Azure digital twins service client connection created.");
                if (eventGridEvent != null && eventGridEvent.Data != null)
                {
                    log.LogInformation(eventGridEvent.Data.ToString());

                    // Read deviceId and temperature for IoT Hub JSON.
                    JObject deviceMessage = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
                    string deviceId = (string)deviceMessage["systemProperties"]["iothub-connection-device-id"];
                    //string twinId = (string)deviceMessage["systemProperties"]["iothub-connection-device-id"];
                    string dtId = (string)deviceMessage["properties"]["dtId"];

                    string dataBase64 = (string)deviceMessage["body"];
                    var base64EncodedBytes = System.Convert.FromBase64String(dataBase64);
                    string json = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    var jData = (JObject)JsonConvert.DeserializeObject(json);

                    var detections = (JArray)jData["NEURAL_NETWORK"];
                    foreach (JObject obj in detections)
                    {
                        log.LogDebug(obj["label"].ToString());
                    }

                    // var result = client.QueryAsync<CustomDigitalTwin>("SELECT * FROM digitaltwins");

                    // await foreach (CustomDigitalTwin x in result)
                    // {
                    //     Console.WriteLine($"Found digital twin '{x.Id}'");
                    // }

                    var twin = await client.GetDigitalTwinAsync<CustomDigitalTwin>(dtId);
                    log.LogDebug(twin.Value.Storage["coke"].ToString());
                    //var storage = twin.Value.Contents["storage"];

                    // var chasistemperature = deviceMessage["body"]["ChasisTemperature"];
                    // log.LogInformation($"Device:{deviceId} Temperature is:{chasistemperature}");

                    //Update twin by using device temperature.
                    // var patch = new Azure.JsonPatchDocument();
                    //  patch.AppendReplace<double>("/ChasisTemperature", chasistemperature.Value<double>());

                    // await client.UpdateDigitalTwinAsync(deviceId, patch);
                }
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
            }

        }
    }
}
