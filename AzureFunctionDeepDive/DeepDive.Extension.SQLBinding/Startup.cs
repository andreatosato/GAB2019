using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;

namespace DeepDive.Extension.SQLBinding
{
    public static class Extension
    {
        public static IFunctionsHostBuilder AddSqlBinding(this IFunctionsHostBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            builder.Services.AddWebJobs(x => { return; }).AddExtension<SqlInputConfiguration>();
            builder.Services.AddWebJobs(x => { return; }).AddExtension<SqlOutputConfiguration>();
            return builder;
        }
    }
}
