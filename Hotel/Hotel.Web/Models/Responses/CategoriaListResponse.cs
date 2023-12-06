namespace Hotel.Web.Models.Responses
{
    public class CategoriaListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List <CategoriaViewResult> data { get; set; }
    }
    public class CategoriaViewResult
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
