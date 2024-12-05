using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GimnasioMVC.Dto;
using GimnasioMVC.Models;
using GimnasioMVC.Repositorio;

namespace TrabajoFinal.Controllers
{
    public class SociosController : Controller
    {
        private readonly ISocioRepositorio _socioRepository;
        private readonly IMapper _mapper;

        public SociosController(ISocioRepositorio socioRepository, IMapper mapper)
        {
            _socioRepository = socioRepository;
            _mapper = mapper;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
            var socios = await _socioRepository.GetAllAsync();
            var sociosDto = _mapper.Map<IEnumerable<SocioDto>>(socios);
            return View(sociosDto);
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var socio = await _socioRepository.GetByIdAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            var socioDto = _mapper.Map<SocioDto>(socio);
            return View(socioDto);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocioDto socioDto)
        {
            if (ModelState.IsValid)
            {
                var socio = _mapper.Map<Socio>(socioDto);
                await _socioRepository.AddAsync(socio); // Usamos AddAsync y await
                return RedirectToAction(nameof(Index));
            }
            return View(socioDto);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var socio = await _socioRepository.GetByIdAsync(id); // Usamos GetByIdAsync y await
            if (socio == null)
            {
                return NotFound();
            }
            var socioDto = _mapper.Map<SocioDto>(socio);
            return View(socioDto);
        }

        // POST: Socios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SocioDto socioDto)
        {
            if (id != socioDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var socio = _mapper.Map<Socio>(socioDto);
                await _socioRepository.UpdateAsync(socio);
                return RedirectToAction(nameof(Index));
            }
            return View(socioDto);
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var socio = await _socioRepository.GetByIdAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            var socioDto = _mapper.Map<SocioDto>(socio);
            return View(socioDto);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socio = await _socioRepository.GetByIdAsync(id);
            if (socio != null)
            {
                await _socioRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}