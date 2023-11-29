namespace Hotel.Web.Models.Responses
{
    public class CategoriaListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CategoriaViewResult> data { get; set; }
    }
    public class CategoriaViewResult
    {
        public int idCategoria { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
