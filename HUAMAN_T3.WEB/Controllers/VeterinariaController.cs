using HUAMAN_T3.WEB.DB;
using HUAMAN_T3.WEB.Models;
using HUAMAN_T3.WEB.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace HUAMAN_T3.WEB.Controllers;

public class VeterinariaController : Controller
{
    private readonly IVeterinariaRepositorio _veterinariaRepositorio;
    private DbEntities _dbEntities;
    
    public VeterinariaController(IVeterinariaRepositorio veterinariaRepositorio, DbEntities dbEntities)
    {
        _veterinariaRepositorio = veterinariaRepositorio;
        _dbEntities = dbEntities;
    }

    // GET
    public IActionResult Index()
    {
        var historias = _veterinariaRepositorio.ObtenerHistorias();
        // return View(NOTAS);
       
        return View(historias);
    }
    
    [HttpGet]
    public IActionResult Create(int id)
    {
        ViewBag.Id = id;
        return View(new Veterinaria());
    }
    
    [HttpPost]
    public IActionResult Guardar(Veterinaria veterinaria)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.notas = _veterinariaRepositorio.ObtenerHistorias();
            return View("Create", veterinaria);
        }

       
        _veterinariaRepositorio.GuardarHistorias(veterinaria);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
       
        _veterinariaRepositorio.EliminarHistorias(id);
        return RedirectToAction("Index");
    }
    
    
    public IActionResult Edit(int id)
    {
       
        
        var historias = _veterinariaRepositorio.ObtenerHistoriasPorId(id);
        return View(historias);
    }

    [HttpPost]
    public IActionResult Actualizar(int id, Veterinaria veterinaria)
    {
       
        _veterinariaRepositorio.EditarHistoria(id, veterinaria);
      
        return RedirectToAction("Index");
    }
}