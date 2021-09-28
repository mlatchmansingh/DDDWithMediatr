using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.Automobiles.Dtos
{
    public class AutomobileSummaryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
