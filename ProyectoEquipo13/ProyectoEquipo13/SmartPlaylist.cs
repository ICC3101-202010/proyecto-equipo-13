using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class SmartPlaylist : Playlists
    {
        private string criterio;
        private string namecriterio;
        public string NameCriterio { get => namecriterio; set => namecriterio = value; }
        public SmartPlaylist(string name, bool privacy, string type, string namecriterio) : base(name, privacy, type)
        {
            this.namecriterio = namecriterio;
        }
    }
}
