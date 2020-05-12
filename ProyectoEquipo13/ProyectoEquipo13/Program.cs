using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;

namespace ProyectoEquipo13
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;

            IFormatter formatter = new BinaryFormatter();
            IFormatter formatter2 = new BinaryFormatter();

            string urlAllMovies = Directory.GetCurrentDirectory() + "\\AllMovies.bin";
            string urlAllSongs = Directory.GetCurrentDirectory() + "\\AllSongs.bin";
            string urlAllPlaylistsSongs = Directory.GetCurrentDirectory() + "\\AllPlaylistsSongs.bin";
            string urlAllPlaylistsMovies = Directory.GetCurrentDirectory() + "\\AllPlaylistsMovies.bin";
            string urlUsers = Directory.GetCurrentDirectory() + "\\Users.bin";

            if (File.Exists(urlAllMovies) && File.Exists(urlAllSongs) && File.Exists(urlAllPlaylistsSongs) && File.Exists(urlAllPlaylistsMovies) && File.Exists(urlUsers))
            {
                Stream stream1 = new FileStream("AllMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream2 = new FileStream("AllSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream3 = new FileStream("AllPlaylistsSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream4 = new FileStream("AllPlaylistsMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream5 = new FileStream("Users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            }


            //Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //Files.AllMovies = (List<Movies>)formatter.Deserialize(stream);               
            //Files.AllSongs = (List<Songs>)formatter.Deserialize(stream);
            //Files.AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            //Files.AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            //Files.Users = (List<User>)formatter.Deserialize(stream);
            //stream.Close();

            Computer computer = new Computer();
            MailSender mailSender = new MailSender();
            User emptyuser = new User();
            {
                char M = 'M';
                char F = 'F';

                //CANCIONES

                //GENERICOS
                string Type = ".mp3";
                int LenghtS = 165;
                string LyricsS = "letra";
                string ResolutionS = "192kbps";
                string MemoryS = "3,78MB";
                int numReproductionsS = 0;
                double RatingProm = 0; //CANCION Y PELICULA
                List<double> Rating = new List<double>(); //CANCION Y PELICULA
                int MinS = 0;

                //SONG 1
                Artist phill_collins = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M, "");
                Album Tarzan_album = new Album("Tarzan: An Original Walt Disney Records Soundtrack", DateTime.Now, phill_collins);
                List<string> Genre_Son_of_man = new List<string>();
                Genre_Son_of_man.Add("Pop Rock");
                Genre_Son_of_man.Add("Soft Rock");
                string Music_Son_of_man = @"\Tarzan_-Son_Of_Man_Phil_Collins";
                Songs Son_of_man = new Songs("Son of man", phill_collins, phill_collins, phill_collins, LenghtS, Genre_Son_of_man, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Son_of_man, Type, MinS, Tarzan_album);
                Files.AllSongs.Add(Son_of_man);


                //SONG 2
                Artist celine_dion = new Artist("Celine Dion", new DateTime(1968, 3, 30, 5, 5, 5), F, "");
                Person james_horner = new Person("James Horner", new DateTime(1953, 8, 14, 5, 5, 5), M, "");
                Album Titanic_album = new Album("Titanic: Music From The Motion Picture ", DateTime.Now, celine_dion);
                List<string> Genre_My_heart_will_go_on = new List<string>();
                Genre_My_heart_will_go_on.Add("Pop");
                Genre_My_heart_will_go_on.Add("Balada");
                string Music_My_heart_will_go_on = @"\";
                Songs My_heart_will_go_on = new Songs("My heart will go on", james_horner, celine_dion, james_horner, LenghtS, Genre_My_heart_will_go_on, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_My_heart_will_go_on, Type, MinS, Titanic_album);
                Files.AllSongs.Add(My_heart_will_go_on);

                //SONG 3
                Album Face_value_album = new Album("Face Vlue", new DateTime(1981, 1, 5, 5, 5, 5), phill_collins);
                List<string> Genre_In_the_air_tonight = new List<string>();
                Genre_In_the_air_tonight.Add("Soft Rock");
                Genre_In_the_air_tonight.Add("Power Ballad");
                string Music_In_the_air_tonight = @"\";
                Songs In_the_air_tonight = new Songs("In the air tonight", phill_collins, phill_collins, phill_collins, LenghtS, Genre_In_the_air_tonight, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_In_the_air_tonight, Type, MinS, Face_value_album);
                Files.AllSongs.Add(In_the_air_tonight);

                //SONG 4
                List<string> Genre_This_must_be_love = new List<string>();
                Genre_This_must_be_love.Add("Pop Rock");
                Genre_This_must_be_love.Add("Art Rock");
                Genre_This_must_be_love.Add("R&B");
                string Music_This_must_be_love = @"\";
                Songs This_must_be_love = new Songs("This must be love", phill_collins, phill_collins, phill_collins, LenghtS, Genre_This_must_be_love, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_This_must_be_love, Type, MinS, Face_value_album);
                Files.AllSongs.Add(This_must_be_love);

                //SONG 5
                Artist randy_newman = new Artist("Randy Newman", new DateTime(1943, 11, 28, 5, 5, 5), M, "");
                Album Toy_Story_album = new Album("Toy Story", new DateTime(1996, 4, 12, 5, 5, 5), randy_newman);
                List<string> Genre_Youve_got_a_friend_in_me = new List<string>();
                string Music_Youve_got_a_friend_in_me = @"\";
                Songs Youve_got_a_friend_in_me = new Songs("You've got a friend in me", randy_newman, randy_newman, randy_newman, LenghtS, Genre_Youve_got_a_friend_in_me, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Youve_got_a_friend_in_me, Type, MinS, Toy_Story_album);
                Files.AllSongs.Add(Youve_got_a_friend_in_me);

                //SONG 6
                Artist sia = new Artist("Sia", new DateTime(1943, 11, 28, 5, 5, 5), F, "");
                Album Forms_album = new Album("1000 Forms of fear", new DateTime(2014, 3, 14, 5, 5, 5), sia);
                List<string> Genre_Chandelier = new List<string>();
                Genre_Chandelier.Add("Pop");
                string Music_Chandelier = @"\";
                Songs Chandelier = new Songs("Chandelier", sia, sia, sia, LenghtS, Genre_Chandelier, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Chandelier, Type, MinS, Forms_album);
                Files.AllSongs.Add(Chandelier);

                //SONG 7
                List<string> Genre_Elastic_heart = new List<string>();
                Genre_Elastic_heart.Add("Electropop");
                string Music_Elastic_heart = @"\";
                Songs Elastic_heart = new Songs("Elastic Heart", sia, sia, sia, LenghtS, Genre_Elastic_heart, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Elastic_heart, Type, MinS, Forms_album);
                Files.AllSongs.Add(Elastic_heart);

                //SONG 8
                Artist diplo = new Artist("Diplo", new DateTime(1978, 11, 10, 5, 5, 5), M, "");
                Artist justin_bieber = new Artist("Justin Bieber", new DateTime(1994, 3, 1, 5, 5, 5), M, "");
                Album My_world_album = new Album("My World 2.0", new DateTime(2010, 5, 5, 5, 5, 5), justin_bieber);
                List<string> Genre_Where_are_u_now = new List<string>();
                Genre_Where_are_u_now.Add("Pop");
                string Music_Where_are_u_now = @"\";
                Songs Where_are_u_now = new Songs("Where are Ü now", diplo, justin_bieber, diplo, LenghtS, Genre_Where_are_u_now, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Where_are_u_now, Type, MinS, My_world_album);
                Files.AllSongs.Add(Where_are_u_now);

                //SONG 9
                Artist maroon_5 = new Artist("Maroon 5", new DateTime(1997, 1, 1, 5, 5, 5), M, "");
                Artist adam_levine = new Artist("Adam Levine", new DateTime(1979, 3, 18, 5, 5, 5), M, "");
                Album V_album = new Album("V", new DateTime(2014, 9, 2, 5, 5, 5), maroon_5);
                List<string> Genre_Sugar = new List<string>();
                Genre_Sugar.Add("Pop Rock");
                string Music_Sugar = @"\";
                Songs Sugar = new Songs("Sugar", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Sugar, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Sugar, Type, MinS, V_album);
                Files.AllSongs.Add(Sugar);

                //SONG 10
                List<string> Genre_Maps = new List<string>();
                Genre_Maps.Add("Pop Rock");
                Genre_Maps.Add("Dance Pop");
                string Music_Maps = @"\";
                Songs Maps = new Songs("Maps", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Maps, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Maps, Type, MinS, V_album);
                Files.AllSongs.Add(Maps);

                //_________________________________________________________________________________
                //PELICULAS

                //GENERICOS
                int Lenght = 88;
                string Description = "descripcion";
                string Resolution = "617kbps";
                string Memory = "12,2MB";
                int numReproductions = 0;
                int Min = 0;

                //MOVIE 1
                Person kevin_lima = new Person("Kevin Lima", new DateTime(1962, 6, 12, 5, 5, 5), M, "");
                List<Person> Actors_Tarzan = new List<Person>();
                Person frank_welker = new Person("Frank Welker", new DateTime(1946, 3, 12, 5, 5, 5), M, "");
                Person danielle_keaton = new Person("Danielle Keaton", new DateTime(1986, 7, 30, 5, 5, 5), F, "");
                Actors_Tarzan.Add(frank_welker);
                Actors_Tarzan.Add(danielle_keaton);
                Person tab_murphay = new Person("Tab Murphy", new DateTime(1966, 2, 25, 5, 5, 5), F, "");
                List<string> Categories_Tarzan = new List<string>();
                Categories_Tarzan.Add("Animación musical");
                Categories_Tarzan.Add("Aventura");
                Categories_Tarzan.Add("Comedia");
                string Trailer_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
                string Video_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
                List<Songs> Songs_Tarzan = new List<Songs>();
                Songs_Tarzan.Add(Son_of_man);
                Movies Tarzan = new Movies("Tarzan", kevin_lima, Actors_Tarzan, tab_murphay, Lenght, Categories_Tarzan, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Tarzan, Video_Tarzan, Songs_Tarzan, Min);
                Files.AllMovies.Add(Tarzan);

                //MOVIE 2
                Person tom_hanks = new Person("Tom Hanks", new DateTime(1956, 7, 9, 5, 5, 5), M, "");
                Person josh_cooley = new Person("Josh Cooley", new DateTime(1950, 11, 23, 5, 5, 5), M, "");
                Person tim_allen = new Person("Tim Allen", new DateTime(1955, 9, 26, 5, 5, 5), M, "");
                Person annie_potts = new Person("Annie Potts", new DateTime(1976, 10, 3, 5, 5, 5), F, "");
                Person john_lasseter = new Person("John Lasseter", new DateTime(1957, 1, 12, 5, 5, 5), M, "");
                List<Person> Actors_Toy_story_4 = new List<Person>();
                Actors_Toy_story_4.Add(tom_hanks);
                Actors_Toy_story_4.Add(tim_allen);
                Actors_Toy_story_4.Add(annie_potts);
                List<string> Categories_Toy_story_4 = new List<string>();
                Categories_Toy_story_4.Add("Animación");
                Categories_Toy_story_4.Add("Aventura");
                Categories_Toy_story_4.Add("Comedia");
                string Video_Toy_story_4 = @"\";
                string Trailer_Toy_story_4 = @"\";
                List<Songs> Songs_Toy_story_4 = new List<Songs>();
                Songs_Toy_story_4.Add(Youve_got_a_friend_in_me);
                Movies Toy_story_4 = new Movies("Toy Story 4", josh_cooley, Actors_Toy_story_4, john_lasseter, Lenght, Categories_Toy_story_4, "Walt Disney Pictures", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_4, Video_Toy_story_4, Songs_Toy_story_4, Min);
                Files.AllMovies.Add(Toy_story_4);

                //MOVIE 3 
                Person lee_unkrich = new Person("Lee Unkrich", new DateTime(1967, 8, 8, 5, 5, 5), M, "");
                Person darla_anderson = new Person("Darla Anderson", new DateTime(1970, 8, 22, 5, 5, 5), F, "");
                List<Person> Actors_Toy_story_3 = new List<Person>();
                Actors_Toy_story_3.Add(tom_hanks);
                Actors_Toy_story_3.Add(tim_allen);
                List<string> Categories_Toy_story_3 = new List<string>();
                Categories_Toy_story_3.Add("Animación");
                Categories_Toy_story_3.Add("Aventura");
                Categories_Toy_story_3.Add("Comedia");
                string Video_Toy_story_3 = @"\";
                string Trailer_Toy_story_3 = @"\";
                List<Songs> Songs_Toy_story_3 = new List<Songs>();
                Songs_Toy_story_3.Add(Youve_got_a_friend_in_me);
                Movies Toy_story_3 = new Movies("Toy Story 3", lee_unkrich, Actors_Toy_story_3, darla_anderson, Lenght, Categories_Toy_story_3, "Walt Disney Pictures", Description, "2010", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_3, Video_Toy_story_3, Songs_Toy_story_3, Min);
                Files.AllMovies.Add(Toy_story_3);

                //MOVIE 4
                Person james_cameron = new Person("James Cameron", new DateTime(1954, 8, 16, 5, 5, 5), M, "");
                Person leonardo_dicaprio = new Person("Leonardo DiCaprio", new DateTime(1974, 11, 11, 5, 5, 5), M, "");
                Person kate_winslet = new Person("Kate Winslet", new DateTime(1975, 10, 5, 5, 5, 5), F, "");
                List<Person> Actors_Titanic = new List<Person>();
                Actors_Titanic.Add(leonardo_dicaprio);
                Actors_Titanic.Add(kate_winslet);
                List<string> Categories_Titanic = new List<string>();
                Categories_Titanic.Add("Romance");
                Categories_Titanic.Add("Catastrofe");
                Categories_Titanic.Add("Drama");
                string Video_Titanic = @"\";
                string Trailer_Titanic = @"\";
                List<Songs> Songs_Titanic = new List<Songs>();
                Songs_Titanic.Add(My_heart_will_go_on);
                Movies Titanic = new Movies("Titanic", james_cameron, Actors_Titanic, james_cameron, Lenght, Categories_Titanic, "20th Century Fox", Description, "1997", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Titanic, Video_Titanic, Songs_Titanic, Min);
                Files.AllMovies.Add(Titanic);

                //MOVIE 5
                Person andrew_stanton = new Person("Andrew Stanton", new DateTime(1965, 12, 3, 5, 5, 5), M, "");
                List<Person> Actors_Toy_story_2 = new List<Person>();
                Actors_Toy_story_2.Add(tom_hanks);
                Actors_Toy_story_2.Add(tim_allen);
                List<string> Categories_Toy_story_2 = new List<string>();
                Categories_Toy_story_2.Add("Animación");
                Categories_Toy_story_2.Add("Aventura");
                Categories_Toy_story_2.Add("Comedia");
                string Video_Toy_story_2 = @"\";
                string Trailer_Toy_story_2 = @"\";
                List<Songs> Songs_Toy_story_2 = new List<Songs>();
                Songs_Toy_story_2.Add(Youve_got_a_friend_in_me);
                Movies Toy_story_2 = new Movies("Toy Story 2", john_lasseter, Actors_Toy_story_2, andrew_stanton, Lenght, Categories_Toy_story_2, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_2, Video_Toy_story_2, Songs_Toy_story_2, Min);
                Files.AllMovies.Add(Toy_story_2);

                //MOVIE 6
                List<Person> Actors_Toy_story = new List<Person>();
                Actors_Toy_story.Add(tom_hanks);
                Actors_Toy_story.Add(tim_allen);
                List<string> Categories_Toy_story = new List<string>();
                Categories_Toy_story.Add("Animación");
                Categories_Toy_story.Add("Aventura");
                Categories_Toy_story.Add("Comedia");
                string Video_Toy_story = @"\";
                string Trailer_Toy_story = @"\";
                List<Songs> Songs_Toy_story = new List<Songs>();
                Songs_Toy_story.Add(Youve_got_a_friend_in_me);
                Movies Toy_story = new Movies("Toy Story", john_lasseter, Actors_Toy_story, andrew_stanton, Lenght, Categories_Toy_story, "Pixar", Description, "1995", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story, Video_Toy_story, Songs_Toy_story, Min);
                Files.AllMovies.Add(Toy_story);

                //MOVIE 7
                Person martin_scorsese = new Person("Martin Scorsese", new DateTime(1942, 11, 17, 5, 5, 5), M, "");
                Person terence_winter = new Person("Terence Winter", new DateTime(1960, 10, 2, 5, 5, 5), M, "");
                Person margot_robbie = new Person("Margot Robie", new DateTime(1990, 7, 2, 5, 5, 5), F, "");
                Person matthew_mcconaughey = new Person("Matthew McConaughey", new DateTime(1969, 11, 4, 5, 5, 5), M, "");
                List<Person> Actors_The_wolf_of_wall_street = new List<Person>();
                Actors_The_wolf_of_wall_street.Add(leonardo_dicaprio);
                Actors_The_wolf_of_wall_street.Add(margot_robbie);
                Actors_The_wolf_of_wall_street.Add(matthew_mcconaughey);
                List<string> Categories_The_wolf_of_wall_street = new List<string>();
                Categories_The_wolf_of_wall_street.Add("Biografía");
                Categories_The_wolf_of_wall_street.Add("Comedia");
                string Video_The_wolf_of_wall_street = @"\";
                string Trailer_The_wolf_of_wall_street = @"\";
                List<Songs> Songs_The_wolf_of_wall_street = new List<Songs>();
                Movies The_wolf_of_wall_street = new Movies("The Wolf of Wall street", martin_scorsese, Actors_The_wolf_of_wall_street, terence_winter, Lenght, Categories_The_wolf_of_wall_street, "Paramount Pictures", Description, "2013", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_wolf_of_wall_street, Video_The_wolf_of_wall_street, Songs_The_wolf_of_wall_street, Min);
                Files.AllMovies.Add(The_wolf_of_wall_street);

                //MOVIE 8
                Person christopher_nolan = new Person("Christopher Nolan", new DateTime(1970, 7, 30, 5, 5, 5), M, "");
                Person anne_hathaway = new Person("Anne Hathaway", new DateTime(1982, 11, 12, 5, 5, 5), F, "");
                List<Person> Actors_Interestellar = new List<Person>();
                Actors_Interestellar.Add(anne_hathaway);
                Actors_Interestellar.Add(matthew_mcconaughey);
                List<string> Categories_Interestellar = new List<string>();
                Categories_Interestellar.Add("Ciencia Ficción");
                string Video_Interestellar = @"\";
                string Trailer_Interestellar = @"\";
                List<Songs> Songs_Interestellar = new List<Songs>();
                Movies Interestellar = new Movies("Interestellar", christopher_nolan, Actors_Interestellar, christopher_nolan, Lenght, Categories_Interestellar, "Paramount Pictures", Description, "2014", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Interestellar, Video_Interestellar, Songs_Interestellar, Min);
                Files.AllMovies.Add(Interestellar);

                //MOVIE 9
                Person steven_rogers = new Person("Steven Rogers", new DateTime(1953, 4, 3, 5, 5, 5), M, "");
                Person allison_janney = new Person("Allison Janney", new DateTime(1959, 11, 19, 5, 5, 5), F, "");
                List<Person> Actors_I_tonya = new List<Person>();
                Actors_I_tonya.Add(margot_robbie);
                Actors_I_tonya.Add(allison_janney);
                List<string> Categories_I_tonya = new List<string>();
                Categories_I_tonya.Add("Drama");
                Categories_I_tonya.Add("Bibliográfica");
                string Video_I_tonya = @"\";
                string Trailer_I_tonya = @"\";
                List<Songs> Songs_I_tonya = new List<Songs>();
                Movies I_tonya = new Movies("I, Tonya", margot_robbie, Actors_I_tonya, steven_rogers, Lenght, Categories_I_tonya, "LuckyChap", Description, "2017", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_I_tonya, Video_I_tonya, Songs_I_tonya, Min);
                Files.AllMovies.Add(I_tonya);

                //MOVIE 10
                Person robert_deniro = new Person("Robert De Niro", new DateTime(1943, 8, 17, 5, 5, 5), M, "");
                Person al_pacino = new Person("Al Pacino", new DateTime(1940, 4, 25, 5, 5, 5), M, "");
                Person joe_pesci = new Person("Joe Pesci", new DateTime(1943, 2, 9, 5, 5, 5), M, "");
                Person steven_zaillian = new Person("Steven Zaillian", new DateTime(1953, 1, 30, 5, 5, 5), M, "");
                List<Person> Actors_The_irishman = new List<Person>();
                Actors_The_irishman.Add(robert_deniro);
                Actors_The_irishman.Add(al_pacino);
                Actors_The_irishman.Add(joe_pesci);
                List<string> Categories_The_irishman = new List<string>();
                Categories_The_irishman.Add("Drama");
                Categories_The_irishman.Add("Bibliográfica");
                string Video_The_irishman = @"\";
                string Trailer_The_irishman = @"\";
                List<Songs> Songs_The_irishman = new List<Songs>();
                Movies The_irishman = new Movies("The Irishman", martin_scorsese, Actors_The_irishman, steven_zaillian, Lenght, Categories_The_irishman, "TriBeCa", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_irishman, Video_The_irishman, Songs_The_irishman, Min);
                Files.AllMovies.Add(The_irishman);
            }

            Console1.InitialMessage();
            while (true)
            {
                Console.WriteLine("\n¿Qué desea realizar?");
                Console.WriteLine("(a) Iniciar/Crear Sesión, modificar cuenta\n(b) Salir del programa");
                string desition = Console.ReadLine();
                if (desition == "a")
                {
                    computer.Registered += mailSender.OnRegistered;
                    computer.PasswordChanged += mailSender.OnPasswordChanged;
                    mailSender.EmailSent += emptyuser.OnEmailSent;
                    emptyuser.EmailVerified += computer.OnEmailVerified;
                    int nmro = 1;
                    List<string> userlogin2 = new List<string>();
                    while (nmro!=0)
                    {
                        Console.WriteLine("Seleccione que desea hacer");
                        Console.WriteLine("(a) Iniciar Sesión \n(b) Crear Cuenta \n(c) Cambiar contraseña\n(d) Cambia tu cuenta de Free a Premium");
                        string option = Console.ReadLine();
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
                                        userlogin2.Add(i.UserName);
                                        userlogin2.Add(i.Password);
                                        nmro = 0;
                                    }
                                }
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nNo es posible iniciar sesión, la cuenta no existe o se equivoco al escribir usuario y/o contraseña\n");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        else if (option == "b")
                        {
                            bool option2 = computer.Register();
                            //Suponiendo que el mail si debería haber llegado
                            if (option2 == true) { emptyuser.OnEmailSent(new object(), new EventArgs()); }
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        else if (option == "c")
                        {
                            Console.Clear();
                            computer.ChangePassword();
                        }
                        else if (option == "d")
                        {
                            Console.Clear();
                            computer.UpgradeFree();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("La opción que seleccionó no es válida");
                        }
                    }
                    
                    while (true)
                    {
                        User userlogin = new User();
                        foreach (User user in Files.Users)
                        {
                            if (user.UserName==userlogin2[0] && user.Password == userlogin2[1])
                            {
                                userlogin = user;
                            }
                        }
                        Console1.SecondMessage(computer);
                        Console.WriteLine("(a) Ver todas las películas\n(b) Ver todas las canciones \n(c) Crear Playlist\n(d) Modificar Playlist (Cambiar nombre, Agregar/Quitar elementos)\n(e) Ver Mis Playlists\n(f) BUSCADOR\n(g) Cerrar Sesión (para volvera a inicio/creación de sesión o salir del programa)");
                        string option = Console.ReadLine();
                        if (option == "a")
                        {
                            Console1.SeeMovies(computer, userlogin);
                        }
                        else if (option == "b")
                        {
                            Console1.SeeSongs(computer, userlogin);
                        }
                        else if (option == "c")
                        {
                            Console1.CreatePlaylist(computer, userlogin);
                        }
                        else if (option == "d")
                        {
                            Console1.ModifiedPlaylist(computer, userlogin);
                        }
                        else if (option == "e")
                        {
                            Console1.SeePlaylist(computer, userlogin);
                        }
                        else if (option == "f")
                        {
                            Console1.Search(computer, userlogin);
                        }
                        else if (option == "g")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                        }                        
                    }
                }
                else if (desition == "b")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                }
            }

            WindowsMediaPlayer player = new WindowsMediaPlayer();
            Son_of_man.Play(player);
            Tarzan.Play(player);
            Console.Read();

            //Stream stream2 = new FileStream("BaseDeDatos.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream2, Files.AllMovies);
            //formatter.Serialize(stream2, Files.AllSongs);
            //formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            //formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            //formatter.Serialize(stream2, Files.Users);
            //stream2.Close();
        }
    }
}
