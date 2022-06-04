using HUAMAN_T3.WEB.DB;
using HUAMAN_T3.WEB.Models;

namespace HUAMAN_T3.WEB.Repositorios;

public interface IVeterinariaRepositorio
{
    List<Veterinaria> ObtenerHistorias();
    void GuardarHistorias(Veterinaria veterinaria);
    Veterinaria DetalleHistorias(int id);
    Veterinaria ObtenerHistoriasPorId(int id);
    void EditarHistoria(int id, Veterinaria veterinaria);
    void EliminarHistorias(int id);

}

public class VeterinariaRepositorio: IVeterinariaRepositorio
{
    private DbEntities _dbEntities;
    
    public VeterinariaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    
    public List<Veterinaria> ObtenerHistorias()
    {
        return _dbEntities.Veterinarias.ToList();
    }
    
    public void GuardarHistorias(Veterinaria veterinaria)
    {
        _dbEntities.Veterinarias.Add(veterinaria);
        _dbEntities.SaveChanges();
    }
    
    public Veterinaria DetalleHistorias(int id)
    {
        var notas = _dbEntities.Veterinarias.First(o => o.Id == id);
        return notas;
    }
    
    public Veterinaria ObtenerHistoriasPorId(int id)
    {
        return _dbEntities.Veterinarias.First(o => o.Id == id); // lambdas / LINQ
       
    }
    
    public void EditarHistoria(int id, Veterinaria veterinaria) {
        
        var historia = _dbEntities.Veterinarias.First(o => o.Id == id);
        historia.Nombre = veterinaria.Nombre;
        historia.NombreD = veterinaria.NombreD;
        _dbEntities.SaveChanges();
       
    }
    
    public void EliminarHistorias(int id)
    {
        var historia = _dbEntities.Veterinarias.First(o => o.Id == id);
        _dbEntities.Veterinarias.Remove(historia);
        _dbEntities.SaveChanges();
        
    }
}