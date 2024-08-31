using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practiva_IV_GabrielCampos.Models.ViewModels;

public class EmpleadoVM
{
    public Empleado oEmpleado { get; set; }

    public List<SelectListItem> oListaCargo { get; set; }
}