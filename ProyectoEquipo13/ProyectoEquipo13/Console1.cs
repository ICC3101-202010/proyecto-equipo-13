using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;


namespace ProyectoEquipo13
{
    public static class Console1
    {
        public static void InitialMessage()
        {
            Console.WriteLine("¡Bienvenido a Netfy! \n¡La nueva plataforma donde podrás tener tu música y películas en un solo lugar!");
        }

        public static void SecondMessage(Computer computer)
        {
            Console.WriteLine("\n¡Bienvenido al Menú!... Seleccione la opción que desee:\n");
        }

        public static void SeeMovies(Computer computer, User userlogin)
        {
            Dictionary<int, Movies> dic = new Dictionary<int, Movies>();
            Console.WriteLine("\nSeleccione la película que desee:\n");
            int counter = 1;
            foreach (Movies movie in Files.AllMovies)
            {
                Console.WriteLine("("+counter+")"+movie.Title1);
                dic.Add(counter, movie);
                counter += 1;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            Movies movie2 = dic[option];
            movie2.MovieInformation();
            Console.WriteLine("\n¿Que desea hacer con la película?");
            Console.WriteLine("(a) Reproducir\n(b) Valorar Película\n(c) Agregar a una Playlist\n(d) Seleccionar otra película\n(e) Nada (Solo quería ver la información de la Película)");
            string option2 = Console.ReadLine();
            if (option2 == "a")
            {
                movie2.Play();
            }
            else if (option2 == "b")
            {
                Console.WriteLine("Seleccione la valoración que desea para la película (double)");
                double val = Convert.ToDouble(Console.ReadLine());
                movie2.Rating1.Add(val);
                computer.Rate("Pelicula", movie2.Title1, movie2.Rating1);
                Thread.Sleep(1000);               
            }
            else if (option2 == "c")
            {
                if (userlogin.Type == "Premium")
                {
                    if(userlogin.MyPlaylist1.Count() > 0)
                    {
                        Dictionary<int, Playlists> dic2 = new Dictionary<int, Playlists>();
                        Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                        int counter2 = 1;
                        foreach (Playlists playlist in userlogin.MyPlaylist1)
                        {
                            Console.WriteLine("(" + counter2 + ")" + playlist.Name);
                            dic2.Add(counter2, playlist);
                            counter += 1;
                        }
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice != 0)
                        {
                            Playlists playlist2 = dic2[choice];
                            playlist2.Playlistmovie.Add(movie2);
                            userlogin.MyPlaylist1.RemoveAt(choice - 1);
                            userlogin.MyPlaylist1.Insert(choice - 1, playlist2);
                        }
                    }
                }
                else if (userlogin.Type == "Free")
                {
                    Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                    Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                }
            }
            else if (option2 == "d")
            {
                SeeMovies(computer, userlogin);
            }
            else if (option2 == "e")
            {
                Console.WriteLine();
            }
            else { Console.WriteLine("La opción que seleccionó no es válida"); }
        }

        public static void SeeSongs(Computer computer, User userlogin)
        {
            Dictionary<int, Songs> dic = new Dictionary<int, Songs>();
            Console.WriteLine("\nSeleccione la canción que desee:\n");
            int count = 1;
            foreach (Songs songs in Files.AllSongs)
            {
                Console.WriteLine("("+count + ")" + songs.Title1);
                dic.Add(count, songs);
                count += 1;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            Songs songs2 = dic[option];
            songs2.SongsInformation();
            Console.WriteLine("\n¿Que desea hacer con la canción?");
            Console.WriteLine("(a) Reproducir\n(b) Valorar Canción\n(c) Agregar a una Playlist\n(d) Seleccionar otra canción\n(e) Nada (Solo quería ver la información de la Canción)");
            string option2 = Console.ReadLine();
            if (option2 == "a")
            {
                songs2.Play();
            }
            else if (option2 == "b")
            {
                Console.WriteLine("Seleccione la valoración que desea para la canción (double)");
                double val = Convert.ToDouble(Console.ReadLine());
                songs2.Rating1.Add(val);
                computer.Rate("Cancion", songs2.Title1, songs2.Rating1);
                Thread.Sleep(1000);
            }
            else if (option2 == "c")
            {
                if (userlogin.Type == "Premium")
                {
                   if(userlogin.MyPlaylist1.Count() > 0)
                    {
                        Dictionary<int, Playlists> dic2 = new Dictionary<int, Playlists>();
                        Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                        int counter2 = 1;
                        foreach (Playlists playlist in userlogin.MyPlaylist1)
                        {
                            Console.WriteLine("(" + counter2 + ")" + playlist.Name);
                            dic2.Add(counter2, playlist);
                            counter2 += 1;
                        }
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice != 0)
                        {
                            Playlists playlist2 = dic2[choice];
                            playlist2.Playlistsong.Add(songs2);
                            userlogin.MyPlaylist1.RemoveAt(choice - 1);
                            userlogin.MyPlaylist1.Insert(choice - 1, playlist2);
                        }
                    }
                }
                else if (userlogin.Type == "Free")
                {
                    Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                    Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                }
            }
            else if (option2 == "d")
            {
                SeeSongs(computer, userlogin);
            }
            else if (option2 == "e")
            {
                Console.WriteLine();
            }
            else { Console.WriteLine("La opción que seleccionó no es válida"); }
        }

