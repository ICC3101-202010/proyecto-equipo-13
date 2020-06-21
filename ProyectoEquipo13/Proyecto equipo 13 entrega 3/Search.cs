using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    static class Search
    {
        public static List<Movies> SearchingMovies(string titulo1, string titulo2, string artist1, string artist2, string cat1, string cat2, int numrep1, int numrep2, double rating1, double rating2, string año1, string año2)
        {
            List<Movies> movies1 = QueryTitle(Files.AllMovies, titulo1, titulo2);
            List<Movies> movies2 = QueryPerson(movies1, artist1, artist2);
            List<Movies> movies3 = QueryCategories(movies2, cat1, cat2);
            List<Movies> movies4 = QueryNumRep(movies3, numrep1, numrep2);
            List<Movies> movies5 = QueryRating(movies4, rating1, rating2);
            List<Movies> movies6 = QueryYear(movies5, año1, año2);
            List<Movies> Final = ((from s in movies6 select s).Distinct()).ToList();
            return Final;
        }
        public static List<Songs> SearchingSongs(string titulo1, string titulo2, string artist1, string artist2, string cat1, string cat2, int numrep1, int numrep2, double rating1, double rating2, string album1, string album2)
        {
            List<Songs> songs1 = QueryTitleS(Files.AllSongs, titulo1, titulo2);
            List<Songs> songs2 = QueryPersonsS(songs1, artist1, artist2);
            List<Songs> songs3 = QueryGenreS(songs2, cat1, cat2);
            List<Songs> songs4 = QueryNumRepS(songs3, numrep1, numrep2);
            List<Songs> songs5 = QueryRatingS(songs4, rating1, rating2);
            List<Songs> songs6 = QueryAlbumS(songs5, album1, album2);
            List<Songs> Final = ((from s in songs6 select s).Distinct()).ToList();
            return Final;
        }
        public static (List<Person>, List<User> ) SearchingPerson(string titulo1, string titulo2, string artist1, string artist2, bool masc, bool fem, int edad1, int edad2)
        {
            List<Person> persons1 = QueryName(Files.AllPersons, titulo1, titulo2);
            List<Person> persons2 = QueryName(persons1, artist1, artist2);
            List<Person> persons3 = QuerySexo(persons2, masc, fem);
            List<Person> persons4 = QueryEdad(persons3, edad1, edad2);
            List<User> users = new List<User>();
            foreach (User user in Files.Users)
            {
                if (titulo1==user.UserName || titulo2==user.UserName ||artist1==user.UserName || artist2 == user.UserName)
                {
                    users.Add(user);
                }
            }
            if (users.Count == 0 && (titulo1 == "" && titulo2 == ""))
            {
                users = Files.Users;
            }
            List<Person> Final = ((from s in persons4 select s).Distinct()).ToList();
            return (Final,users);
        }

        public static List<Movies> SmartSearchingMovies(string S) //Titulo, artist, categoria, NumRep, Rating, Año
        {
            List<List<Movies>> listaM = new List<List<Movies>>(); 
            string[] stringSeparators = new string[] { " | " };
            string[] ors = S.Split(stringSeparators, StringSplitOptions.None);
            int contador = 0;
            foreach(string s in ors)
            {
                List<Movies> Mov = new List<Movies>();
                Mov = Files.AllMovies;
                string[] stringSeparators2 = new string[] { " & " };
                string[] ands = s.Split(stringSeparators2, StringSplitOptions.None);
                foreach(string s2 in ands)
                {
                    if(s2.ToUpper().Contains("TITULO:"))
                    {
                        string datos = null;
                        try
                        {
                             datos = s2.ToUpper().Replace("TITULO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryTitle(Mov, datos, "");

                    }
                    else if (s2.ToUpper().Contains("TÍTULO:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("TÍTULO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryTitle(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("ACTOR: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ACTOR: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryPerson(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("CATEGORIA: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("CATEGORIA: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryCategories(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("CATEGORÍA: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("CATEGORÍA: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryCategories(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("AÑO: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("AÑO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryYear(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("RATING: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("RATING: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryRating(Mov, Convert.ToDouble(datos),-1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("NUMERO DE REPRODUCCIONES: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NUMERO DE REPRODUCCIONES: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryNumRep(Mov, Convert.ToInt32(datos), -1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("NÚMERO DE REPRODUCCIONES: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NÚMERO DE REPRODUCCIONES: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryNumRep(Mov, Convert.ToInt32(datos), -1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                }
                if (contador!=0 && !Mov.Equals(Files.AllMovies))
                    listaM.Add(Mov);
            }
            List<Movies> moviesfinal = new List<Movies>();
            foreach(List<Movies> list in listaM)
            {
                foreach(Movies m in list)
                {
                    int cont = 0;
                    foreach (Movies movie in moviesfinal)
                    {
                        if (movie.Title1 == m.Title1)
                        {
                            cont += 1;
                        }
                    }
                    if (cont == 0)
                        moviesfinal.Add(m);
                }
            }
            return moviesfinal;
        }

        public static List<Songs> SmartSearchingSongs(string S) // Titulo, artist, genero, NumRep, Rating, Album 
        {
            List<List<Songs>> listaM = new List<List<Songs>>();
            string[] stringSeparators = new string[] { " | " };
            string[] ors = S.Split(stringSeparators, StringSplitOptions.None);
            int contador = 0;
            foreach (string s in ors)
            {
                List<Songs> Mov = new List<Songs>();
                Mov = Files.AllSongs;
                string[] stringSeparators2 = new string[] { " & " };
                string[] ands = s.Split(stringSeparators2, StringSplitOptions.None);
                foreach (string s2 in ands)
                {
                    if (s2.ToUpper().Contains("TITULO:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("TITULO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryTitleS(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("TÍTULO:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("TÍTULO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryTitleS(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("ARTISTA: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ARTISTA: ", string.Empty);
                        }
                        catch
                        {

                        }
                        Mov = QueryPersonsS(Mov, datos, "");
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("GENERO: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("GENERO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryGenreS(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("GÉNERO: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("GÉNERO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        contador += 1;
                        Mov = QueryGenreS(Mov, datos, "");
                    }
                    else if (s2.ToUpper().Contains("ALBUM: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ALBUM: ", string.Empty);
                        }
                        catch
                        {

                        }
                        Mov = QueryAlbumS(Mov, datos, "");
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("ÁLBUM: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ÁLBUM: ", string.Empty);
                        }
                        catch
                        {

                        }
                        Mov = QueryAlbumS(Mov, datos, "");
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("RATING: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("RATING: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryRatingS(Mov, Convert.ToDouble(datos), -1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("NUMERO DE REPRODUCCIONES: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NUMERO DE REPRODUCCIONES: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryNumRepS(Mov, Convert.ToInt32(datos), -1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                    else if (s2.ToUpper().Contains("NÚMERO DE REPRODUCCIONES: "))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NÚMERO DE REPRODUCCIONES: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Mov = QueryNumRepS(Mov, Convert.ToInt32(datos), -1);
                        }
                        catch
                        {

                        }
                        contador += 1;
                    }
                }
                if (contador!=0 && !Mov.Equals(Files.AllSongs))
                    listaM.Add(Mov);
            }
            List<Songs> songsfinal = new List<Songs>();
            foreach (List<Songs> list in listaM)
            {
                foreach (Songs s in list)
                {
                    int cont = 0;
                    foreach (Songs song in songsfinal)
                    {
                        if (song.Title1 == s.Title1)
                        {
                            cont += 1;
                        }
                    }
                    if (cont == 0)
                        songsfinal.Add(s);
                }
            }
            return songsfinal;
        }

        public static (List<Person>, List<User>) SmartSearchingPeoples(string S) // Artist, Sexo, Edad
        {
            List<List<Person>> listaM = new List<List<Person>>();
            string[] stringSeparators = new string[] { " | " };
            string[] ors = S.Split(stringSeparators, StringSplitOptions.None);
            int contador1 = 0;
            foreach (string s in ors)
            {
                List<Person> per = new List<Person>();
                per = Files.AllPersons;
                string[] stringSeparators2 = new string[] { " & " };
                string[] ands = s.Split(stringSeparators2, StringSplitOptions.None);
                foreach (string s2 in ands)
                {
                    if (s2.ToUpper().Contains("NOMBRE:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NOMBRE: ", string.Empty);
                        }
                        catch
                        {

                        }
                        per = QueryName(per, datos, "");
                        contador1 += 1;
                    }
                    else if (s2.ToUpper().Contains("ARTISTA:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ARTISTA: ", string.Empty);
                        }
                        catch
                        {

                        }
                        per = QueryName(per, datos, "");
                        contador1 += 1;
                    }
                    else if (s2.ToUpper().Contains("ACTOR:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("ACTOR: ", string.Empty);
                        }
                        catch
                        {

                        }
                        per = QueryName(per, datos, "");
                        contador1 += 1;
                    }
                    else if (s2.ToUpper().Contains("SEXO:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("SEXO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        if (datos.ToUpper() == "MASCULINO")
                        {
                            per = QuerySexo(per, true, false);
                        }
                        else if (datos.ToUpper() == "FEMENINO")
                        {
                            per = QuerySexo(per, false, true);
                        }
                        contador1 += 1;
                    }
                    else if (s2.ToUpper().Contains("EDAD:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("EDAD: ", string.Empty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            per = QueryEdad(per, Convert.ToInt32(datos), -1);
                        }
                        catch { }
                        contador1 += 1;
                    }
                }
                if (contador1!=0 && !per.Equals(Files.AllPersons))
                    listaM.Add(per);
            }
            List<List<User>> lista2 = new List<List<User>>();
            string[] stringSeparators3 = new string[] { " | " };
            string[] ors2 = S.Split(stringSeparators3, StringSplitOptions.None);
            int contador2 = 0;
            foreach (string s in ors2)
            {
                List<User> per = new List<User>();
                string[] stringSeparators4 = new string[] { " & " };
                string[] ands = s.Split(stringSeparators4, StringSplitOptions.None);
                foreach (string s2 in ands)
                {
                    if (s2.ToUpper().Contains("NOMBRE:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("NOMBRE: ", string.Empty);
                        }
                        catch
                        {

                        }
                        foreach (User u in Files.Users)
                        {
                            if (datos.ToUpper() == u.UserName.ToUpper())
                            {
                                per.Add(u);
                            }
                        }
                        contador2 += 1;
                    }
                    else if (s2.ToUpper().Contains("USUARIO:"))
                    {
                        string datos = null;
                        try
                        {
                            datos = s2.ToUpper().Replace("USUARIO: ", string.Empty);
                        }
                        catch
                        {

                        }
                        foreach (User u in Files.Users)
                        {
                            if (datos.ToUpper() == u.UserName.ToUpper())
                            {
                                per.Add(u);
                            }
                        }
                        contador2 += 1;
                    }
                }
                if (contador2!=0 && !per.Equals(Files.Users))
                    lista2.Add(per);
            }
            List<Person> personfinal = new List<Person>();
            foreach (List<Person> list in listaM)
            {
                foreach (Person s in list)
                {
                    int cont = 0;
                    foreach (Person person  in personfinal)
                    {
                        if (person.Name == s.Name)
                        {
                            cont += 1;
                        }
                    }
                    if (cont==0)
                        personfinal.Add(s);
                }
            }
            List<User> userfinal = new List<User>();
            foreach (List<User> list in lista2)
            {
                int cont2 = 0;
                foreach (User s in list)
                {
                    foreach(User user in userfinal)
                    {
                        if (user.UserName == s.UserName)
                        {
                            cont2 += 1;
                        }
                    }
                    if (cont2==0)
                        userfinal.Add(s);
                }
            }
            return (personfinal,userfinal);
        }

        //Query Movies
        static List<Movies> QueryTitle(List<Movies> movies, string TitleA, string TitleB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (TitleA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Title1.ToUpper()==TitleA.ToUpper() || movie.Title1.ToUpper().Contains(TitleA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (TitleB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Title1.ToUpper() == TitleB.ToUpper() || movie.Title1.ToUpper().Contains(TitleB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (movies2.Count == 0 && (TitleA == "" || TitleB == ""))
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        static List<Movies> QueryPerson(List<Movies> movies, string personA, string personB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (personA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Director1.Name.ToUpper() == personA.ToUpper() || movie.Director1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    if (movie.Writer1.Name.ToUpper() == personA.ToUpper() || movie.Writer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    foreach(Person j in movie.Actors1)
                    {
                        if ((j.Name.ToUpper() == personA.ToUpper() || j.Name.ToUpper().Contains(personA.ToUpper())))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (personB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Director1.Name.ToUpper() == personB.ToUpper() || movie.Director1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    if (movie.Writer1.Name.ToUpper() == personB.ToUpper() || movie.Writer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    foreach (Person j in movie.Actors1)
                    {
                        if ((j.Name.ToUpper() == personB.ToUpper() || j.Name.ToUpper().Contains(personB.ToUpper())))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
            
        }

        static List<Movies> QueryCategories(List<Movies> movies, string categorieA, string categorieB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (categorieA!="")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        if (j.ToUpper() == categorieA.ToUpper() || j.ToUpper().Contains(categorieA.ToUpper()))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (categorieB != "")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        if (j.ToUpper() == categorieB.ToUpper() || j.ToUpper().Contains(categorieB.ToUpper()))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        static List<Movies> QueryYear(List<Movies> movies, string yearA, string yearB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (yearA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Year1 == yearA)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (yearB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Year1 == yearB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        //Mayor o igual que ese ranking
        static List<Movies> QueryRating(List<Movies> movies, double ratingA, double ratingB)
        {
            List<Movies> movies2 = new List<Movies>();
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.RatingProm1 >= ratingA)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.RatingProm1 >= ratingB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Movies> QueryNumRep(List<Movies> movies, int numrepA, int numrepB)
        {
            List<Movies> movies2 = new List<Movies>();
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.NumReproductions >= numrepB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.NumReproductions >= numrepB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }



        //Query Songs
        static List<Songs> QueryTitleS(List<Songs> songs, string TitleA,string TitleB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (TitleA != "")
            {
                foreach(Songs song in songs)
                {
                    if (song.Title1.ToUpper() == TitleA.ToUpper() || song.Title1.ToUpper().Contains(TitleA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (TitleB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Title1.ToUpper() == TitleB.ToUpper() || song.Title1.ToUpper().Contains(TitleB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0 && (TitleA=="" || TitleB==""))
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        static List<Songs> QueryPersonsS(List<Songs> songs, string personA, string personB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (personA != "")
            {
                foreach (Songs song in songs)
                {
                    if(song.Artist1.Name.ToUpper() == personA.ToUpper() || song.Artist1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if(song.Composer1.Name.ToUpper() == personA.ToUpper() || song.Composer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach(Songs song in songs)
                {
                    if (song.Writer1.Name.ToUpper() == personA.ToUpper() || song.Writer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (personB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Artist1.Name.ToUpper() == personB.ToUpper() || song.Artist1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if (song.Composer1.Name.ToUpper() == personB.ToUpper() || song.Composer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if (song.Writer1.Name.ToUpper() == personB.ToUpper() || song.Writer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }

        }

        static List<Songs> QueryGenreS(List<Songs> songs, string genreA,string genreB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (genreA != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        if (j.ToUpper() == genreA.ToUpper() || j.ToUpper().Contains(genreA.ToUpper()))
                        {
                            songs2.Add(song);
                        }
                    }
                }
            }
            if (genreB != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        if (j.ToUpper() == genreB.ToUpper() || j.ToUpper().Contains(genreB.ToUpper()))
                        {
                            songs2.Add(song);
                        }
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Songs> QueryNumRepS(List<Songs> songs, int numrepA, int numrepB)
        {
            List<Songs> songs2 = new List<Songs>();
            try
            {
                foreach (Songs song in songs)
                {
                    if ((song.NumReproductions >= numrepA))
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (Songs song in songs)
                {
                    if ((song.NumReproductions >= numrepB))
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs;
            }
        }

        static List<Songs> QueryRatingS(List<Songs> songs, double ratingA,double ratingB)
        {
            List<Songs> songs2 = new List<Songs>();
            try
            {
                foreach (Songs song in songs)
                {
                    if (song.RatingProm1 >= ratingA)
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (Songs song in songs)
                {
                    if (song.RatingProm1 >= ratingB)
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            if (songs2.Count == 0)
            { 
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        static List<Songs> QueryAlbumS(List<Songs> songs, string albumA, string albumB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (albumA != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Album1.Name1.ToUpper() == albumA.ToUpper() || song.Album1.Name1.ToUpper().Contains(albumA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (albumB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Album1.Name1.ToUpper() == albumB.ToUpper() || song.Album1.Name1.ToUpper().Contains(albumB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        //Persons
         static List<Person> QueryName(List<Person> persons, string nameA,string nameB)
         {
            if (nameA == "")
            {
                nameA = 0.ToString();
            }
            if (nameB == "")
            {
                nameB = 0.ToString();
            }
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.Name.ToUpper()==nameA.ToUpper() || person.Name.ToUpper().Contains(nameA.ToUpper()))
                {
                    persons2.Add(person);
                }
                if (person.Name.ToUpper() == nameB.ToUpper() || person.Name.ToUpper().Contains(nameB.ToUpper()))
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0 && (nameA == 0.ToString() || nameB == 0.ToString()))
            {
                return persons;
            }
            else
            {
                return persons2;
            }
         }

         static List<Person> QuerySexo(List<Person> persons, bool masc,bool fem)
         {
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.Genre == 'M' && masc==true)
                {
                    persons2.Add(person);
                }
                if (person.Genre == 'F' && fem == true)
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0)
            {
                return persons;
            }
            else
            {
                return persons2;
            }
         }

        static List<Person> QueryEdad(List<Person> persons, int edadA, int edadB)
        {
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                int age = GetAge(person.Birthday);
                if (age == edadA)
                {
                    persons2.Add(person);
                }
                if (age == edadB)
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0)
            {
                return persons;
            }
            else
            {
                return persons2;
            }
        }

        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
    }
}
