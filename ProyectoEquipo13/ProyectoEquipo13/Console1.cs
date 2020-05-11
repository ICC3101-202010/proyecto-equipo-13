using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public static class Console1
    {
        public static void InitialMessage()
        {
            Console.WriteLine("¡Bienvenido a Netfy! \n¡La nueva plataforma donde podrás tener tu música y películas en un solo lugar!");
        }

        public static User Account(Computer computer, User user, MailSender mailSender)
        {
            Console.WriteLine("Seleccione que desea hacer");
            Console.WriteLine("(a) Iniciar Sesión \n(b) Crear Cuenta \n(c) Cambiar contraseña \n(d) Cambiar nombre de usuario \n (e) Cambia tu cuenta de Free a Premium");
            string option = Console.ReadLine();
            computer.Registered += mailSender.OnRegistered;
            computer.PasswordChanged += mailSender.OnPasswordChanged;
            computer.UserNameChanged += mailSender.OnUserNameChanged;
            mailSender.EmailSent += user.OnEmailSent;
            user.EmailVerified += computer.OnEmailVerified;
            if (option == "a")
            {
                Console.WriteLine("Seleccione su Usuario:");
                string usrname = Console.ReadLine();
                Console.WriteLine("seleccione su Contraseña");
                string password = Console.ReadLine();
                string login = Files.LogIn(usrname, password);
                if (login == null)
                {
                    foreach (User i in Files.Users)
                    {
                        if (i.UserName == usrname && i.Password == password)
                        {
                            Thread.Sleep(2000);
                            Console.Clear();                           
                            return i;
                        }
                    }
                }
                else
                {
                    Console1.Account(computer, user, mailSender);
                }
            }
            else if (option == "b")
            {
                bool option2 = computer.Register();
                //Suponiendo que el mail si debería haber llegado
                if (option2 == true) { user.OnEmailSent(new object(), new EventArgs()); }
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "c")
            {
                Console.Clear();
                computer.ChangePassword();
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "d")
            {
                Console.Clear();
                computer.ChangeUserName();
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "e")
            {
                Console.Clear();
                computer.UpgradeFree();
                Console1.Account(computer, user, mailSender);
            }
            else
            {
                Console.WriteLine("La opción que seleccionó no es válida");
                Console1.Account(computer, user, mailSender);
            }
            Thread.Sleep(2000);
            Console.Clear();
            return null;
        }

        static void SecondMessage(Computer computer)
        {
            Console.WriteLine("¡Bienvenido al Menú!... Selecione la opción que desee:\n");
        }

        static void SeeMovies(Computer computer, Premium userlogin)
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
                //Nada Todavía
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

        static void SeeMovies(Computer computer, Free userlogin)
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
                //Nada Todavía
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
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
               
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

        public static void SeeSongs(Computer computer, Premium userlogin)
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
                //Nada Todavía
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

        public static void SeeSongs(Computer computer, Free userlogin)
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
                //Nada Todavía
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
                Console.WriteLine("Su usuario no es Premium, por lo que no puede tener Playlists");
                Console.WriteLine("Si desea poder acceder a este menú en inicio seleccione la opción 'Cambia tu cuenta de Free a Premium'");
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

        public static void CreatePlaylist(Computer computer, Premium user)
        {
            Console.WriteLine("Desea crear una Playlist (a)normal o (b)inteligente(agrega canciones automáticamente según un criterio");
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
                Console.WriteLine("¿De que tipo sera la Plylist? Película/Canción");
                string type = Console.ReadLine();
                Console.WriteLine("Eliga un nombre");
                string name = Console.ReadLine();
                Console.WriteLine("¿Desea hacer la Playlist (a) Privada o (b) Pública?");
                string privacidad = Console.ReadLine();
                Console.WriteLine("Elija el criterio de la SmartPlaylist(Género:Rock,Pop,etc o Artista: Michael Jakson,Elvis Presley,etc.)");
                string criterio = Console.ReadLine();
                if (privacidad == "a")
                {
                    user.MyPlaylist1.Add(computer.CreateSmartPlaylist(type,criterio,name,true));
                    Console.WriteLine("Playlist creada con éxito");
                }
                else if (privacidad == "b")
                {
                    user.MyPlaylist1.Add(computer.CreateSmartPlaylist(type,criterio, name, false));
                    Console.WriteLine("Playlist creada con éxito");
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

        public static void ModifiedPlaylist(Computer computer, Premium user)
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
                Console.WriteLine("Nombre cambiado con éxito");
            }
            else if (option2 == "b")
            {
                if(play.Type ==  "Pelicula" || play.Type == "Película" || play.Type == "pelicula" || play.Type == "película")
                {
                    Dictionary<int, Movies> dic2 = new Dictionary<int, Movies>();
                    int counter2 = 1;
                    foreach (Movies movies in play.Playlistmovie)
                    {
                        Console.WriteLine("La playlist contiene las siguientes películas: \n");
                        Console.WriteLine('(' + counter + ')' + movies.Title1);
                        dic2.Add(counter, movies);
                        counter2 += 1;

                    }
                    Console.WriteLine("Seleccione cual desea eliminar");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    play.Playlistmovie.RemoveAt(choise-1);

                }
                else if(play.Type == "Cancion" || play.Type == "Canción" || play.Type == "canción" || play.Type == "cancion")
                {
                    Dictionary<int, Songs> dic2 = new Dictionary<int, Songs>();
                    int counter2 = 1;
                    foreach (Songs songs in play.Playlistsong)
                    {
                        Console.WriteLine("La playlist contiene las siguientes canciones: \n");
                        Console.WriteLine('(' + counter + ')' + songs.Title1);
                        dic2.Add(counter, songs);
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
                        Console.WriteLine('(' + counter + ')' + movies.Title1);
                        dic2.Add(counter, movies);
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
                        Console.WriteLine('(' + counter + ')' + songs.Title1);
                        dic2.Add(counter, songs);
                        counter2 += 1;

                    }
                    int choise = Convert.ToInt32(Console.ReadLine());
                    Songs songs1 = dic2[choise];
                    play.Playlistsong.Add(songs1);
                }

            }
            else
            {
                Console.WriteLine("Comando ingresado no válido");
            }
        }

        public static void SeePlaylist(Computer computer, Premium user)
        {
            Dictionary<int, Playlists> dic = new Dictionary<int, Playlists>();
            Console.WriteLine("\nSeleccione la Playlist que desee:\n");
            int counter = 1;
            foreach (Playlists playlists in user.MyPlaylist1)
            {
                Console.WriteLine('(' + counter + ')' + playlists.Name);
                dic.Add(counter, playlists);
                counter += 1;
            }
        }

        public static void Search(Computer computer)
        {
            computer.Searcher();
        }

        public static void ChangeUser(Computer computer)
        {
            //Cambiar Usuario
        }
    }   
}
