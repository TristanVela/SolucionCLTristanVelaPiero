using CLTristanVelaPiero.Database;
using CLTristanVelaPiero.Database.EstudianteContext;
using CLTristanVelaPiero.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CLTristanVelaPiero.Controllers
{
    public class EstudianteController : Controller
    {
        public readonly EstudianteContext _estudianteContext;

        public EstudianteController(EstudianteContext estudianteContext)
        {
            this._estudianteContext = estudianteContext;
        }

        public IActionResult List()
        {
            var listResult = _estudianteContext.Estudiantes.ToList();

            EstudianteListViewModel model = new EstudianteListViewModel();
            model.List = (from c in listResult
                          select new EstudianteViewModel()
                          {
                              Id = c.Id,
                              Nombre = c.Nombre,
                              Apellido = c.Apellido,
                              DNI = c.DNI,
                              FechaNacimiento = c.FechaNacimiento,
                              Correo = c.Correo,
                              Numero = c.Numero,
                              NombreContacto = c.NombreContacto,
                              NumeroContacto = c.NumeroContacto,
                          }).ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            EstudianteViewModel model = new EstudianteViewModel();
            return View(model);
        }

        public IActionResult AddSavedAction(EstudianteViewModel model)
        {
            EstudianteEntity entity = new EstudianteEntity();
            entity.Nombre = model.Nombre;
            entity.Apellido = model.Apellido;
            entity.DNI = model.DNI;
            entity.FechaNacimiento = model.FechaNacimiento;
            entity.Correo = model.Correo;
            entity.Numero = model.Numero;
            entity.NombreContacto = model.NombreContacto;
            entity.NumeroContacto = model.NumeroContacto;
            _estudianteContext.Estudiantes.Add(entity);
            _estudianteContext.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            var findEstudiante = _estudianteContext.Estudiantes.Where(c => c.Id == id).SingleOrDefault();
            var model = new EstudianteViewModel();
            model.Id = findEstudiante.Id;
            model.Nombre = findEstudiante.Nombre;
            model.Apellido = findEstudiante.Apellido;
            model.DNI = findEstudiante.DNI;
            model.FechaNacimiento = findEstudiante.FechaNacimiento;
            model.Correo = findEstudiante.Correo;
            model.Numero = findEstudiante.Numero;
            model.NombreContacto = findEstudiante.NombreContacto;
            model.NumeroContacto = findEstudiante.NumeroContacto;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditSaved(EstudianteViewModel model)
        {
            var findEstudiante = _estudianteContext.Estudiantes.SingleOrDefault(c => c.Id == model.Id);
            if (findEstudiante != null)
            {
                findEstudiante.Nombre = model.Nombre;
                findEstudiante.Apellido = model.Apellido;
                findEstudiante.DNI = model.DNI;
                findEstudiante.FechaNacimiento = model.FechaNacimiento;
                findEstudiante.Correo = model.Correo;
                findEstudiante.Numero = model.Numero;
                findEstudiante.NombreContacto = model.NombreContacto;
                findEstudiante.NumeroContacto = model.NumeroContacto;
                _estudianteContext.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var findEstudiante = _estudianteContext.Estudiantes.SingleOrDefault(c => c.Id == id);
            _estudianteContext.Estudiantes.Remove(findEstudiante);
            _estudianteContext.SaveChanges();
            return RedirectToAction("List");   
        }

    }
}
