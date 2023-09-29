using System;

namespace CLTristanVelaPiero.Database
{
    public class EstudianteEntity
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


