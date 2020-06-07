using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proyecto_equipo_13_entrega_3
{
    public class Computer
    {

        public Playlists CreatePlaylist(string type, string name)
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                Playlists playlists = new Playlists(name, type);

                return playlists;
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                Playlists playlists = new Playlists(name, type);

                return playlists;
            }
            return null;
        }

        public SmartPlaylist CreateSmartPlaylist(string type, string criterio, string namecriterio, string name)
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                SmartPlaylist smart = new SmartPlaylist(name, type, criterio, namecriterio);
                return smart;
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                SmartPlaylist smart = new SmartPlaylist(name, type, criterio, namecriterio);
                return smart;
            }
            return null;

        }
        
    }
}
