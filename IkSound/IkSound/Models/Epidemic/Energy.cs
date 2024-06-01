﻿using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Energy
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}