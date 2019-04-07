using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace DeepDive.Extension.SQLBinding
{
   [Binding]
   [AttributeUsage(AttributeTargets.Parameter)]
   public sealed class SQLInputBindingAttribute : Attribute
   {
      [AppSetting(Default = "SqlInputConnectionString")]
      [Required]
      public string SqlConnectionString { get; set; }

      [AutoResolve(ResolutionPolicyType = typeof(SqlResolutionPolicy))]
      [Required]
      public string Query { get; set; }

      internal List<SqlParameter> Parameters { get; set; }
   }
}
