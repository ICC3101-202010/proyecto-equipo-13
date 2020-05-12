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
        public static WindowsMediaPlayer wp = new WindowsMediaPlayer();

        public static void InitialMessage()
        {
            Console.WriteLine("¡Bienvenido a Netfy! \n¡La nueva plataforma donde podrás tener tu música y películas en un solo lugar!");
        }

        public static void SecondMessage(Computer computer)
        {
            Console.WriteLine("¡Bienvenido al Menú!... Selecione la opción que desee:\n");
        }

        public static void SeeMovies(Computer computer, User userlogin)
        {
            Dictionary<int, Movies> dic = new Dictionary<int, Movies>();
            Console.WriteLine("\nSeleccione la película que desee:\n");
            int counter = 1;
            foreach (Movies movie in Files.AllMovies)
            {
                Console.WriteLine('(' + counter + ')' + movie.Title1);
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
                        Console.WriteLine('(' + counter2 + ')' + playlist.Name);
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
            int counter = 1;
            foreach (Songs songs in Files.AllSongs)
            {
                Console.WriteLine('(' + counter + ')' + songs.Title1);
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
                        Console.WriteLine('(' + counter2 + ')' + playlist.Name);
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

        public static void CreatePlaylist(Computer computer, User user)
        {
            if (user.Type == "Premium")
            {
                Console.WriteLine("\nDe que tipo desea que sea su Playlist:");
                Console.WriteLine("(a) normal \n(b) inteligente(agrega canciones automáticamente según un criterio");
                string res = Console.ReadLine();
                if (res == "a")
                {
                    Console.WriteLine("¿De que tipo sera la Plylist? Película/Canción");
                    string type = Console.ReadLine();
                    Console.WriteLine("Eliga un nombre");
                    string name = Console.ReadLine();
                    Console.WriteLine("¿Desea hacer la Playlist (a) Privada o (b) Pública?");
                    string privacidad = Console.ReadLine();

                    if (privacidad == "a")
                    {
                        user.MyPlaylist1.Add(computer.CreatePlaylist(type, name, true));
                        Console.WriteLine("Playlist creada con éxito");

                    }
                    else if (privacidad == "b")
                    {
                        user.MyPlaylist1.Add(computer.CreatePlaylist(type, name, false));
                        Console.WriteLine("Playlist creada con éxito");
                    }
                    else
                    {
                        Console.WriteLine("Comando ingresado no válido");
                    }

                }
                else if (res == "b")
                {
                    Console.WriteLine("¿De que tipo sera la Playlist? Película/Canción");
                    string type = Console.ReadLine();
                    Console.WriteLine("Eliga un nombre");
                    string name = Console.ReadLine();
                    Console.WriteLine("¿Desea hacer la Playlist (a) Privada o (b) Pública?");
                    string privacidad = Console.ReadLine();
                    if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
                    {
                        Console.WriteLine("Elija el criterio de la SmartPlaylist(Género,Artista)");
                        string criterio = Console.ReadLine();
                        Console.WriteLine("Elija el nombre del criterio de la SmartPlaylist(ej: Género(rock,Pop),Artista(Michael Jakson,Elvis Presley))");
                        string namecriterio = Console.ReadLine();
                        if (privacidad == "a")
                        {
                            var a = computer.CreateSmartPlaylist(type, criterio, namecriterio, name, true);
                            Console.WriteLine("\nPlaylist creada con éxito");
                            if (criterio == "Genero" || criterio == "Género" || criterio == "genero" || criterio == "género")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    foreach(string genero in songs.Genre1)
                                    {
                                        if(genero == namecriterio)
                                        {
                                            a.Playlistsong.Add(songs);
                                        }
                                    }
                                }
                            }
                            else if (criterio == "Artista"|| criterio == "artista")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    if(songs.Artist1.Name == namecriterio)
                                    {
                                        a.Playlistsong.Add(songs);
                                    }
                                }
                            }
                            user.MyPlaylist1.Add(a);
                            Files.AllSmartPlaylistsSongs.Add(a);
                            Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
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
                            Files.AllSmartPlaylistsSongs.Add(a);
                            Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                        }

                    }
                    else if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
                    {
                        Console.WriteLine("Elija el criterio de la SmartPlaylist(Director,Categoria,Actor,Estudio)");
                        string criterio = Console.ReadLine();
                        Console.WriteLine("Elija el nombre del criterio de la SmartPlaylist(ej: Estudio(Pixar,Universal Studio), Director(Guillermo Del Toro,Steven Spielberg)");
                        string namecriterio = Console.ReadLine();
                        if (privacidad == "a")
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
                                    foreach(string cate in movies.Categories1)
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
                            Files.AllSmartPlaylistsMovies.Add(a);
                            Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
                        }
                        else if (privacidad=="b")
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
                            Files.AllSmartPlaylistsMovies.Add(a);
                            Console.WriteLine("Si quiere Agregarle Elementos vaya a la opción Modificar Playlist");
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
                //Cambiar nombre, sacar elementos, agregar elementos, etc etc
                Dictionary<int, Playlists> dic = new Dictionary<int, Playlists>();
                Console.WriteLine("\nSeleccione la Playlist que desee:\n");
                int counter = 1;
                foreach (Playlists playlists in user.MyPlaylist1)
                {
                    Console.WriteLine('(' + counter + ')' + playlists.Name);
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
                    if (play.Type == "Pelicula" || play.Type == "Película" || play.Type == "pelicula" || play.Type == "película")
                    {
                        Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                        int counter2 = 1;
                        foreach (Movies movies in play.Playlistmovie)
                        {
                            Console.WriteLine("La playlist contiene las siguientes películas: \n");
                            Console.WriteLine('(' + counter2 + ')' + movies.Title1);
                            dic2.Add(counter2, movies);
                            counter2 += 1;

                        }
                        Console.WriteLine("Seleccione cual desea eliminar");
                        int choise = Convert.ToInt32(Console.ReadLine());
                        play.Playlistmovie.RemoveAt(choise - 1);

                    }
                    else if (play.Type == "Cancion" || play.Type == "Canción" || play.Type == "canción" || play.Type == "cancion")
                    {
                        Dictionary<int, Songs> dic2 = new Dictionary<int, Songs>();
                        int counter2 = 1;
                        foreach (Songs songs in play.Playlistsong)
                        {
                            Console.WriteLine("La playlist contiene las siguientes canciones: \n");
                            Console.WriteLine('(' + counter2 + ')' + songs.Title1);
                            dic2.Add(counter2, songs);
                            counter2 += 1;

                        }
                        Console.WriteLine("Seleccione cual desea eliminar");
                        int choise = Convert.ToInt32(Console.ReadLine());
                        play.Playlistsong.RemoveAt(choise - 1);
                    }
                }
                else if (option2 == "c")
                {
                    if (play.Type == "Pelicula" || play.Type == "Película" || play.Type == "pelicula" || play.Type == "película")
                    {
                        Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                        int counter2 = 1;
                        foreach (Movies movies in Files.AllMovies)
                        {
                            Console.WriteLine("¿Qué película desea agregar? \n");
                            Console.WriteLine('(' + counter2 + ')' + movies.Title1);
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
                        foreach (Songs songs in Files.AllSongs)
                        {
                            Console.WriteLine("¿Qué canción desea agregar? \n");
                            Console.WriteLine('(' + counter2 + ')' + songs.Title1);
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
                    Console.WriteLine('(' + counter + ')' + playlists.Name);
                    dic.Add(counter, playlists);
                    counter += 1;
                }
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                user.MyPlaylist1[choice - 1].VerPlaylist();
                Console.WriteLine("\nQue desea realizar:");
                Console.WriteLine("(a) Poner una Canción/Película en específico\n(b) Reproducir Canción/Película Aleatoria");
                string option = Console.ReadLine();
                if (option == "a")
                {
                    if (user.MyPlaylist1[choice - 1].Type == "Película" || user.MyPlaylist1[choice - 1].Type == "Películas" || user.MyPlaylist1[choice - 1].Type == "Pelicula" || user.MyPlaylist1[choice - 1].Type == "Peliculas" || user.MyPlaylist1[choice - 1].Type == "película" || user.MyPlaylist1[choice - 1].Type == "películas" || user.MyPlaylist1[choice - 1].Type == "pelicula" || user.MyPlaylist1[choice - 1].Type == "peliculas")
                    {
                        Dictionary<int, Movies> dic3 = new Dictionary<int, Movies>();
                        Console.WriteLine("\nSeleccione la Película que desee ver:\n");
                        int counter2 = 1;
                        for (int i = 0; i < user.MyPlaylist1[choice - 1].Playlistmovie.Count; i++)
                        {
                            Console.WriteLine('(' + counter2 + ')' + user.MyPlaylist1[choice - 1].Playlistmovie[i].Title1);
                            dic3.Add(counter2, user.MyPlaylist1[choice - 1].Playlistmovie[i]);
                            counter2 += 1;
                        }
                        int movieselection = Convert.ToInt32(Console.ReadLine());
                        //Falta método reproducir
                        user.MyPlaylist1[choice - 1].Playlistmovie[movieselection - 1].Play();
                    }
                    else if (user.MyPlaylist1[choice - 1].Type == "Canción" || user.MyPlaylist1[choice - 1].Type == "Canciones" || user.MyPlaylist1[choice - 1].Type == "canción" || user.MyPlaylist1[choice - 1].Type == "canciones" || user.MyPlaylist1[choice - 1].Type == "Cancion" || user.MyPlaylist1[choice - 1].Type == "cancion")
                    {
                        Dictionary<int, Songs> dic4 = new Dictionary<int, Songs>();
                        Console.WriteLine("\nSeleccione la Canción que desee ver:\n");
                        int counter2 = 1;
                        for (int i = 0; i < user.MyPlaylist1[choice - 1].Playlistsong.Count; i++)
                        {
                            Console.WriteLine('(' + counter2 + ')' + user.MyPlaylist1[choice - 1].Playlistsong[i].Title1);
                            dic4.Add(counter2, user.MyPlaylist1[choice - 1].Playlistsong[i]);
                            counter2 += 1;
                        }
                        int songselection = Convert.ToInt32(Console.ReadLine());
                        //Falta método reproducir
                        user.MyPlaylist1[choice - 1].Playlistsong[songselection - 1].Play();
                    }
                }
                else if (option == "b")
                {
                    if (user.MyPlaylist1[choice - 1].Type == "Película" || user.MyPlaylist1[choice - 1].Type == "Películas" || user.MyPlaylist1[choice - 1].Type == "Pelicula" || user.MyPlaylist1[choice - 1].Type == "Peliculas" || user.MyPlaylist1[choice - 1].Type == "película" || user.MyPlaylist1[choice - 1].Type == "películas" || user.MyPlaylist1[choice - 1].Type == "pelicula" || user.MyPlaylist1[choice - 1].Type == "peliculas")
                    {
                        Random rdn = new Random();
                        int num = rdn.Next(user.MyPlaylist1[choice - 1].Playlistmovie.Count);
                        //Falta método reproducir
                        user.MyPlaylist1[choice - 1].Playlistmovie[num].Play();
                    }
                    else if (user.MyPlaylist1[choice - 1].Type == "Canción" || user.MyPlaylist1[choice - 1].Type == "Canciones" || user.MyPlaylist1[choice - 1].Type == "canción" || user.MyPlaylist1[choice - 1].Type == "canciones" || user.MyPlaylist1[choice - 1].Type == "Cancion" || user.MyPlaylist1[choice - 1].Type == "cancion")
                    {
                        Random rdn = new Random();
                        int num = rdn.Next(user.MyPlaylist1[choice - 1].Playlistsong.Count);
                        //Falta método reproducir
                        user.MyPlaylist1[choice - 1].Playlistsong[num].Play();
                    }
                }
                else
                {
                    Console.WriteLine("La opción seleccionada no es válida");
                }
            }
            else if (user.Type == "Free")
            {
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
                Console.WriteLine('(' + counter + ')' + movie.Title1);
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
                        Console.WriteLine('(' + counter2 + ')' + playlist.Name);
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
                Console.WriteLine('(' + counter + ')' + songs.Title1);
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
                        Console.WriteLine('(' + counter2 + ')' + playlist.Name);
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
