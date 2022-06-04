using HUAMAN_T3.WEB.Controllers;
using HUAMAN_T3.WEB.Models;
using HUAMAN_T3.WEB.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HUAMAN_T3.TEST.Controllers;

public class VeterinariaControllerTest
{
     [Test]
    public void ListarControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        mockHistoriaRepositorio.Setup(o => o.ObtenerHistorias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = (ViewResult) controller.Index();
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);

    }
    
    [Test]
    public void CrearControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        mockHistoriaRepositorio.Setup(o => o.ObtenerHistorias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = (ViewResult) controller.Create(1);
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);

    }
    
    
    [Test]
    public void GuardarPostControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        mockHistoriaRepositorio.Setup(o => o.ObtenerHistorias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = controller.Guardar(new Veterinaria(){Id = 1, Nombre = "Rambo", Raza = "Aleman" });
        
        Assert.IsNotNull(view);

    }
    
    
    
     
    [Test]
    public void EditarGetControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        mockHistoriaRepositorio.Setup(o => o.ObtenerHistoriasPorId(1)).Returns(new Veterinaria()
            { Id = 1, Nombre = "Rambo", Raza = "Aleman" });
        
        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = (ViewResult) controller.Edit(1);
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);

    }
    
    
    [Test]
    public void EditarPostControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        
        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = controller.Actualizar(1, new Veterinaria());
        
        Assert.IsNotNull(view);
        

    }
    
     
    [Test]
    public void EliminarControllerTestCaso01()
    {
        var mockHistoriaRepositorio = new Mock<IVeterinariaRepositorio>();
        
        var controller = new VeterinariaController(mockHistoriaRepositorio.Object, null);
        var view = controller.Delete(1);
        
        Assert.IsNotNull(view);
     

    }
}