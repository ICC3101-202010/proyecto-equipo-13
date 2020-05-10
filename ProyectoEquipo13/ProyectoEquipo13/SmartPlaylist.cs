using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class SmartPlaylist : Playlists
    {
        protected string criterio;
        protected string namecriterio;
        public SmartPlaylist(string name, bool privacy, string type, string criterio, string namecriterio) : base(name, privacy, type)
        {
            this.criterio = criterio;
            this.namecriterio = namecriterio;
        }
    }
}
