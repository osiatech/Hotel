namespace Hotel.API.Models.Core
{
    public class UsuarioBaseModel : ModelBase
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
    }
}
