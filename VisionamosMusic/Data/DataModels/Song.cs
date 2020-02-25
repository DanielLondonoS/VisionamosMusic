using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Entidad que se encarga de almacenar las canciones de los albunes
    /// </summary>
    public partial class Song
    {
        public Song()
        {
            Car = new HashSet<Car>();
        }
        /// <summary>
        /// Identificador de la cancion
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre de la cancion
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Autor de la cancion
        /// </summary>
        public int Author { get; set; }
        /// <summary>
        /// Album al que pertenece la cancion
        /// </summary>
        public int Album { get; set; }
        /// <summary>
        /// Relaciona la cancion con un album
        /// </summary>
        public virtual Album AlbumNavigation { get; set; }
        /// <summary>
        /// Relaciona el autor con la cancion
        /// </summary>
        public virtual Author AuthorNavigation { get; set; }
        public virtual ICollection<Car> Car { get; set; }
    }
}
