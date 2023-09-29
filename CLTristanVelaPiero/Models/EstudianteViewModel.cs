using System;
using System.Collections.Generic;

namespace CLTristanVelaPiero.Models
{
    public class EstudianteListViewModel
    {
        public List<EstudianteViewModel> List { get; set; }

        public EstudianteListViewModel() 
        { 
            List = new List<EstudianteViewModel>();
        }
        
    }

    public class EstudianteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public int Numero { get; set; }
        public string NombreContacto { get; set; }
        public int NumeroContacto { get; set; }
    }
}
