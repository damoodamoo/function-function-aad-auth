using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Services.AppAuthentication;
using System.Net.Http;

namespace ADFuncClient
{
    public static class FuncClient
    {
        [FunctionName("ADFuncClient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // new up a token provider. this handles getting the token from AAD for us
            var tokenProvider = new AzureServiceTokenProvider();
            var token = await tokenProvider.GetAccessTokenAsync("<client-id-of-AD-Function-App");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync("https://<hostname>.azurewebsites.net/api/ADFunctionApp");

            return new OkObjectResult(await response.Content.ReadAsStringAsync());

        }
    }
}
