using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lab3.Model
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string FotoPath { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Observaciones { get; set; }
        public string NombreCompleto { get { return string.Format("{0} {1} {2}", Nombre, ApellidoPaterno, ApellidoMaterno); } }
        public int Edad { get { return DateTime.Today.Year - FechaNacimiento.Year; } }
        public ObservableCollection<Ventas> lstVentas { get; set; }

        public PersonaModel() { }

        public static ObservableCollection<PersonaModel> ObtenerPersonas()
        {
            //aqui se llamaria a un API x ej, q me devuelve un json para llenar la lista
            ObservableCollection<PersonaModel> lst = new ObservableCollection<PersonaModel>();
            lst.Add(new PersonaModel { Id= 1, Nombre="Sharon", FotoPath="deleteImg"});
            lst.Add(new PersonaModel { Id = 2, Nombre = "Maria" });
            lst.Add(new PersonaModel { Id = 3, Nombre = "Jorge" });
            lst.Add(new PersonaModel { Id = 4, Nombre = "Sam" });
            lst.Add(new PersonaModel { Id = 5, Nombre = "Stephanie" });

            return lst;
        }
    }
}
