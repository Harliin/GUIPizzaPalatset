using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GUI_Beställning.Models.Data
{
    public class ExchangeRates
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("rates")]
        public Dictionary<string, float> Rates { get; set; }
    }
}
