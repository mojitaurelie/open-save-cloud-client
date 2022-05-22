using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models.Remote
{
    public class NewGameInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
