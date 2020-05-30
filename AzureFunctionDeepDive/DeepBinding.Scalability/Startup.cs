using DeepDive.Extension.SQLBinding;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(DeepBinding.Scalability.Startup))]
namespace DeepBinding.Scalability
{
    public class Startup : FunctionsStartup
    {
		public override void Configure(IFunctionsHostBuilder builder)
		{
            builder.AddSqlBinding();
        }
	}
}
