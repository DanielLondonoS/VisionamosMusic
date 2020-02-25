using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Entidad que se encarga de almacenar los autores musicales
    /// </summary>
    public partial class Author
    {
        public Author()
        {
            Album = new HashSet<Album>();
            Song = new HashSet<Song>();
        }
        /// <summary>
        /// Identificador del autor
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del autor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Coleccion con canciones relacionadas al autor
        /// </summary>
        public virtual ICollection<Song> Song { get; set; }
        public virtual ICollection<Album> Album { get; set; }
    }
}
