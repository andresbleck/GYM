namespace GimnasioMVC.Dto
{
    public class ClaseDto
    {
        public int Id { get; set; }
        public required string NombreClase { get; set; }
        public required int Duracion { get; set; }
        public required DateOnly Fecha { get; set; }
        public required TimeOnly Horario { get; set; }
    }
}
