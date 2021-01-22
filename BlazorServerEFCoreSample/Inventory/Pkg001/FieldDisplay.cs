using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Pkg001
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
    public record FieldDisplay
    {
        public int FieldIndex { get; init; }
        public string Display { get; init; }

    }
}
