using HUAMAN_T3.TEST.Helpers;
using HUAMAN_T3.WEB.DB;
using HUAMAN_T3.WEB.Models;
using HUAMAN_T3.WEB.Repositorios;
using Moq;

namespace HUAMAN_T3.TEST.Repositorios;

public class VeterinariaRepositorioTest
{
    private IQueryable<Veterinaria> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<Veterinaria>
        {
            new Veterinaria() { Id = 1, Nombre = "Rambo", Especie = "Carniboro", NombreD = "Jose"},
            new Veterinaria() { Id = 2, Nombre = "Pamela", Especie = "Ave", NombreD = "Pedro" },
            new Veterinaria() { Id = 3, Nombre = "Luck", Especie = "Especie", NombreD = "Laura" }

        }.AsQueryable();

        var mockDbsetHistoria = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetHistoria.Object);
    }

    [Test]

    public void ObtenerHistoriasRepositorioCaso01()
    {
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        var result = repositorio.ObtenerHistorias();
        
        Assert.IsNotNull(result);
    }
    
    
    [Test]
    public void AgregarHistoriasRepositorioCaso01()
    {
        var mockDbsetHistoria = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetHistoria.Object);
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        repositorio.GuardarHistorias(new Veterinaria(){Id = 1, Nombre = "Rambo1", Especie = "Especie3", Raza = "Aleman"});
        
        mockDbsetHistoria.Verify(o => o.Add(It.IsAny<Veterinaria>()), Times.Once);
    }
    
    
    
    [Test]
    public void EditarHistoriasPorIdRepositorioCaso01()
    {
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        var result = repositorio.ObtenerHistoriasPorId(1);
        
        Assert.AreEqual(1, result.Id);
    }

    [Test]
    public void EditarHistoriasPorIdRepositorioCaso02()
    {
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        var result = repositorio.ObtenerHistoriasPorId(2);
        
        Assert.AreEqual(2, result.Id);
    }

    [Test]
    public void EditarHistoriasPorIdRepositorioCaso03()
    {
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        var result = repositorio.ObtenerHistoriasPorId(1);
        
        Assert.AreEqual(1, result.Id);
    }
    
    [Test]
    public void EditarErrorHistoriasPorIdRepositorioCaso01()
    {
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        var result = repositorio.ObtenerHistoriasPorId(1);
        
        Assert.AreEqual(10, result.Id);
    }
    
    
    [Test]
    public void EliminarNotasRepositorioCaso01()
    {
        var mockDbsetHistoria = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetHistoria.Object);
        
        var repositorio = new VeterinariaRepositorio(mockDB.Object);
        repositorio.EliminarHistorias(1);
        
        var dataMockEliminar = data.First(o => o.Id == 1);
        
        mockDbsetHistoria.Verify(o => o.Remove(dataMockEliminar), Times.Once());
    }


}