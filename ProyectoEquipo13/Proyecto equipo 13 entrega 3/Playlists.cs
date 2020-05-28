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

        public void VerPlaylist()
        {
            Console.WriteLine("Nombre:"+this.name);
            Console.WriteLine("Elementos involucrados");
            if (this.type =="Película" || this.type=="Películas" || this.type=="Pelicula" || this.type=="Peliculas"|| this.type == "película" || this.type == "películas" || this.type == "pelicula" || this.type == "peliculas")
            {
                foreach (Movies movie in this.Playlistmovie)
                {
                    Console.WriteLine("-"+movie.Title1);
                }
            }
            else if (this.type=="Canción" || this.type=="Canciones" ||this.type=="canción" ||this.type=="canciones" ||this.type=="Cancion" || this.type == "cancion")
            {
                foreach (Songs song in this.Playlistsong)
                {
                    Console.WriteLine("-"+song.Title1);
                }
            }
        }
    }
}
