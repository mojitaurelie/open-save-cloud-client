﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models.Remote
{
    public class UploadGameInfo
    {
        [JsonPropertyName("game_id")]
        public long GameId { get; set; }
    }
}
