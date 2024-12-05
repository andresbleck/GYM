using GimnasioMVC.Models;

namespace GimnasioMVC.Dto
{
    public class SocioDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string NumeroDeTelefono { get; set; }
    }
}
