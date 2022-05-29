using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models.Remote
{
    public class NewPassword
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("verify_password")]
        public string VerifyPassword { get; set; }
    }
}
