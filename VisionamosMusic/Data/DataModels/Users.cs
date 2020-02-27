using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    public class Users
    {
        public Users()
        {
            Car = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string EsAdmin { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
