using System.ComponentModel.DataAnnotations;

namespace GimnasioMVC.Models
{
        public class Clase
        {
        public int Id { get; set; }
        public required string NombreClase { get; set; }
        public required int Duracion { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Horario { get; set; }
    }
    
}
