using DeepDive.Extension.SQLBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepBinding.Models
{
   public class ReadModel : DapperEntity, IEntity
    {
      public string Name { get; set; }
      public DateTime Birthday { get; set; }
   }
}
