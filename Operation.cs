using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Planner
{
    [JsonDerivedType(typeof(Income), typeDiscriminator:"income")]
    [JsonDerivedType(typeof(Expense), typeDiscriminator:"expense")]
    internal abstract class Operation
    {
        public int Id { get; set; }
        public decimal OperationDecimal { get; set; }
        public static List<Operation> Operations = new();

        protected Operation(decimal operationDecimal)
        {
            if (Operations.Count == 0) Id = 0;
            else Id = Operations.Max(e => e.Id) + 1;
            OperationDecimal = operationDecimal;
            Operations.Add(this);
        }

        protected Operation()
        {
        }
    }
}
