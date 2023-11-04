using Newtonsoft.Json;
using System;

namespace Hotel.Application.Dtos.Base
{
    public abstract class DtoBase
    {
        [JsonProperty("changeUser")]
        public int ChangeUser { get; set; }

        [JsonProperty("changeDate")]
        public DateTime ChangeDate { get; set; }
    }
}
