using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class Playlists
    {
        private string type;
        private string name;
        protected List<Songs> playlistsong = new List<Songs>();
        protected List<Movies> playlistmovie = new List<Movies>();

        public List<Songs> Playlistsong { get => playlistsong; set => playlistsong = value; }
        public List<Movies> Playlistmovie { get => playlistmovie; set => playlistmovie = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }

        public Playlists(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
