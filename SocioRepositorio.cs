using GimnasioMVC.Data;
using GimnasioMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GimnasioMVC.Repositorio
{
    public class SocioRepositorio : ISocioRepositorio
    {
       
        private readonly GimnasioContext _context;

        public SocioRepositorio(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Socio>> GetAllAsync()
        {
            return await _context.Socios.ToListAsync();
        }

        public async Task<Socio> GetByIdAsync(int id)
        {
            return await _context.Socios.FindAsync(id);
        }

        public async Task AddAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Socio socio)
        {
            _context.Socios.Update(socio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
                await _context.SaveChangesAsync();
            }
        }
    }
}