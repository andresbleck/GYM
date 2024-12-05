using GimnasioMVC.Models;

namespace GimnasioMVC.Repositorio
{
    public interface IClaseRepositorio
    {
        Task<IEnumerable<Clase>> GetAllAsync(); // Mostrar todas las clases
        Task<Clase> GetByIdAsync(int id); // Obtener una clase por su id
        Task AddAsync(Clase clase); // Agregar una nueva clase
        Task UpdateAsync(Clase clase); // Actualizar los datos de una clase
        Task DeleteAsync(int id); // Eliminar una clase por su id
    }
}