        public static void CreatePlaylist(Computer computer, User user)
        {
            if (user.Type == "Premium")
            {
                Console.WriteLine("\nDe que tipo desea que sea su Playlist:");
                Console.WriteLine("(a) Normal \n(b) Inteligente (agrega canciones automáticamente según un criterio)");
                string res = Console.ReadLine();
                if (res == "a")
                {
                    Console.WriteLine("¿De que tipo sera la Playlist?");
                    Console.WriteLine("(a)Película\n(b)Canción");
                    string type = Console.ReadLine();
                    if (type == "a") { type = "Película"; }
                    else if (type == "b") { type = "Canción"; }
                    if (type == "Película" || type=="Canción")
                    {
                        Console.WriteLine("Eliga un nombre");
                        string name = Console.ReadLine();
                        Console.WriteLine("¿Desea hacer la Playlist (a) Pública o (b) Privada?");
                        string privacidad = Console.ReadLine();

                        if (privacidad == "a")
                        {
                            user.MyPlaylist1.Add(computer.CreatePlaylist(type, name, true));
                            Console.WriteLine("Playlist creada con éxito");
                            if (type == "Película") { Files.AllPlaylistsMovies.Add(computer.CreatePlaylist(type, name, true)); }
                            else if (type == "Canción") { Files.AllPlaylistsSongs.Add(computer.CreatePlaylist(type, name, true)); }
                            Thread.Sleep(1200);
                        }
                        else if (privacidad == "b")
                        {
                            user.MyPlaylist1.Add(computer.CreatePlaylist(type, name, false));
                            Console.WriteLine("Playlist creada con éxito");
                            Thread.Sleep(1200);
                        }
                        else
                        {
                            Console.WriteLine("Comando ingresado no válido");
                        }
                    }
                }
                else if (res == "b")
                {
                    Console.WriteLine("¿De que tipo sera la Playlist?");
                    Console.WriteLine("(a)Película\n(b)Canción");
                    string type = Console.ReadLine();
                    if (type == "a") { type = "Película"; }
                    else if (type == "b") { type = "Canción"; }
                    if (type == "Película" || type == "Canción")
                    {
                        Console.WriteLine("Eliga un nombre");
                        string name = Console.ReadLine();
                        Console.WriteLine("¿Desea hacer la Playlist (a) Pública o (b) Privada?");
                        string privacidad = Console.ReadLine();
                        if (type == "Canción")
                        {
                            Console.WriteLine("Elija el criterio de la SmartPlaylist(Género,Artista)");
                            string criterio = Console.ReadLine();
                            Console.WriteLine("Elija el nombre del criterio de la SmartPlaylist(ej: Género(rock,Pop),Artista(Michael Jakson,Elvis Presley))");
                            string namecriterio = Console.ReadLine();
                            if (privacidad == "a")
                            {
                                var a = computer.CreateSmartPlaylist(type, criterio, namecriterio, name, true);
                                Thread.Sleep(1200);
                                Console.WriteLine("\nPlaylist creada con éxito");
                                if (criterio == "Genero" || criterio == "Género" || criterio == "genero" || criterio == "género")
                                {
                                    foreach (Songs songs in Files.AllSongs)
                                    {
                                        foreach (string genero in songs.Genre1)
                                        {
                                            if (genero == namecriterio)
                                            {
                                                a.Playlistsong.Add(songs);
                                            }
                                        }
                                    }
                                }
                                else if (criterio == "Artista" || criterio == "artista")
                                {
                                    foreach (Songs songs in Files.AllSongs)
                                    {
                                        if (songs.Artist1.Name == namecriterio)
                                        {
                                            a.Playlistsong.Add(songs);
                                        }
                                    }
                                }
                                user.MyPlaylist1.Add(a);
                                Files.AllPlaylistsSongs.Add(a);
                                Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                                Thread.Sleep(2000);
                            }
                            else if (privacidad == "b")
                            {
                                var a = computer.CreateSmartPlaylist(type, criterio, namecriterio, name, true);
                                Console.WriteLine("\nPlaylist creada con éxito");
                                if (criterio == "Genero" || criterio == "Género" || criterio == "genero" || criterio == "género")
                                {
                                    foreach (Songs songs in Files.AllSongs)
                                    {
                                        foreach (string genero in songs.Genre1)
                                        {
                                            if (genero == namecriterio)
                                            {
                                                a.Playlistsong.Add(songs);
                                            }
                                        }
                                    }
                                }
                                else if (criterio == "Artista" || criterio == "artista")
                                {
                                    foreach (Songs songs in Files.AllSongs)
                                    {
                                        if (songs.Artist1.Name == namecriterio)
                                        {
                                            a.Playlistsong.Add(songs);
                                        }
                                    }
                                }
                                user.MyPlaylist1.Add(a);                  
                                Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                                Thread.Sleep(2000);
                            }
                        }
                        else if (type == "Película")
                        {
                            Console.WriteLine("Elija el criterio de la SmartPlaylist(Director,Categoria,Actor,Estudio)");
                            string criterio = Console.ReadLine();
                            Console.WriteLine("Elija el nombre del criterio de la SmartPlaylist(ej: Estudio(Pixar,Universal Studio), Director(Guillermo Del Toro,Steven Spielberg)");
                            string namecriterio = Console.ReadLine();
                            if (privacidad == "a")
                            {
                                var a = computer.CreateSmartPlaylist(type, criterio, namecriterio, name, true);
                                Console.WriteLine("\nPlaylist creada con éxito");
                                Thread.Sleep(1200);
                                if (criterio == "Director" || criterio == "director")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        if (movies.Director1.Name == namecriterio)
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                                else if (criterio == "Estudio" || criterio == "estudio")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        if (movies.Studio1 == namecriterio)
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                                else if (criterio == "Categoria" || criterio == "categoria" || criterio == "Categoría" || criterio == "categoría")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        foreach (string cate in movies.Categories1)
                                        {
                                            if (cate == namecriterio)
                                            {
                                                a.Playlistmovie.Add(movies);
                                            }
                                        }
                                    }
                                }
                                else if (criterio == "Actor" || criterio == "actor")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        foreach (Person actor in movies.Actors1)
                                        {
                                            if (actor.Name == namecriterio)
                                            {
                                                a.Playlistmovie.Add(movies);
                                            }
                                        }
                                    }
                                }
                                user.MyPlaylist1.Add(a);
                                Files.AllPlaylistsMovies.Add(a);
                                Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                            }
                            else if (privacidad == "b")
                            {
                                var a = computer.CreateSmartPlaylist(type, criterio, namecriterio, name, true);
                                Console.WriteLine("\nPlaylist creada con éxito");
                                if (criterio == "Director" || criterio == "director")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        if (movies.Director1.Name == namecriterio)
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                                else if (criterio == "Estudio" || criterio == "estudio")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        if (movies.Studio1 == namecriterio)
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                                else if (criterio == "Categoria" || criterio == "categoria" || criterio == "Categoría" || criterio == "categoría")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        foreach (string cate in movies.Categories1)
                                        {
                                            if (cate == namecriterio)
                                            {
                                                a.Playlistmovie.Add(movies);
                                            }
                                        }
                                    }
                                }
                                else if (criterio == "Actor" || criterio == "actor")
                                {
                                    foreach (Movies movies in Files.AllMovies)
                                    {
                                        foreach (Person actor in movies.Actors1)
                                        {
                                            if (actor.Name == namecriterio)
                                            {
                                                a.Playlistmovie.Add(movies);
                                            }
                                        }
                                    }
                                }
                                user.MyPlaylist1.Add(a);
                                Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Comando ingresado no válido");
                    }
                }
                else
                {
                    Console.WriteLine("Comando ingresado no válido");
                }
            }
            else if (user.Type == "Free")
            {
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
            }
        }

        public static void ModifiedPlaylist(Computer computer, User user)
        {
            if (user.Type == "Premium")
            {
                if (user.MyPlaylist1.Count() > 0)
                {
                    //Cambiar nombre, sacar elementos, agregar elementos, etc etc
                    Dictionary<int, Playlists> dic = new Dictionary<int, Playlists>();
                    Console.WriteLine("\nSeleccione la Playlist que desee:\n");
                    int counter = 1;
                    foreach (Playlists playlists in user.MyPlaylist1)
                    {
                        Console.WriteLine("(" + counter + ")" + playlists.Name);
                        dic.Add(counter, playlists);
                        counter += 1;
                    }
                    int option = Convert.ToInt32(Console.ReadLine());
                    Playlists play = dic[option];
                    Console.WriteLine("\n¿Que desea hacer con la Playlist?");
                    Console.WriteLine("(a) Cambiar nombre\n(b) Sacar elemento\n(c) Agregar elementos\n");
                    string option2 = Console.ReadLine();
                    if (option2 == "a")
                    {
                        Console.WriteLine("Elija el nuevo nombre: ");
                        string name = Console.ReadLine();
                        play.Name = name;
                        Console.WriteLine("\nNombre cambiado con éxito");
                    }
                    else if (option2 == "b")
                    {
                        if (play.Playlistmovie.Count() > 0)
                        {
                            if (play.Type == "Pelicula" || play.Type == "Película" || play.Type == "pelicula" || play.Type == "película")
                            {
                                Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                                int counter2 = 1;
                                Console.WriteLine("La playlist contiene las siguientes películas: \n");
                                foreach (Movies movies in play.Playlistmovie)
                                {
                                    Console.WriteLine("(" + counter2 + ")" + movies.Title1);
                                    dic2.Add(counter2, movies);
                                    counter2 += 1;

                                }
                                Console.WriteLine("Seleccione cual desea eliminar");
                                int choise = Convert.ToInt32(Console.ReadLine());
                                play.Playlistmovie.RemoveAt(choise - 1);

                            }
                            else
                            {
                                Console.WriteLine("Lista vacía");
                                Thread.Sleep(2000);
                            }

                        }
                        if (play.Playlistsong.Count() > 0)
                        {
                            if (play.Type == "Cancion" || play.Type == "Canción" || play.Type == "canción" || play.Type == "cancion")
                            {
                                Dictionary<int, Songs> dic2 = new Dictionary<int, Songs>();
                                int counter2 = 1;
                                Console.WriteLine("La playlist contiene las siguientes canciones: \n");
                                foreach (Songs songs in play.Playlistsong)
                                {
                                    Console.WriteLine("(" + counter2 + ")" + songs.Title1);
                                    dic2.Add(counter2, songs);
                                    counter2 += 1;

                                }
                                Console.WriteLine("Seleccione cual desea eliminar");
                                int choise = Convert.ToInt32(Console.ReadLine());
                                play.Playlistsong.RemoveAt(choise - 1);
                            }
                            else
                            {
                                Console.WriteLine("Lista vacía");
                                Thread.Sleep(2000);
                            }
                        }

                    }
                    else if (option2 == "c")
                    {
                        if (play.Type == "Pelicula" || play.Type == "Película" || play.Type == "pelicula" || play.Type == "película")
                        {
                            Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                            int counter2 = 1;
                            Console.WriteLine("¿Qué película desea agregar? \n");
                            foreach (Movies movies in Files.AllMovies)
                            {
                                Console.WriteLine("(" + counter2 + ")" + movies.Title1);
                                dic2.Add(counter2, movies);
                                counter2 += 1;

                            }
                            int choise = Convert.ToInt32(Console.ReadLine());
                            Movies movies1 = dic2[choise];
                            play.Playlistmovie.Add(movies1);
                        }
                        else if (play.Type == "Cancion" || play.Type == "Canción" || play.Type == "canción" || play.Type == "cancion")
                        {
                            Dictionary<int, Songs> dic2 = new Dictionary<int, Songs>();
                            int counter2 = 1;
                            Console.WriteLine("¿Qué canción desea agregar? \n");
                            foreach (Songs songs in Files.AllSongs)
                            {
                                Console.WriteLine("(" + counter2 + ")" + songs.Title1);
                                dic2.Add(counter2, songs);
                                counter2 += 1;

                            }
                            int choice = Convert.ToInt32(Console.ReadLine());
                            Songs songs1 = dic2[choice];
                            play.Playlistsong.Add(songs1);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Comando ingresado no válido");
                    }
                }
                else
                {
                    Console.WriteLine("No existe Playlist para modificar");
                    Thread.Sleep(2000);
                }
            }
            else if (user.Type == "Free")
            {
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
            }
        }

        public static void SeePlaylist(Computer computer, User user)
        {
            if (user.Type == "Premium")
            {
                Dictionary<int, Playlists> dic = new Dictionary<int, Playlists>();
                Console.WriteLine("\nSeleccione la Playlist que desee ver:\n");
                int counter = 1;
                foreach (Playlists playlists in user.MyPlaylist1)
                {
                    Console.WriteLine("(" + counter + ")" + playlists.Name);
                    dic.Add(counter, playlists);
                    counter += 1;
                }
                if (user.MyPlaylist1.Count() > 0)
                {
                    Console.WriteLine();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    user.MyPlaylist1[choice - 1].VerPlaylist();
                    Console.WriteLine("\nQue desea realizar:");
                    Console.WriteLine("(a) Poner una Canción/Película en específico\n(b) Reproducir Canción/Película Aleatoria\n(c) Reproducir Todo (Tendrán que sonar todas las canciones para volver al menú inicial, puede ir saltando canciones apretando Enter)");
                    string option = Console.ReadLine();
                    if (option == "a")
                    {
                        if (user.MyPlaylist1[choice-1].Playlistmovie.Count() > 0)
                        {
                            if (user.MyPlaylist1[choice - 1].Type == "Película" || user.MyPlaylist1[choice - 1].Type == "Películas" || user.MyPlaylist1[choice - 1].Type == "Pelicula" || user.MyPlaylist1[choice - 1].Type == "Peliculas" || user.MyPlaylist1[choice - 1].Type == "película" || user.MyPlaylist1[choice - 1].Type == "películas" || user.MyPlaylist1[choice - 1].Type == "pelicula" || user.MyPlaylist1[choice - 1].Type == "peliculas")
                            {
                                Dictionary<int, Movies> dic3 = new Dictionary<int, Movies>();
                                Console.WriteLine("\nSeleccione la Película que desee ver:\n");
                                int counter2 = 1;
                                for (int i = 0; i < user.MyPlaylist1[choice - 1].Playlistmovie.Count; i++)
                                {
                                    Console.WriteLine("(" + counter2 + ")" + user.MyPlaylist1[choice - 1].Playlistmovie[i].Title1);
                                    dic3.Add(counter2, user.MyPlaylist1[choice - 1].Playlistmovie[i]);
                                    counter2 += 1;
                                }
                                int movieselection = Convert.ToInt32(Console.ReadLine());
                                user.MyPlaylist1[choice - 1].Playlistmovie[movieselection - 1].Play();
                            }
                        }
                        if (user.MyPlaylist1[choice-1].Playlistsong.Count() > 0)
                        {
                            if (user.MyPlaylist1[choice - 1].Type == "Canción" || user.MyPlaylist1[choice - 1].Type == "Canciones" || user.MyPlaylist1[choice - 1].Type == "canción" || user.MyPlaylist1[choice - 1].Type == "canciones" || user.MyPlaylist1[choice - 1].Type == "Cancion" || user.MyPlaylist1[choice - 1].Type == "cancion")
                            {
                                Dictionary<int, Songs> dic4 = new Dictionary<int, Songs>();
                                Console.WriteLine("\nSeleccione la Canción que desee ver:\n");
                                int counter2 = 1;
                                for (int i = 0; i < user.MyPlaylist1[choice - 1].Playlistsong.Count; i++)
                                {
                                    Console.WriteLine("(" + counter2 + ")" + user.MyPlaylist1[choice - 1].Playlistsong[i].Title1);
                                    dic4.Add(counter2, user.MyPlaylist1[choice - 1].Playlistsong[i]);
                                    counter2 += 1;
                                }
                                int songselection = Convert.ToInt32(Console.ReadLine());
                                //Falta método reproducir
                                user.MyPlaylist1[choice - 1].Playlistsong[songselection - 1].Play();
                            }
                        }

                    }
                    else if (option == "b")
                    {
                        if (user.MyPlaylist1[choice-1].Playlistmovie.Count() > 0)
                        {
                            if (user.MyPlaylist1[choice - 1].Type == "Película" || user.MyPlaylist1[choice - 1].Type == "Películas" || user.MyPlaylist1[choice - 1].Type == "Pelicula" || user.MyPlaylist1[choice - 1].Type == "Peliculas" || user.MyPlaylist1[choice - 1].Type == "película" || user.MyPlaylist1[choice - 1].Type == "películas" || user.MyPlaylist1[choice - 1].Type == "pelicula" || user.MyPlaylist1[choice - 1].Type == "peliculas")
                            {
                                Random rdn = new Random();
                                int num = rdn.Next(user.MyPlaylist1[choice - 1].Playlistmovie.Count);
                                //Falta método reproducir
                                user.MyPlaylist1[choice - 1].Playlistmovie[num].Play();
                            }
                        }
                        if (user.MyPlaylist1[choice-1].Playlistsong.Count() > 0)
                        {
                            if (user.MyPlaylist1[choice - 1].Type == "Canción" || user.MyPlaylist1[choice - 1].Type == "Canciones" || user.MyPlaylist1[choice - 1].Type == "canción" || user.MyPlaylist1[choice - 1].Type == "canciones" || user.MyPlaylist1[choice - 1].Type == "Cancion" || user.MyPlaylist1[choice - 1].Type == "cancion")
                            {
                                Random rdn = new Random();
                                int num = rdn.Next(user.MyPlaylist1[choice - 1].Playlistsong.Count);
                                //Falta método reproducir
                                user.MyPlaylist1[choice - 1].Playlistsong[num].Play();
                            }
                        }

                    }
                    else if (option == "c")
                    {
                        if (user.MyPlaylist1[choice - 1].Type == "Canciones" || user.MyPlaylist1[choice - 1].Type == "Cancion" || user.MyPlaylist1[choice - 1].Type == "Canción" || user.MyPlaylist1[choice - 1].Type == "canciones" || user.MyPlaylist1[choice - 1].Type == "cancion" || user.MyPlaylist1[choice - 1].Type == "canción")
                        {
                            computer.AutomaticRep(user.MyPlaylist1[choice - 1].Playlistsong);
                        }
                        else if (user.MyPlaylist1[choice - 1].Type == "Película" || user.MyPlaylist1[choice - 1].Type == "película" || user.MyPlaylist1[choice - 1].Type == "Películas" || user.MyPlaylist1[choice - 1].Type == "películas" || user.MyPlaylist1[choice - 1].Type == "Pelicula" || user.MyPlaylist1[choice - 1].Type == "pelicula" || user.MyPlaylist1[choice - 1].Type == "Peliculas" || user.MyPlaylist1[choice - 1].Type == "peliculas")
                        {
                            Console.WriteLine("\nEsta opción no es válida para Películas\n");
                        }
                        else
                        {
                            Console.WriteLine("\nOpción no válida\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La opción seleccionada no es válida");
                    }
                }
                else
                {
                    Console.WriteLine("Aún no posee Playlists");
                    Thread.Sleep(1000);
                }
            }

            else if (user.Type == "Free")
            {
                Console.WriteLine();
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
            }
        }

        public static void SeeProgramPlaylists(Computer computer, User user)
        {
            if (user.Type == "Premium")
            {
                Dictionary<int, Playlists> dic = new Dictionary<int, Playlists>();
                Console.WriteLine("\nSeleccione la Playlist que desee ver:\n");
                int counter = 1;
                Console.WriteLine("Playlists de Películas: ");
                foreach (Playlists playlists in Files.AllPlaylistsMovies)
                {
                    Console.WriteLine("(" + counter + ")" + playlists.Name);
                    dic.Add(counter, playlists);
                    counter += 1;
                }
                Console.WriteLine("\nPlaylists de Canciones: ");
                int counter2 = counter;
                foreach (Playlists playlists in Files.AllPlaylistsSongs)
                {
                    Console.WriteLine("(" + counter2 + ")" + playlists.Name);
                    dic.Add(counter2, playlists);
                    counter2 += 1;
                }
                int opt = Convert.ToInt32(Console.ReadLine());
                if (dic[opt].Type=="Películas" || dic[opt].Type == "Peliculas" || dic[opt].Type == "películas" || dic[opt].Type == "peliculas" || dic[opt].Type == "Película" || dic[opt].Type == "Pelicula" || dic[opt].Type == "película" || dic[opt].Type == "pelicula")
                {
                    int pos = opt - 1;
                    Console.WriteLine("\n¿Que desea hacer?");
                    Console.WriteLine("(a) Agregarla a Mis Playlists \n(b) Ver/Seleccione Películas de la Playlist");
                    string des = Console.ReadLine();
                    if (des == "a")
                    {
                        user.MyPlaylist1.Add(Files.AllPlaylistsMovies[pos]);
                        Console.WriteLine("\nSu Playlist se ha agregado correctamente");
                    }
                    else if (des == "b")
                    {
                        Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                        Console.WriteLine("\nSeleccione la película que desee:\n");
                        int counter3 = 1;
                        foreach (Movies movie in Files.AllPlaylistsMovies[pos].Playlistmovie)
                        {
                            Console.WriteLine("(" + counter3 + ")" + movie.Title1);
                            dic2.Add(counter3, movie);
                            counter3 += 1;
                        }
                        int option = Convert.ToInt32(Console.ReadLine());
                        Movies movie2 = dic2[option];
                        movie2.MovieInformation();
                        Console.WriteLine("\n¿Que desea hacer con la película?");
                        Console.WriteLine("(a) Reproducir\n(b) Valorar Película\n(c) Agregar a una Playlist\n(d) Nada (Solo quería ver la información de la Película)");
                        string option2 = Console.ReadLine();
                        if (option2 == "a")
                        {
                            movie2.Play();
                        }
                        else if (option2 == "b")
                        {
                            Console.WriteLine("Seleccione la valoración que desea para la película (double)");
                            double val = Convert.ToDouble(Console.ReadLine());
                            movie2.Rating1.Add(val);
                            computer.Rate("Pelicula", movie2.Title1, movie2.Rating1);
                            Thread.Sleep(1000);
                        }
                        else if (option2 == "c")
                        {
                            if (user.Type == "Premium")
                            {
                                if (user.MyPlaylist1.Count() > 0)
                                {
                                    Dictionary<int, Playlists> dic3 = new Dictionary<int, Playlists>();
                                    Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                                    int counter4 = 1;
                                    foreach (Playlists playlist in user.MyPlaylist1)
                                    {
                                        Console.WriteLine("(" + counter4 + ")" + playlist.Name);
                                        dic3.Add(counter4, playlist);
                                        counter4 += 1;
                                    }
                                    int choice = Convert.ToInt32(Console.ReadLine());
                                    if (choice != 0)
                                    {
                                        Playlists playlist2 = dic3[choice];
                                        playlist2.Playlistmovie.Add(movie2);
                                        user.MyPlaylist1.RemoveAt(choice - 1);
                                        user.MyPlaylist1.Insert(choice - 1, playlist2);
                                    }
                                }
                            }
                            else if (user.Type == "Free")
                            {
                                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                            }
                        }
                        else if (option2 == "d")
                        {
                            Console.WriteLine();
                        }
                        else { Console.WriteLine("La opción que seleccionó no es válida"); }
                    }
                    else
                    {
                        Console.WriteLine("\nLa opción seleccionada no es válida\n");
                    }
                }
                else if(dic[opt].Type == "Canciones" || dic[opt].Type == "canciones" || dic[opt].Type == "Canción" || dic[opt].Type == "canción" || dic[opt].Type == "Cancion" || dic[opt].Type == "cancion")
                {
                    int pos = opt -counter - 1;
                    Console.WriteLine("\n¿Que desea hacer?");
                    Console.WriteLine("(a) Agregarla a Mis Playlists \n(b) Reproducir Playlist \n(c) Ver Canciones/Seleccionar de la Playlist");
                    string des = Console.ReadLine();
                    if (des == "a")
                    {
                        user.MyPlaylist1.Add(Files.AllPlaylistsSongs[pos]);
                        Console.WriteLine("\nSu Playlist se ha agregado correctamente");
                    }
                    else if (des == "b")
                    {
                        computer.AutomaticRep(Files.AllPlaylistsSongs[pos].Playlistsong);
                    }
                    else if (des == "c")
                    {
                        Dictionary<int, Songs> dic5 = new Dictionary<int, Songs>();
                        Console.WriteLine("\nSeleccione la canción que desee:\n");
                        int count = 1;
                        foreach (Songs song in Files.AllPlaylistsSongs[pos].Playlistsong)
                        {
                            Console.WriteLine("(" + count + ")" + song.Title1);
                            dic5.Add(count, song);
                            count += 1;
                        }
                        int option = Convert.ToInt32(Console.ReadLine());
                        Songs songs2 = dic5[option];
                        songs2.SongsInformation();
                        Console.WriteLine("\n¿Que desea hacer con la canción?");
                        Console.WriteLine("(a) Reproducir\n(b) Valorar Canción\n(c) Agregar a una Playlist\n(d) Nada (Solo quería ver la información de la Canción)");
                        string option2 = Console.ReadLine();
                        if (option2 == "a")
                        {
                            songs2.Play();
                        }
                        else if (option2 == "b")
                        {
                            Console.WriteLine("Seleccione la valoración que desea para la canción (double)");
                            double val = Convert.ToDouble(Console.ReadLine());
                            songs2.Rating1.Add(val);
                            computer.Rate("Cancion", songs2.Title1, songs2.Rating1);
                            Thread.Sleep(1000);
                        }
                        else if (option2 == "c")
                        {
                            if (user.Type == "Premium")
                            {
                                if (user.MyPlaylist1.Count() > 0)
                                {
                                    Dictionary<int, Playlists> dic6 = new Dictionary<int, Playlists>();
                                    Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                                    int counter6 = 1;
                                    foreach (Playlists playlist in user.MyPlaylist1)
                                    {
                                        Console.WriteLine("(" + counter6 + ")" + playlist.Name);
                                        dic6.Add(counter6, playlist);
                                        counter6 += 1;
                                    }
                                    int choice = Convert.ToInt32(Console.ReadLine());
                                    if (choice != 0)
                                    {
                                        Playlists playlist2 = dic6[choice];
                                        playlist2.Playlistsong.Add(songs2);
                                        user.MyPlaylist1.RemoveAt(choice - 1);
                                        user.MyPlaylist1.Insert(choice - 1, playlist2);
                                    }
                                }
                            }
                            else if (user.Type == "Free")
                            {
                                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                            }
                        }
                        else if (option2 == "d")
                        {
                            Console.WriteLine();
                        }
                        else { Console.WriteLine("La opción que seleccionó no es válida"); }
                    }
                    else
                    {
                        Console.WriteLine("\nLa opción seleccionada no es válida\n");
                    }
                }
                Thread.Sleep(2000);
            }
            else if (user.Type == "Free")
            {
                Console.WriteLine();
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
            }
        }

        public static void Search(Computer computer, User userlogin)
        {
            computer.Searcher(userlogin);
        }

        public static void SeeMoviesSearch(Computer computer, User userlogin, List<Movies> MOVIES)
        {
            Dictionary<int, Movies> dic = new Dictionary<int, Movies>();
            Console.WriteLine("\nSeleccione la película que desee:\n");
            int counter = 1;
            foreach (Movies movie in MOVIES)
            {
                Console.WriteLine("(" + counter + ")" + movie.Title1);
                dic.Add(counter, movie);
                counter += 1;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            Movies movie2 = dic[option];
            movie2.MovieInformation();
            Console.WriteLine("\n¿Que desea hacer con la película?");
            Console.WriteLine("(a) Reproducir\n(b) Valorar Película\n(c) Agregar a una Playlist\n(d) Seleccionar otra película\n(e) Nada (Solo quería ver la información de la Película)");
            string option2 = Console.ReadLine();
            if (option2 == "a")
            {
                movie2.Play();
            }
            else if (option2 == "b")
            {
                Console.WriteLine("Seleccione la valoración que desea para la película (double)");
                double val = Convert.ToDouble(Console.ReadLine());
                movie2.Rating1.Add(val);
                computer.Rate("Pelicula", movie2.Title1, movie2.Rating1);
                Thread.Sleep(1000);
            }
            else if (option2 == "c")
            {
                if (userlogin.Type == "Premium")
                {
                    Dictionary<int, Playlists> dic2 = new Dictionary<int, Playlists>();
                    Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                    int counter2 = 1;
                    foreach (Playlists playlist in userlogin.MyPlaylist1)
                    {
                        Console.WriteLine("(" + counter2 + ")" + playlist.Name);
                        dic2.Add(counter2, playlist);
                        counter += 1;
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice != 0)
                    {
                        Playlists playlist2 = dic2[choice];
                        playlist2.Playlistmovie.Add(movie2);
                        userlogin.MyPlaylist1.RemoveAt(choice - 1);
                        userlogin.MyPlaylist1.Insert(choice - 1, playlist2);
                    }
                }
                else if (userlogin.Type == "Free")
                {
                    Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                    Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                }
            }
            else if (option2 == "d")
            {
                SeeMoviesSearch(computer, userlogin, MOVIES);
            }
            else if (option2 == "e")
            {
                Console.WriteLine();
            }
            else { Console.WriteLine("La opción que seleccionó no es válida"); }
        }

        public static void SeeSongsSearch(Computer computer, User userlogin, List<Songs> SONGS)
        {
            Dictionary<int, Songs> dic = new Dictionary<int, Songs>();
            Console.WriteLine("\nSeleccione la canción que desee:\n");
            int counter = 1;
            foreach (Songs songs in SONGS)
            {
                Console.WriteLine("(" + counter + ")" + songs.Title1);
                dic.Add(counter, songs);
                counter += 1;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            Songs songs2 = dic[option];
            songs2.SongsInformation();
            Console.WriteLine("\n¿Que desea hacer con la canción?");
            Console.WriteLine("(a) Reproducir\n(b) Valorar Cnción\n(c) Agregar a una Playlist\n(d) Seleccionar otra canción\n(e) Nada (Solo quería ver la información de la Canción)");
            string option2 = Console.ReadLine();
            if (option2 == "a")
            {
                songs2.Play();
            }
            else if (option2 == "b")
            {
                Console.WriteLine("Seleccione la valoración que desea para la canción (double)");
                double val = Convert.ToDouble(Console.ReadLine());
                songs2.Rating1.Add(val);
                computer.Rate("Cancion", songs2.Title1, songs2.Rating1);
                Thread.Sleep(1000);
            }
            else if (option2 == "c")
            {
                if (userlogin.Type == "Premium")
                {
                    Dictionary<int, Playlists> dic2 = new Dictionary<int, Playlists>();
                    Console.WriteLine("\nSeleccione la Playlist que desee (si no desea agregarla a ningúna seleccione 0):\n");
                    int counter2 = 1;
                    foreach (Playlists playlist in userlogin.MyPlaylist1)
                    {
                        Console.WriteLine("(" + counter2 + ")" + playlist.Name);
                        dic2.Add(counter2, playlist);
                        counter += 1;
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice != 0)
                    {
                        Playlists playlist2 = dic2[choice];
                        playlist2.Playlistsong.Add(songs2);
                        userlogin.MyPlaylist1.RemoveAt(choice - 1);
                        userlogin.MyPlaylist1.Insert(choice - 1, playlist2);
                    }
                }
                else if (userlogin.Type == "Free")
                {
                    Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                    Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
                }
            }
            else if (option2 == "d")
            {
                SeeSongs(computer, userlogin);
            }
            else if (option2 == "e")
            {
                Console.WriteLine();
            }
            else { Console.WriteLine("La opción que seleccionó no es válida"); }
        }
        
    }   
}
