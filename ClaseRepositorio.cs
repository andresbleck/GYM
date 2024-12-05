using GimnasioMVC.Data;
using GimnasioMVC.Models;
using Microsoft.EntityFrameworkCore;
using static GimnasioMVC.Repositorio.ClaseRepositorio;

namespace GimnasioMVC.Repositorio
{
    public class ClaseRepositorio : IClaseRepositorio
    {
        
         
        private readonly GimnasioContext _context;

        public ClaseRepositorio(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            return await _context.Clases.ToListAsync();
        }

        public async Task<Clase> GetByIdAsync(int id)
        {
            return await _context.Clases.FindAsync(id);
        }

        public async Task AddAsync(Clase clase)
        {
            await _context.Clases.AddAsync(clase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Clase clase)
        {
            _context.Clases.Update(clase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }
    }
}