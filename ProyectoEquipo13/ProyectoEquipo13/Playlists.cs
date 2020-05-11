using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Playlists
    {
        private string type;
        private string name;
        private bool privacy;
        protected List<Songs> playlistsong = new List<Songs>();
        protected List<Movies> playlistmovie = new List<Movies>();

        public List<Songs> Playlistsong { get => playlistsong; set => playlistsong = value; }
        public List<Movies> Playlistmovie { get => playlistmovie; set => playlistmovie = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public bool Privacy { get => privacy; set => privacy = value; }

        public Playlists(string name, bool privacy, string type)
        {
            this.Name = name;
            this.Privacy = privacy;
            this.Type = type;
        }


    }
}
