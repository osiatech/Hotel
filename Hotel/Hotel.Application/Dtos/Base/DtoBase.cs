using Newtonsoft.Json;
using System;

namespace Hotel.Application.Dtos.Base
{
    public abstract class DtoBase
    {
        [JsonProperty("changeUser")]
        public int ChangeUser { get; set; }

        [JsonProperty("changeDate")]
        public int IdCreationUser { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool Deleted { get; set; }
    }
}
