using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DeepDive.Extension.SQLBinding;
using DeepBinding.Models;

namespace DeepBinding
{
   public static class SqlReaderFunction
   {
      [FunctionName("SqlReader")]
      public static async Task<IActionResult> Run(
          [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
          [SQLInputBinding(Query = "SELECT * FROM TestData")]
          ReadModel entity,
          ILogger log)
      {
         log.LogInformation("C# HTTP trigger function processed a request.");

         //log.LogInformation($"{entity.Name}");
         //string name = req.Query["name"];

         //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
         //dynamic data = JsonConvert.DeserializeObject(requestBody);
         //name = name ?? data?.name;

         return new OkObjectResult($"Hello");
      }
   }
}
