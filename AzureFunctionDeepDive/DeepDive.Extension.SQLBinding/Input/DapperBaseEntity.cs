using System;
using System.Collections.Generic;
using System.Text;

namespace DeepDive.Extension.SQLBinding
{
   public class DapperEntity : IEntity
   {
      public int Id { get; set; }
   }

   public interface IEntity
   {
      int Id { get; set; }
   }
}
