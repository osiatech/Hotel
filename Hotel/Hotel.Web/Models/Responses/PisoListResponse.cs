namespace Hotel.Web.Models.Responses
{
    public class PisoListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<PisoViewResult> data { get; set; }

    }

    public class PisoViewResult
    {
        public int IdPiso { get; set; }
        public string descripcion { get; set; }
        public bool? estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
