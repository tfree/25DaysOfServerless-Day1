using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TFreedman.Function
{
    public static class SpinDreidel
    {
        [FunctionName("SpinDreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string[] side = {"נ","ג","ה","ש"};
            Random rnd = new Random();
            int sideIndex = rnd.Next(side.Length);
            return (ActionResult)new OkObjectResult(side[sideIndex]);
        }
    }
}
