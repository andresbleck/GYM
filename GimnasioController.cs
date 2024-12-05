using AutoMapper;
using GimnasioMVC.Dto;
using GimnasioMVC.Models;
using GimnasioMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;


public class ClasesController : Controller
{
    private readonly IClaseRepositorio _claseRepository;
    private readonly IMapper _mapper;

    public ClasesController(IClaseRepositorio claseRepository, IMapper mapper)
    {
        _claseRepository = claseRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clases = await _claseRepository.GetAllAsync();
        var clasesDto = _mapper.Map<IEnumerable<ClaseDto>>(clases);
        return View(clasesDto);
    }

    // Método GET para la vista de crear clase
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Método POST para crear clase
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClaseDto claseDto)
    {
        if (ModelState.IsValid)
        {
            var clase = _mapper.Map<Clase>(claseDto);
            await _claseRepository.AddAsync(clase);
            return RedirectToAction("Index");
        }

        return View(claseDto);
    }

    // Método GET para editar clase
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var clase = await _claseRepository.GetByIdAsync(id);
        if (clase == null)
        {
            return NotFound();
        }

        // Mapear la clase a un Dto para editar
        var claseDto = _mapper.Map<ClaseDto>(clase);
        return View(claseDto);
    }

    // Método POST para actualizar clase
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClaseDto claseDto)
    {
        if (ModelState.IsValid)
        {
            var clase = _mapper.Map<Clase>(claseDto);
            await _claseRepository.UpdateAsync(clase);
            return RedirectToAction("Index");
        }

        return View(claseDto);
    }

    // Metodo GET para eliminar clase
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var clase = await _claseRepository.GetByIdAsync(id);
        if (clase == null)
        {
            return NotFound();
        }

        // Mapear la clase a un Dto para eliminar
        var claseDto = _mapper.Map<ClaseDto>(clase);
        return View(claseDto);
    }

    // Método POST para confirmar la eliminación de la clase
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var clase = await _claseRepository.GetByIdAsync(id);
        if (clase == null)
        {
            return NotFound();
        }

        await _claseRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}