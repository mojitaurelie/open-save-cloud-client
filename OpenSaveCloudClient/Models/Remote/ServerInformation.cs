using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models.Remote
{
    public class ServerInformation
    {
        [JsonPropertyName("allow_register")]
        public bool AllowRegister { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("api_version")]
        public int ApiVersion { get; set; }

        [JsonPropertyName("go_version")]
        public string GoVersion { get; set; }

        [JsonPropertyName("os_name")]
        public string OsName { get; set; }

        [JsonPropertyName("os_architecture")]
        public string OsArchitecture { get; set; }
    }
}
