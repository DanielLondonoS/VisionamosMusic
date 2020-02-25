using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    public class Users
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string EsAdmin { get; set; }
    }
}
