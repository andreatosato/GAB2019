using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace DeepDive.Extension.SQLBinding
{
   public class SQLInputConfiguration : IExtensionConfigProvider
   {
      public void Initialize(ExtensionConfigContext context)
      {
         context
            .AddBindingRule<SQLInputBindingAttribute>()
            .BindToInput<OpenType>(typeof(SqlServerBuilder<>));
      }

   }

    internal class SqlServerBuilder<T> : IAsyncConverter<SQLInputBindingAttribute, T> where T : class
    {
        public async Task<T> ConvertAsync(SQLInputBindingAttribute input, CancellationToken cancellationToken)
        {
            var data = default(T);

            using (var connection = new SqlConnection(input.SqlConnectionString))
            {
                var parameters = new DynamicParameters(new { });
                input.Parameters.ForEach(param => parameters.Add(param.ParameterName, param.Value));

                data = await connection.QuerySingleAsync<T>(new CommandDefinition(input.Query, parameters)).ConfigureAwait(false);
            }

            return data;
        }
    }
}
