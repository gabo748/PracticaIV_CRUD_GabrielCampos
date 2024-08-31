using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practiva_IV_GabrielCampos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practiva_IV_GabrielCampos.Models.ViewModels;

namespace Practiva_IV_GabrielCampos.Controllers;

public class HomeController : Controller
{
    private readonly DbcrudcoreContext _DBContext;

    public HomeController(DbcrudcoreContext context)
    {
        _DBContext = context;
    }

    public IActionResult Index()
    {
        List<Empleado> lista = _DBContext.Empleados.Include(c => c.oCargo).ToList();
        return View(lista);
    }

    [HttpGet]
    public IActionResult Empleado_Detalle()
    {
        EmpleadoVM oEmpleadoVM = new EmpleadoVM()
        {
            oEmpleado = new Empleado(),
            oListaCargo = _DBContext.Cargos.Select(cargo => new SelectListItem()
            {
                Text = cargo.Descripcion,
                Value = cargo.IdCargo.ToString()
            }).ToList()

        };

        return View(oEmpleadoVM);
    }

    [HttpPost]
    public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
    {
        if (oEmpleadoVM.oEmpleado.IdEmpleado == 0)
        {
            _DBContext.Empleados.Add(oEmpleadoVM.oEmpleado);
        }

        _DBContext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}