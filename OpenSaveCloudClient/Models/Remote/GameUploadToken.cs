using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models.Remote
{
    public class GameUploadToken
    {
        [JsonPropertyName("upload_token")]
        public string UploadToken { get; set; }
        [JsonPropertyName("expire")]
        public string Expire { get; set; }

    }
}
