using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Notifications.Functions
{
    public static class CheckPastDueBooks
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            //Call Books service API to retrieve book list 
            //Define which books 
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //services.AddHttpClient<ICatalogService, CatalogService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            //})
        }
    }
}
