using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Sandbox.Serialization
{
    [JsonSerializable(typeof(User))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    public partial class SerializerContext : JsonSerializerContext
    {
    }
}
