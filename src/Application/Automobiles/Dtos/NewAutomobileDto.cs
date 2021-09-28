using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.Automobiles.Dtos
{
    public class NewAutomobileDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
