
using Newtonsoft.Json;
using System;
using System.Data;

namespace Hotel.Application.Dtos
{
    public abstract class DtoBase
    {
        [JsonProperty("changeUser")]
        public int ChangeUser { get; set; }

        [JsonProperty("changeDate")]
        public int IdUsuarioCreacion { get; set; }
        public DateTime ChangeDate { get; set; }
        
        public bool Eliminado { get; set; }


    }
}
