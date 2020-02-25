using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    public class Car
    {
        public int Id { get; set; }
        public int? IdSong { get; set; }
        public DateTime? Date { get; set; }

        public virtual Song IdSongNavigation { get; set; }
    }
}
