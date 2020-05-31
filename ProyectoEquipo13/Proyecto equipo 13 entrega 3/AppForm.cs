using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    public partial class AppForm : Form
    {
        public delegate bool LoginEventHandler(object source, LoginEventArgs args);
        public event LoginEventHandler LoginButtonClicked;
        public event EventHandler<LoginEventArgs> UserChecked;
        public delegate bool CreateAccountEventHandler(object source, RegisterEventArgs args);
        public event CreateAccountEventHandler CreateAccountClicked;
        public string ruta, dest, name;


        

        //Organizacion
        List<Panel> stackPanels = new List<Panel>();
        Dictionary<string, Panel> panels = new Dictionary<string, Panel>();

        public AppForm()
        {
            InitializeComponent();
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
            Artist phill_collins = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Phil_Collins");
            Album Tarzan_album = new Album("Tarzan: An Original Walt Disney Records Soundtrack", DateTime.Now, phill_collins, @"\Tarzan.jpg");
            List<string> Genre_Son_of_man = new List<string>();
            Genre_Son_of_man.Add("Pop Rock");
            Genre_Son_of_man.Add("Soft Rock");
            string Music_Son_of_man = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp3";
            Songs Son_of_man = new Songs("Son of man", phill_collins, phill_collins, phill_collins, LenghtS, Genre_Son_of_man, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Son_of_man, Type, MinS, Tarzan_album);
            Files.AllSongs.Add(Son_of_man);


            //SONG 2
            Artist celine_dion = new Artist("Celine Dion", new DateTime(1968, 3, 30, 5, 5, 5), F, "https://es.wikipedia.org/wiki/C%C3%A9line_Dion");
            Person james_horner = new Person("James Horner", new DateTime(1953, 8, 14, 5, 5, 5), M, "https://es.wikipedia.org/wiki/James_Horner");
            Album Titanic_album = new Album("Titanic: Music From The Motion Picture ", DateTime.Now, celine_dion, @"\Titanic.jpg");
            List<string> Genre_My_heart_will_go_on = new List<string>();
            Genre_My_heart_will_go_on.Add("Pop");
            Genre_My_heart_will_go_on.Add("Balada");
            string Music_My_heart_will_go_on = @"\Celine Dion - My heart will go on [Lyrics y Subtitulos en Español].mp3";
            Songs My_heart_will_go_on = new Songs("My heart will go on", james_horner, celine_dion, james_horner, LenghtS, Genre_My_heart_will_go_on, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_My_heart_will_go_on, Type, MinS, Titanic_album);
            Files.AllSongs.Add(My_heart_will_go_on);

            //SONG 3
            Album Face_value_album = new Album("Face Value", new DateTime(1981, 1, 5, 5, 5, 5), phill_collins, @"\Face Value.jpg");
            List<string> Genre_In_the_air_tonight = new List<string>();
            Genre_In_the_air_tonight.Add("Soft Rock");
            Genre_In_the_air_tonight.Add("Power Ballad");
            string Music_In_the_air_tonight = @"\Phil Collins - In The Air Tonight (Official Video).mp3";
            Songs In_the_air_tonight = new Songs("In the air tonight", phill_collins, phill_collins, phill_collins, LenghtS, Genre_In_the_air_tonight, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_In_the_air_tonight, Type, MinS, Face_value_album);
            Files.AllSongs.Add(In_the_air_tonight);

            //SONG 4
            List<string> Genre_This_must_be_love = new List<string>();
            Genre_This_must_be_love.Add("Pop Rock");
            Genre_This_must_be_love.Add("Art Rock");
            Genre_This_must_be_love.Add("R&B");
            string Music_This_must_be_love = @"\Phil Collins This Must Be Love.mp3";
            Songs This_must_be_love = new Songs("This must be love", phill_collins, phill_collins, phill_collins, LenghtS, Genre_This_must_be_love, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_This_must_be_love, Type, MinS, Face_value_album);
            Files.AllSongs.Add(This_must_be_love);

            //SONG 5
            Artist randy_newman = new Artist("Randy Newman", new DateTime(1943, 11, 28, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Randy_Newman");
            Album Toy_Story_album = new Album("Toy Story", new DateTime(1996, 4, 12, 5, 5, 5), randy_newman, @"\Toy Story.jpg");
            List<string> Genre_Youve_got_a_friend_in_me = new List<string>();
            string Music_Youve_got_a_friend_in_me = @"\Randy Newman - Youve Got a Friend in Me (From Toy Story 4Audio Only).mp3";
            Songs Youve_got_a_friend_in_me = new Songs("You've got a friend in me", randy_newman, randy_newman, randy_newman, LenghtS, Genre_Youve_got_a_friend_in_me, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Youve_got_a_friend_in_me, Type, MinS, Toy_Story_album);
            Files.AllSongs.Add(Youve_got_a_friend_in_me);

            //SONG 6
            Artist sia = new Artist("Sia", new DateTime(1943, 11, 28, 5, 5, 5), F, "https://es.wikipedia.org/wiki/Sia");
            Album Forms_album = new Album("1000 Forms of fear", new DateTime(2014, 3, 14, 5, 5, 5), sia, @"\Forms of Fear.jpg");
            List<string> Genre_Chandelier = new List<string>();
            Genre_Chandelier.Add("Pop");
            string Music_Chandelier = @"\Sia - Chandelier (Official Video).mp3";
            Songs Chandelier = new Songs("Chandelier", sia, sia, sia, LenghtS, Genre_Chandelier, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Chandelier, Type, MinS, Forms_album);
            Files.AllSongs.Add(Chandelier);

            //SONG 7
            List<string> Genre_Elastic_heart = new List<string>();
            Genre_Elastic_heart.Add("Electropop");
            string Music_Elastic_heart = @"\Sia - Elastic Heart (Traducida al Español).mp3";
            Songs Elastic_heart = new Songs("Elastic Heart", sia, sia, sia, LenghtS, Genre_Elastic_heart, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Elastic_heart, Type, MinS, Forms_album);
            Files.AllSongs.Add(Elastic_heart);

            //SONG 8
            Artist diplo = new Artist("Diplo", new DateTime(1978, 11, 10, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Diplo");
            Artist justin_bieber = new Artist("Justin Bieber", new DateTime(1994, 3, 1, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Justin_Bieber");
            Album My_world_album = new Album("My World 2.0", new DateTime(2010, 5, 5, 5, 5, 5), justin_bieber, @"\My World.jpg");
            List<string> Genre_Where_are_u_now = new List<string>();
            Genre_Where_are_u_now.Add("Pop");
            string Music_Where_are_u_now = @"\Skrillex and Diplo - Where Are Ü Now with Justin Bieber (Official Video).mp3";
            Songs Where_are_u_now = new Songs("Where are Ü now", diplo, justin_bieber, diplo, LenghtS, Genre_Where_are_u_now, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Where_are_u_now, Type, MinS, My_world_album);
            Files.AllSongs.Add(Where_are_u_now);

            //SONG 9
            Artist maroon_5 = new Artist("Maroon 5", new DateTime(1997, 1, 1, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Maroon_5");
            Artist adam_levine = new Artist("Adam Levine", new DateTime(1979, 3, 18, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Adam_Levine");
            Album V_album = new Album("V", new DateTime(2014, 9, 2, 5, 5, 5), maroon_5, @"\V.jpg");
            List<string> Genre_Sugar = new List<string>();
            Genre_Sugar.Add("Pop Rock");
            string Music_Sugar = @"\Maroon 5 - Sugar (lyrics).mp3";
            Songs Sugar = new Songs("Sugar", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Sugar, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Sugar, Type, MinS, V_album);
            Files.AllSongs.Add(Sugar);

            //SONG 10
            List<string> Genre_Maps = new List<string>();
            Genre_Maps.Add("Pop Rock");
            Genre_Maps.Add("Dance Pop");
            string Music_Maps = @"\Maroon 5 - Maps (Lyric).mp3";
            Songs Maps = new Songs("Maps", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Maps, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Maps, Type, MinS, V_album);
            Files.AllSongs.Add(Maps);
            
            //PELICULAS

            //GENERICOS
            int Lenght = 88;
            string Description = "descripcion";
            string Resolution = "617kbps";
            string Memory = "12,2MB";
            int numReproductions = 0;
            int Min = 0;

            //MOVIE 1
            Person kevin_lima = new Person("Kevin Lima", new DateTime(1962, 6, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0510674/?ref_=fn_al_nm_1");
            List<Person> Actors_Tarzan = new List<Person>();
            Person frank_welker = new Person("Frank Welker", new DateTime(1946, 3, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0919798/?ref_=fn_al_nm_1");
            Person danielle_keaton = new Person("Danielle Keaton", new DateTime(1986, 7, 30, 5, 5, 5), F, "https://www.imdb.com/name/nm0918210/?ref_=fn_al_nm_1");
            Actors_Tarzan.Add(frank_welker);
            Actors_Tarzan.Add(danielle_keaton);
            Person tab_murphay = new Person("Tab Murphy", new DateTime(1966, 2, 25, 5, 5, 5), F, "https://www.imdb.com/name/nm0614742/?ref_=nv_sr_srsg_0");
            List<string> Categories_Tarzan = new List<string>();
            Categories_Tarzan.Add("Animación musical");
            Categories_Tarzan.Add("Aventura");
            Categories_Tarzan.Add("Comedia");
            string Trailer_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            string Video_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            List<Songs> Songs_Tarzan = new List<Songs>();
            Songs_Tarzan.Add(Son_of_man);
            Movies Tarzan = new Movies("Tarzan", kevin_lima, Actors_Tarzan, tab_murphay, Lenght, Categories_Tarzan, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Tarzan, Video_Tarzan, Songs_Tarzan, Min, @"\Tarzanmovie.jpg");
            Files.AllMovies.Add(Tarzan);

            //MOVIE 2
            Person tom_hanks = new Person("Tom Hanks", new DateTime(1956, 7, 9, 5, 5, 5), M, "https://www.imdb.com/name/nm0000158/?ref_=fn_al_nm_1");
            Person josh_cooley = new Person("Josh Cooley", new DateTime(1950, 11, 23, 5, 5, 5), M, "https://www.imdb.com/name/nm2155757/?ref_=nv_sr_srsg_0");
            Person tim_allen = new Person("Tim Allen", new DateTime(1955, 9, 26, 5, 5, 5), M, "https://www.imdb.com/name/nm0000741/?ref_=fn_al_nm_1");
            Person annie_potts = new Person("Annie Potts", new DateTime(1976, 10, 3, 5, 5, 5), F, "https://www.imdb.com/name/nm0001633/?ref_=fn_al_nm_1");
            Person john_lasseter = new Person("John Lasseter", new DateTime(1957, 1, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0005124/?ref_=fn_al_nm_1");
            List<Person> Actors_Toy_story_4 = new List<Person>();
            Actors_Toy_story_4.Add(tom_hanks);
            Actors_Toy_story_4.Add(tim_allen);
            Actors_Toy_story_4.Add(annie_potts);
            List<string> Categories_Toy_story_4 = new List<string>();
            Categories_Toy_story_4.Add("Animación");
            Categories_Toy_story_4.Add("Aventura");
            Categories_Toy_story_4.Add("Comedia");
            string Video_Toy_story_4 = @"\Toy Story 4  Official Trailer.mp4";
            string Trailer_Toy_story_4 = @"\";
            List<Songs> Songs_Toy_story_4 = new List<Songs>();
            Songs_Toy_story_4.Add(Youve_got_a_friend_in_me);
            string b = @"\Toy Story 4.jpg";
            Movies Toy_story_4 = new Movies("Toy Story 4", josh_cooley, Actors_Toy_story_4, john_lasseter, Lenght, Categories_Toy_story_4, "Walt Disney Pictures", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_4, Video_Toy_story_4, Songs_Toy_story_4, Min, b);
            Files.AllMovies.Add(Toy_story_4);

            //MOVIE 3 
            Person lee_unkrich = new Person("Lee Unkrich", new DateTime(1967, 8, 8, 5, 5, 5), M, "https://www.imdb.com/name/nm0881279/?ref_=nv_sr_srsg_0");
            Person darla_anderson = new Person("Darla Anderson", new DateTime(1970, 8, 22, 5, 5, 5), F, "https://www.imdb.com/name/nm0026565/?ref_=fn_al_nm_1");
            List<Person> Actors_Toy_story_3 = new List<Person>();
            Actors_Toy_story_3.Add(tom_hanks);
            Actors_Toy_story_3.Add(tim_allen);
            List<string> Categories_Toy_story_3 = new List<string>();
            Categories_Toy_story_3.Add("Animación");
            Categories_Toy_story_3.Add("Aventura");
            Categories_Toy_story_3.Add("Comedia");
            string Video_Toy_story_3 = @"\Toy Story 3 Trailer.mp4";
            string Trailer_Toy_story_3 = @"\";
            List<Songs> Songs_Toy_story_3 = new List<Songs>();
            Songs_Toy_story_3.Add(Youve_got_a_friend_in_me);
            Movies Toy_story_3 = new Movies("Toy Story 3", lee_unkrich, Actors_Toy_story_3, darla_anderson, Lenght, Categories_Toy_story_3, "Walt Disney Pictures", Description, "2010", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_3, Video_Toy_story_3, Songs_Toy_story_3, Min, @"\Toy Story 3.jpg");
            Files.AllMovies.Add(Toy_story_3);

            //MOVIE 4
            Person james_cameron = new Person("James Cameron", new DateTime(1954, 8, 16, 5, 5, 5), M, "https://www.imdb.com/name/nm0000116/?ref_=fn_al_nm_1");
            Person leonardo_dicaprio = new Person("Leonardo DiCaprio", new DateTime(1974, 11, 11, 5, 5, 5), M, "https://www.imdb.com/name/nm0000138/?ref_=fn_al_nm_1");
            Person kate_winslet = new Person("Kate Winslet", new DateTime(1975, 10, 5, 5, 5, 5), F, "https://www.imdb.com/name/nm0000701/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Titanic = new List<Person>();
            Actors_Titanic.Add(leonardo_dicaprio);
            Actors_Titanic.Add(kate_winslet);
            List<string> Categories_Titanic = new List<string>();
            Categories_Titanic.Add("Romance");
            Categories_Titanic.Add("Catastrofe");
            Categories_Titanic.Add("Drama");
            string Video_Titanic = @"\Titanic 3D Re-Release Official Trailer 1 - Leonardo DiCaprio, Kate Winslet Movie (2012) HD.mp4";
            string Trailer_Titanic = @"\";
            List<Songs> Songs_Titanic = new List<Songs>();
            Songs_Titanic.Add(My_heart_will_go_on);
            Movies Titanic = new Movies("Titanic", james_cameron, Actors_Titanic, james_cameron, Lenght, Categories_Titanic, "20th Century Fox", Description, "1997", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Titanic, Video_Titanic, Songs_Titanic, Min, @"\Titanicmovie.jpg");
            Files.AllMovies.Add(Titanic);

            //MOVIE 5
            Person andrew_stanton = new Person("Andrew Stanton", new DateTime(1965, 12, 3, 5, 5, 5), M, "https://www.imdb.com/name/nm0004056/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Toy_story_2 = new List<Person>();
            Actors_Toy_story_2.Add(tom_hanks);
            Actors_Toy_story_2.Add(tim_allen);
            List<string> Categories_Toy_story_2 = new List<string>();
            Categories_Toy_story_2.Add("Animación");
            Categories_Toy_story_2.Add("Aventura");
            Categories_Toy_story_2.Add("Comedia");
            string Video_Toy_story_2 = @"\Toy Story 2 (1999) Trailer 1  Movieclips Classic Trailers.mp4";
            string Trailer_Toy_story_2 = @"\";
            List<Songs> Songs_Toy_story_2 = new List<Songs>();
            Songs_Toy_story_2.Add(Youve_got_a_friend_in_me);
            Movies Toy_story_2 = new Movies("Toy Story 2", john_lasseter, Actors_Toy_story_2, andrew_stanton, Lenght, Categories_Toy_story_2, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_2, Video_Toy_story_2, Songs_Toy_story_2, Min, @"\Toy Story 2.jpg");
            Files.AllMovies.Add(Toy_story_2);

            //MOVIE 6
            List<Person> Actors_Toy_story = new List<Person>();
            Actors_Toy_story.Add(tom_hanks);
            Actors_Toy_story.Add(tim_allen);
            List<string> Categories_Toy_story = new List<string>();
            Categories_Toy_story.Add("Animación");
            Categories_Toy_story.Add("Aventura");
            Categories_Toy_story.Add("Comedia");
            string Video_Toy_story = @"\Toy Story 1 HD Trailer.mp4";
            string Trailer_Toy_story = @"\";
            List<Songs> Songs_Toy_story = new List<Songs>();
            Songs_Toy_story.Add(Youve_got_a_friend_in_me);
            Movies Toy_story = new Movies("Toy Story", john_lasseter, Actors_Toy_story, andrew_stanton, Lenght, Categories_Toy_story, "Pixar", Description, "1995", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story, Video_Toy_story, Songs_Toy_story, Min, @"\Toy Storymovie.jpg");
            Files.AllMovies.Add(Toy_story);

            //MOVIE 7
            Person martin_scorsese = new Person("Martin Scorsese", new DateTime(1942, 11, 17, 5, 5, 5), M, "https://www.imdb.com/name/nm0000217/?ref_=nv_sr_srsg_0");
            Person terence_winter = new Person("Terence Winter", new DateTime(1960, 10, 2, 5, 5, 5), M, "https://www.imdb.com/name/nm1010540/?ref_=nv_sr_srsg_0");
            Person margot_robbie = new Person("Margot Robbie", new DateTime(1990, 7, 2, 5, 5, 5), F, "https://www.imdb.com/name/nm3053338/?ref_=fn_al_nm_1");
            Person matthew_mcconaughey = new Person("Matthew McConaughey", new DateTime(1969, 11, 4, 5, 5, 5), M, "https://www.imdb.com/name/nm0000190/?ref_=nv_sr_srsg_0");
            List<Person> Actors_The_wolf_of_wall_street = new List<Person>();
            Actors_The_wolf_of_wall_street.Add(leonardo_dicaprio);
            Actors_The_wolf_of_wall_street.Add(margot_robbie);
            Actors_The_wolf_of_wall_street.Add(matthew_mcconaughey);
            List<string> Categories_The_wolf_of_wall_street = new List<string>();
            Categories_The_wolf_of_wall_street.Add("Biografía");
            Categories_The_wolf_of_wall_street.Add("Comedia");
            string Video_The_wolf_of_wall_street = @"\The Wolf of Wall Street Official Trailer.mp4";
            string Trailer_The_wolf_of_wall_street = @"\";
            List<Songs> Songs_The_wolf_of_wall_street = new List<Songs>();
            Movies The_wolf_of_wall_street = new Movies("The Wolf of Wall street", martin_scorsese, Actors_The_wolf_of_wall_street, terence_winter, Lenght, Categories_The_wolf_of_wall_street, "Paramount Pictures", Description, "2013", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_wolf_of_wall_street, Video_The_wolf_of_wall_street, Songs_The_wolf_of_wall_street, Min, @"\The Wolf of Wall Street.jpg");
            Files.AllMovies.Add(The_wolf_of_wall_street);

            //MOVIE 8
            Person christopher_nolan = new Person("Christopher Nolan", new DateTime(1970, 7, 30, 5, 5, 5), M, "https://www.imdb.com/name/nm0634240/?ref_=nv_sr_srsg_0");
            Person anne_hathaway = new Person("Anne Hathaway", new DateTime(1982, 11, 12, 5, 5, 5), F, "https://www.imdb.com/name/nm0004266/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Interestellar = new List<Person>();
            Actors_Interestellar.Add(anne_hathaway);
            Actors_Interestellar.Add(matthew_mcconaughey);
            List<string> Categories_Interestellar = new List<string>();
            Categories_Interestellar.Add("Ciencia Ficción");
            string Video_Interestellar = @"\Interstellar - Trailer - Official Warner Bros. UK.mp4";
            string Trailer_Interestellar = @"\";
            List<Songs> Songs_Interestellar = new List<Songs>();
            Movies Interestellar = new Movies("Interestellar", christopher_nolan, Actors_Interestellar, christopher_nolan, Lenght, Categories_Interestellar, "Paramount Pictures", Description, "2014", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Interestellar, Video_Interestellar, Songs_Interestellar, Min, @"\Interestellar.jpg");
            Files.AllMovies.Add(Interestellar);

            //MOVIE 9
            Person steven_rogers = new Person("Steven Rogers", new DateTime(1953, 4, 3, 5, 5, 5), M, "https://www.imdb.com/name/nm0737216/?ref_=fn_al_nm_1");
            Person allison_janney = new Person("Allison Janney", new DateTime(1959, 11, 19, 5, 5, 5), F, "https://www.imdb.com/name/nm0005049/?ref_=nv_sr_srsg_0");
            List<Person> Actors_I_tonya = new List<Person>();
            Actors_I_tonya.Add(margot_robbie);
            Actors_I_tonya.Add(allison_janney);
            List<string> Categories_I_tonya = new List<string>();
            Categories_I_tonya.Add("Drama");
            Categories_I_tonya.Add("Bibliográfica");
            string Video_I_tonya = @"\I, Tonya Trailer #1 (2017) _ Movieclips Trailers.mp4";
            string Trailer_I_tonya = @"\";
            List<Songs> Songs_I_tonya = new List<Songs>();
            Movies I_tonya = new Movies("I, Tonya", margot_robbie, Actors_I_tonya, steven_rogers, Lenght, Categories_I_tonya, "LuckyChap", Description, "2017", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_I_tonya, Video_I_tonya, Songs_I_tonya, Min, @"\I, Tonya.jpg");
            Files.AllMovies.Add(I_tonya);

            //MOVIE 10
            Person robert_deniro = new Person("Robert De Niro", new DateTime(1943, 8, 17, 5, 5, 5), M, "https://www.imdb.com/name/nm0000134/?ref_=nv_sr_srsg_0");
            Person al_pacino = new Person("Al Pacino", new DateTime(1940, 4, 25, 5, 5, 5), M, "https://www.imdb.com/name/nm0000199/?ref_=nv_sr_srsg_0");
            Person joe_pesci = new Person("Joe Pesci", new DateTime(1943, 2, 9, 5, 5, 5), M, "https://www.imdb.com/name/nm0000582/?ref_=fn_al_nm_1");
            Person steven_zaillian = new Person("Steven Zaillian", new DateTime(1953, 1, 30, 5, 5, 5), M, "https://www.imdb.com/name/nm0001873/?ref_=nv_sr_srsg_0");
            List<Person> Actors_The_irishman = new List<Person>();
            Actors_The_irishman.Add(robert_deniro);
            Actors_The_irishman.Add(al_pacino);
            Actors_The_irishman.Add(joe_pesci);
            List<string> Categories_The_irishman = new List<string>();
            Categories_The_irishman.Add("Drama");
            Categories_The_irishman.Add("Bibliográfica");
            string Video_The_irishman = @"\The Irishman  Official Trailer  Netflix.mp4";
            string Trailer_The_irishman = @"\";
            List<Songs> Songs_The_irishman = new List<Songs>();
            Movies The_irishman = new Movies("The Irishman", martin_scorsese, Actors_The_irishman, steven_zaillian, Lenght, Categories_The_irishman, "TriBeCa", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_irishman, Video_The_irishman, Songs_The_irishman, Min, @"\The Irishman.jpg");
            Files.AllMovies.Add(The_irishman);

            this.WindowState = FormWindowState.Maximized;
            IniciarSerializacion();
            panels.Add("WelcomePanel", WelcomeMenu);
            panels.Add("LoginPanel", LoginView);
            panels.Add("UserPanel", UserPanel);
            panels.Add("CreateAccountPanel", CreateAccountView);
            panels.Add("ModificarCuentaPanel", ModificarCuentaPanel);
            panels.Add("ReproductionPanel", ReproductionPanel);
            foreach (User user in Files.Users)
            {
                if (user.LOGIN == true)
                {
                    stackPanels.Add(panels["UserPanel"]);
                    setNameUser(user.UserName);
                    ShowLastPanel();
                }
            }
            if (stackPanels.Count()==0)
            {
                stackPanels.Add(panels["WelcomePanel"]);
                ShowLastPanel();
            }
        }


        private void IniciarSerializacion()
        {
            User Admin = new User("Premium", "Admin", "email", "", true);
            Files.Users.Add(Admin);
            foreach (User i in Files.Users)
            {
                List<string> data = new List<string>()
                        { i.UserName, i.Email, i.Password, Convert.ToString(DateTime.Now), i.Type};
                Files.AllUsers.Add(Files.AllUsers.Count + 1, data);
            }

            IFormatter formatter = new BinaryFormatter();

            string urlAllMovies = Directory.GetCurrentDirectory() + "\\AllMovies.bin";
            string urlAllSongs = Directory.GetCurrentDirectory() + "\\AllSongs.bin";
            string urlAllPlaylistsSongs = Directory.GetCurrentDirectory() + "\\AllPlaylistsSongs.bin";
            string urlAllPlaylistsMovies = Directory.GetCurrentDirectory() + "\\AllPlaylistsMovies.bin";
            string urlUsers = Directory.GetCurrentDirectory() + "\\Users.bin";
            string urlAllPersons = Directory.GetCurrentDirectory() + "\\AllPersons.bin";

            if (File.Exists(urlAllMovies) && File.Exists(urlAllSongs) && File.Exists(urlAllPlaylistsSongs) && File.Exists(urlAllPlaylistsMovies) && File.Exists(urlUsers))
            {
                Stream stream1 = new FileStream("AllMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream2 = new FileStream("AllSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream3 = new FileStream("AllPlaylistsSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream4 = new FileStream("AllPlaylistsMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream5 = new FileStream("Users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream6 = new FileStream("AllPersons.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                //try que Desterializa; catch mostrar mensaje; finally cierra archivo
                try
                {
                    List<Movies> des = (List<Movies>)formatter.Deserialize(stream1);
                    if (des.Count != 0)
                    {
                        Files.AllMovies = des;
                    }
                }
                catch
                {
                }
                try
                {
                    List<Songs> des2 = (List<Songs>)formatter.Deserialize(stream2);
                    if (des2.Count != 0)
                    {
                        Files.AllSongs.Clear();
                        Files.AllSongs = des2;
                    }
                }
                catch
                {
                }
                try
                {
                    Files.AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream3);
                }
                catch
                {
                }
                try
                {
                    Files.AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream4);
                }
                catch
                {
                }
                try
                {
                    Files.Users = (List<User>)formatter.Deserialize(stream5);
                    foreach (User i in Files.Users)
                    {
                        List<string> data = new List<string>()
                        { i.UserName, i.Email, i.Password, Convert.ToString(DateTime.Now), i.Type};
                        Files.AllUsers.Add(Files.AllUsers.Count + 1, data);
                    }
                }
                catch
                {
                }
                try
                {
                    Files.AllPersons = (List<Person>)formatter.Deserialize(stream6);
                }
                catch
                {
                }
                finally
                {
                    stream1.Close();
                    stream2.Close();
                    stream3.Close();
                    stream4.Close();
                    stream5.Close();
                    stream6.Close();
                }
            }
        }

        private void Serializacion()
        {
            IFormatter formatter = new BinaryFormatter();

            Stream stream7 = new FileStream("AllMovies.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream8 = new FileStream("AllSongs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream9 = new FileStream("AllPlaylistsSongs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream10 = new FileStream("AllPlaylistsMovies.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream11 = new FileStream("Users.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream12 = new FileStream("AllPersons.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream7, Files.AllMovies);
            formatter.Serialize(stream8, Files.AllSongs);
            formatter.Serialize(stream9, Files.AllPlaylistsSongs);
            formatter.Serialize(stream10, Files.AllPlaylistsMovies);
            formatter.Serialize(stream11, Files.Users);
            formatter.Serialize(stream12, Files.AllPersons);
            stream7.Close();
            stream8.Close();
            stream9.Close();
            stream10.Close();
            stream11.Close();
            stream12.Close();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {

        }

        private void IniciarSesión_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["LoginPanel"]);
            ShowLastPanel();            
        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            InputPrivacidadCreateAccountView.SelectedIndex = -1;
            InputTipoUsuarioCreateAccountView.SelectedIndex = -1;
            InputPasswordCreateAccountView.ResetText();
            InputEmailCreateAccountView.ResetText();
            InputUserNameCreateAccountView.ResetText();
            stackPanels.Add(panels["CreateAccountPanel"]);
            ShowLastPanel();
        }

        private void WelcomeMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowLastPanel()
        {
            foreach (Panel panel in panels.Values)
            {
                if (panel != stackPanels.Last())
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Dock = DockStyle.Fill;
                    panel.Visible = true;
                }
            }
        }

        public void setNameUser(string username)
        {
            ReadUserName.Text = username;
        }

        private void OnUserChecked(string username)
        {
            if (UserChecked != null)
            {
                UserChecked(this, new LoginEventArgs() { UsernameText = username });
                InputUsuarioLoginView.ResetText();
                InputContraseñaLoginView.ResetText();
                setNameUser(username);
                foreach (User user in Files.Users)
                {
                    if (user.UserName == username)
                    {
                        user.LOGIN = true;
                        Serializacion();
                    }
                }
                stackPanels.Add(panels["UserPanel"]);
                ShowLastPanel();
            }
        }

        private void UserPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginButtonLoginView_Click(object sender, EventArgs e)
        {
            string username = InputUsuarioLoginView.Text;
            string pass = InputContraseñaLoginView.Text;
            OnLoginButtonClicked(username, pass);
        }

        private void OnLoginButtonClicked(string username, string pass)
        {
            bool result = LoginButtonClicked(this, new LoginEventArgs() { UsernameText = username, PasswordText = pass });
            if (!result)
            {
                loginViewInvalidCredentialsAlert.Text = "Credenciales inválidas";
                loginViewInvalidCredentialsAlert.Visible = true;
            }
            else
            {
                loginViewInvalidCredentialsAlert.ResetText();
                loginViewInvalidCredentialsAlert.Visible = false;
                foreach (User user in Files.Users)
                {
                    if (user.UserName == username)
                    {
                        user.LOGIN = true;
                        Serializacion();
                    }
                }
                OnUserChecked(username);
            }
        }

        private void CreateAccountView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string username = InputUserNameCreateAccountView.Text;
            string email = InputEmailCreateAccountView.Text;
            string pass = InputPasswordCreateAccountView.Text;
            string type = InputTipoUsuarioCreateAccountView.Text;
            string privacy = InputPrivacidadCreateAccountView.Text;
            OnCreateAccountClicked(username, email, pass,type, privacy);
        }

        private void OnCreateAccountClicked(string username, string email, string pass, string type, string privacy)
        {
            if ((type =="") || (type=="Premium" && privacy == "") || (username=="") || pass=="" || email =="")
            {
                CheckRegistration.Text = "Agregue los valores que faltan";
                CheckRegistration.Visible = true;
            }
            else
            {
                string typeprivacy = null;
                if (type == "Premium")
                {
                    if (privacy == "Público")
                    {
                        typeprivacy = "PremiumT";
                    }
                    else
                    {
                        typeprivacy = "PremiumF";
                    }
                }
                else if (type == "Free")
                {
                    typeprivacy = "Free";
                }
                bool result = CreateAccountClicked(this, new RegisterEventArgs() { Username = username, Password = pass, Email = email, TypePrivacy= typeprivacy });
                if (!result)
                {
                    CheckRegistration.Text = "Usuario y/o email ya existen";
                    CheckRegistration.Visible = true;
                }
                else
                {
                    CheckRegistration.ResetText();
                    CheckRegistration.Visible = false;
                    Serializacion();
                    OnUserChecked(username);
                }
            }
        }

        private void CerrarSesiónButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            foreach (User user in Files.Users)
            {
                if (user.LOGIN==true)
                {
                    user.LOGIN = false;
                }
            }
            Serializacion();
            setNameUser("");
            ShowLastPanel();
        }

        private void ModificarCuentaButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["ModificarCuentaPanel"]);
            ShowLastPanel();
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
        }

        private void BackToUserMenuButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["UserPanel"]);
            ShowLastPanel();
        }

        private void AceptarCambioNombreUsuarioButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string newUser = NuevoNombreUsuarioTextBox.Text;
            List<string> UserValues = Files.GetData(oldUser);
            UserValues[0] = newUser;
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    usuario.UserName = newUser;
                }
            }
            ReadUserName.Text = newUser;
            ChangeUserPanel.Visible = false;
            ModCorrPanel.Visible = true;
            Serializacion();
        }

        private void CambiarUsuarioButton_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            NuevoNombreUsuarioTextBox.ResetText();
            ChangeUserPanel.Visible = true;
        }

        private void CambiarContraseñaButton_Click(object sender, EventArgs e)
        {
            ChangeUserPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            CheckOldPassword.ResetText();
            InputNewPassword.ResetText();
            InputOldPassword.ResetText();
            ChangePasswordPanel.Visible = true;
        }

        private void AceptarNuevaContraseñaButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string oldPass = InputOldPassword.Text;
            string newPass = InputNewPassword.Text;
            List<string> UserValues = Files.GetData(oldUser);
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    if (oldPass == usuario.Password)
                    {
                        usuario.Password = newPass;
                        UserValues[2] = newPass;
                        ChangePasswordPanel.Visible = false;
                        ModCorrPanel.Visible = true;
                    }
                    else
                    {
                        CheckOldPassword.Text = "Contraseña Actual Incorrecta";
                    }
                    Serializacion();
                }
            }
        }

        private void ChangeFreePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AceptarCambioCuentaButton_Click(object sender, EventArgs e)
        {
            if (PrivacidadFreeNuevaComboBox.Text == "")
            {
                CheckPrivacyInformation.Text = "Seleccione Privacidad";
            }
            else
            {
                string oldUser = ReadUserName.Text;
                string privacy = PrivacidadFreeNuevaComboBox.Text;
                List<string> UserValues = Files.GetData(oldUser);
                foreach (User usuario in Files.Users)
                {
                    if (usuario.UserName == oldUser)
                    {
                       if (privacy == "Público")
                       {
                            UserValues[4] = "PremiumT";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = true;
                            ChangeFreePanel.Visible = false;
                       }
                       else if (privacy == "Privado")
                       {
                            UserValues[4] = "PremiumF";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = false;
                            ChangeFreePanel.Visible = false;
                       }
                       Serializacion();
                       ModCorrPanel.Visible = true;
                    }
                }
            }
        }

        private void CambioTipoCuentaButton_Click(object sender, EventArgs e)
        {
            YaEsPremiumPanel.Visible = false;
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ModCorrPanel.Visible = false;
            PrivacidadFreeNuevaComboBox.SelectedIndex = -1;
            CheckPrivacyInformation.ResetText();
            string oldUser = ReadUserName.Text;
            List<string> UserValues = Files.GetData(oldUser);
            if (UserValues[4].Contains("Premium"))
            {
                YaEsPremiumPanel.Visible = true;
            }
            else
            { 
                ChangeFreePanel.Visible = true;
            }
        }

        private void VolverButtonLoginView_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            InputContraseñaLoginView.ResetText();
            InputUsuarioLoginView.ResetText();
            loginViewInvalidCredentialsAlert.ResetText();
            ShowLastPanel();
        }

        private void FemeninoSexoBuscadorPanel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MasculinoSexoBuscadorPanel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void VolverRegisterPanel_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            InputPrivacidadCreateAccountView.SelectedIndex = -1;
            InputPasswordCreateAccountView.ResetText();
            InputEmailCreateAccountView.ResetText();
            InputUserNameCreateAccountView.ResetText();
            InputTipoUsuarioCreateAccountView.SelectedIndex = -1;
            CheckRegistration.ResetText();
            ShowLastPanel();
        }

        private void FillDataGridViewSongS(List<Songs> songs)
        {
            DataGriedSongS.Rows.Clear();
            DataGriedSongS.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Canción";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            DataGriedSongS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGriedSongS.RowTemplate.Height = 200;
            DataGriedSongS.AllowUserToAddRows = false;

            DataGriedSongS.Columns.Add(dgvImagen);
            DataGriedSongS.Columns.Add(nombre);
            DataGriedSongS.Columns.Add(buttons);

            DataGriedSongS.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGriedSongS.Columns[0].Width = 200;
            DataGriedSongS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Songs song in songs)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var D = carpeta + song.Album1.Image1;
                DataGriedSongS.Rows.Add(new object[] { System.Drawing.Image.FromFile(D), "Título: " + song.Title1 + "\r\nCantante: " + song.Artist1.Name + "\r\nDuración: " + song.Lenght1.ToString() + " min. \r\nRating: " + song.RatingProm1.ToString() });
            }
            ShowSongsPanel.Controls.Add(DataGriedSongS);
        }

        private void VerTodasLasCancionesButton_Click(object sender, EventArgs e)
        {
            ShowSongsPanel.Visible = true;
            ShowSongsPanel.BringToFront();
            FillDataGridViewSongS(Files.AllSongs);
        }

        private void FillDataGridViewMovieS(List<Movies> movies)
        {
            DataGriedMovieS.Rows.Clear();
            DataGriedMovieS.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Película";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            DataGriedMovieS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGriedMovieS.RowTemplate.Height = 200;
            DataGriedMovieS.AllowUserToAddRows = false;

            DataGriedMovieS.Columns.Add(dgvImagen);
            DataGriedMovieS.Columns.Add(nombre);
            DataGriedMovieS.Columns.Add(buttons);


            DataGriedMovieS.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGriedMovieS.Columns[0].Width = 200;
            DataGriedMovieS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Movies movie in movies)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var H = carpeta + movie.MovieDirection;
                DataGriedMovieS.Rows.Add(new object[] { System.Drawing.Image.FromFile(H), "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() });
            }
            ShowMoviesPanel.Controls.Add(DataGriedMovieS);
        }


        private void VerTodasLasPeliculasButton_Click(object sender, EventArgs e)
        {
            ShowMoviesPanel.Visible = true;
            ShowMoviesPanel.BringToFront();
            FillDataGridViewMovieS(Files.AllMovies);
        }

        private void DataGriedMovieS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string datosTO = DataGriedMovieS.Rows[DataGriedMovieS.CurrentRow.Index].Cells[1].Value.ToString();
            string datosT = datosTO.Replace("Título: ", string.Empty);
            string datos = datosT.Replace("Director: ", string.Empty);
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show("Reproduciendo: " + lines[0] + " del director " + lines[1]);
                InfoMovieTextBox.Text = null;
                foreach (Movies movie in Files.AllMovies)
                {
                    if (movie.Title1==lines[0] && movie.Director1.Name == lines[1])
                    {
                        InfoMovieTextBox.Text = "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nReparto: ";
                        foreach(Person person in movie.Actors1)
                        {
                            InfoMovieTextBox.Text += person.Name + ", ";
                        }
                        InfoMovieTextBox.Text = InfoMovieTextBox.Text.Substring(0, InfoMovieTextBox.Text.Length - 2);
                        InfoMovieTextBox.Text += "\r\nEscritor: " + movie.Writer1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString()+ "\r\nNúmero de Reproducciones: "+movie.NumReproductions.ToString()+"\r\nCategorías: ";
                        foreach (string cat in movie.Categories1)
                        {
                            InfoMovieTextBox.Text += cat + ", ";
                        }
                        InfoMovieTextBox.Text = InfoMovieTextBox.Text.Substring(0, InfoMovieTextBox.Text.Length - 2);
                        InfoMovieTextBox.Text += "\r\nEstudio: " + movie.Studio1 + "\r\nAño: " + movie.Year1;
                        var carpeta = Directory.GetCurrentDirectory();
                        var H = carpeta + movie.MovieDirection;
                        ShowImagenShowMovie.BackgroundImageLayout = ImageLayout.Stretch;
                        ShowImagenShowMovie.BackgroundImage = Image.FromFile(H);
                    }             
                }
                ShowMovie.BringToFront();
            }
        }

        private void DataGriedSongS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string datosTO = DataGriedSongS.Rows[DataGriedSongS.CurrentRow.Index].Cells[1].Value.ToString();
            string datosT = datosTO.Replace("Título: ", string.Empty);
            string datos = datosT.Replace("Cantante: ", string.Empty);
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show("Reproduciendo: " + lines[0] + " de " + lines[1]);
                InfoSongsTextBox.Text = null;
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Title1 == lines[0] && song.Artist1.Name == lines[1])
                    {
                        InfoSongsTextBox.Text = "Título: " + song.Title1 + "\r\nArtista: " + song.Artist1.Name + "\r\nÁlbum: " +song.Album1.Name1+ "\r\nGéneros: ";
                        foreach (string gen in song.Genre1)
                        {
                            InfoSongsTextBox.Text += gen + ", ";
                        }
                        InfoSongsTextBox.Text = InfoSongsTextBox.Text.Substring(0, InfoSongsTextBox.Text.Length - 2);
                        InfoSongsTextBox.Text += "\r\nCompositor: " + song.Composer1.Name + "\r\nEscritor: " + song.Writer1.Name + "\r\nDuración: " +song.Lenght1.ToString()+"\r\nRating: "+song.RatingProm1.ToString()+"\r\nNúmero de Reproducciones: "+song.NumReproductions.ToString();
                        var carpeta = Directory.GetCurrentDirectory();
                        var H = carpeta + song.Album1.Image1;
                        ShowImageShowSong.BackgroundImageLayout = ImageLayout.Stretch;
                        ShowImageShowSong.BackgroundImage = Image.FromFile(H);
                    }
                }
                ShowSong.BringToFront();
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        public void SacarRuta(string s)
        {
            string carpeta = Directory.GetCurrentDirectory();
            foreach (Movies j in Files.AllMovies)
            {
                if (s == j.Title1)
                {
                    this.ruta = carpeta + j.Video1;
                    this.name = j.Title1;
                }
            }
            foreach (Songs j in Files.AllSongs)
            {
                if (s == j.Title1)
                {
                    this.ruta = carpeta + j.Music1;
                    this.name = j.Title1;
                }
            }
        }

        public void ChooseFolder()
        { 
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.dest = folderBrowserDialog1.SelectedPath;
                try
                {
                    Copy();
                }
                catch(Exception EX) 
                { 
                }
            }
        }
        public void Copy()
        {
            string destFileName = (this.name) + " (Spotflix)" + ".mp3";
            var destFile = System.IO.Path.Combine(dest, destFileName);
            System.IO.File.Copy(ruta, destFile, true);
        }
        
    }
}
