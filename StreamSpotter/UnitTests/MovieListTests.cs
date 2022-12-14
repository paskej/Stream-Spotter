using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StreamSpotter;
using System;
using System.IO;

namespace UnitTests
{
    /*******************************************************************************************************
     * FilterTests tests the methods that aren't related to gui and aren't variable result methods
     *******************************************************************************************************/
    [TestClass]
    public class MovieListTests
    {
        static string BASE_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        static string WITCHER = "{\"results\":[{\"imdbID\":\"tt5180504\",\"tmdbID\":\"71912\",\"imdbRating\":83,\"imdbVoteCount\":456933,\"tmdbRating\":82,\"backdropPath\":\"/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\"},\"originalTitle\":\"The Witcher\",\"genres\":[28,12,18],\"countries\":[\"US\"],\"year\":2019,\"firstAirYear\":2019,\"lastAirYear\":2021,\"episodeRuntimes\":[60],\"cast\":[\"Henry Cavill\",\"Anya Chalotra\",\"Freya Allan\",\"Mimi Ndiweni\",\"Eamon Farren\",\"Wilson Radjou-Pujalte\",\"MyAnna Buring\"],\"significants\":[\"Lauren Schmidt Hissrich\"],\"title\":\"The Witcher\",\"overview\":\"Geralt of Rivia, a mutated monster-hunter for hire, journeys toward his destiny in a turbulent world where people often prove more wicked than beasts.\",\"video\":\"eb90gqGYP9c\",\"posterPath\":\"/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\"},\"seasons\":2,\"episodes\":16,\"age\":17,\"status\":1,\"tagline\":\"\",\"streamingInfo\":{\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/80189685/\",\"added\":1600382656,\"leaving\":0}}},\"originalLanguage\":\"en\"},{\"imdbID\":\"tt12748032\",\"tmdbID\":\"108987\",\"imdbRating\":71,\"imdbVoteCount\":146,\"tmdbRating\":61,\"backdropPath\":\"/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\"},\"originalTitle\":\"The Witcher: A Look Inside the Episodes\",\"genres\":[99,6],\"countries\":[\"GB\"],\"year\":2020,\"firstAirYear\":2020,\"lastAirYear\":2020,\"episodeRuntimes\":[5],\"cast\":[\"Lauren Schmidt Hissrich\"],\"significants\":[],\"title\":\"The Witcher: A Look Inside the Episodes\",\"overview\":\"With series creator Lauren S. Hissrich as your guide, take an in-depth journey into the stories and themes powering the first season of The Witcher.\",\"video\":\"\",\"posterPath\":\"/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\"},\"seasons\":1,\"episodes\":8,\"age\":-1,\"status\":4,\"tagline\":\"\",\"streamingInfo\":{\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/81294100/\",\"added\":1636213877,\"leaving\":0}}},\"originalLanguage\":\"en\"}],\"total_pages\":1}";
        static string BATMAN = "{\"results\":[{\"imdbID\":\"tt0372784\",\"tmdbID\":\"272\",\"imdbRating\":83,\"imdbVoteCount\":1415322,\"tmdbRating\":77,\"backdropPath\":\"/hQrHN6WXERVw6XUMpfCgLfvrh5V.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/hQrHN6WXERVw6XUMpfCgLfvrh5V.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/hQrHN6WXERVw6XUMpfCgLfvrh5V.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/hQrHN6WXERVw6XUMpfCgLfvrh5V.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/hQrHN6WXERVw6XUMpfCgLfvrh5V.jpg\"},\"originalTitle\":\"Batman Begins\",\"genres\":[28,80,18],\"countries\":[\"GB\",\"US\"],\"year\":2005,\"runtime\":140,\"cast\":[\"Christian Bale\",\"Michael Caine\",\"Liam Neeson\",\"Katie Holmes\",\"Gary Oldman\",\"Cillian Murphy\",\"Tom Wilkinson\"],\"significants\":[\"Christopher Nolan\"],\"title\":\"Batman Begins\",\"overview\":\"Driven by tragedy, billionaire Bruce Wayne dedicates his life to uncovering and defeating the corruption that plagues his home, Gotham City. Unable to work within the system, he instead creates a new identity, a symbol of fear for the criminal underworld - The Batman.\",\"tagline\":\"Evil fears the knight.\",\"video\":\"FiL15DWV7Y\",\"posterPath\":\"/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/8RW2runSEc34IwKN2D1aPcJd2UL.jpg\"},\"age\":11,\"streamingInfo\":{\"hbo\":{\"us\":{\"link\":\"https://play.hbomax.com/page/urn:hbo:page:GXeOM3Q7qcZuAuwEAADwo:type:feature\",\"added\":1609567234,\"leaving\":0}},\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/70021642/\",\"added\":1645426112,\"leaving\":0}}},\"originalLanguage\":\"en\"},{\"imdbID\":\"tt0468569\",\"tmdbID\":\"155\",\"imdbRating\":91,\"imdbVoteCount\":2532564,\"tmdbRating\":85,\"backdropPath\":\"/nMKdUUepR0i5zn0y1T4CsSB5chy.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/nMKdUUepR0i5zn0y1T4CsSB5chy.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/nMKdUUepR0i5zn0y1T4CsSB5chy.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/nMKdUUepR0i5zn0y1T4CsSB5chy.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/nMKdUUepR0i5zn0y1T4CsSB5chy.jpg\"},\"originalTitle\":\"The Dark Knight\",\"genres\":[28,80,18],\"countries\":[\"GB\",\"US\"],\"year\":2008,\"runtime\":152,\"cast\":[\"Christian Bale\",\"Heath Ledger\",\"Michael Caine\",\"Gary Oldman\",\"Aaron Eckhart\",\"Maggie Gyllenhaal\",\"Morgan Freeman\"],\"significants\":[\"Christopher Nolan\"],\"title\":\"The Dark Knight\",\"overview\":\"Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.\",\"tagline\":\"Welcome to a world without rules.\",\"video\":\"kmJLuwP3MbY\",\"posterPath\":\"/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/qJ2tW6WMUDux911r6m7haRef0WH.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/qJ2tW6WMUDux911r6m7haRef0WH.jpg\"},\"age\":12,\"streamingInfo\":{\"hbo\":{\"us\":{\"link\":\"https://play.hbomax.com/page/urn:hbo:page:GXdkpqAvyDaXCPQEAADdn:type:feature\",\"added\":1609567221,\"leaving\":0}},\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/70079583/\",\"added\":1645436371,\"leaving\":0}}},\"originalLanguage\":\"en\"}],\"totalpages\":1}";

        /*******************************************************************************************************
        * Method to test a empty list
        *******************************************************************************************************/
        [TestMethod]
        public void EmptySearchList()
        {
            MovieList movieList = new MovieList();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            Result[] list = new Result[0];
            movieList.populateSearchList(list);
            Assert.AreEqual(null, movieList.getMovie(0), "Empty MovieList Test failed");
        }
        /*******************************************************************************************************
        * Method to test if movies were added to the lists
        *******************************************************************************************************/
        [TestMethod]
        public void ChangeSearchList()
        {
            MovieList movieList = new MovieList();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            RootObject ro1 = JsonConvert.DeserializeObject<RootObject>(BATMAN);
            Result[] list = { ro.results[0], ro1.results[0] };//add another movie
            movieList.populateSearchList(list);
            Assert.IsTrue(movieList.getListSize() == 2 && movieList.getMovie(0) == ro.results[0] 
                && movieList.getMovie(1) == ro1.results[0], "Change Search List Test failed");
        }
        /*******************************************************************************************************
        * Method to test if the movie added to the list is the same movie from the get method
        *******************************************************************************************************/
        [TestMethod]
        public void TestGetMovie()
        {
            MovieList movieList = new MovieList();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            Result[] list = { ro.results[0] };//add another movie
            movieList.populateSearchList(list);
            Assert.IsTrue(movieList.getMovie(0) == ro.results[0], "Get movie test failed");
        }
        /*******************************************************************************************************
        * Method to test if the size of lists changes
        *******************************************************************************************************/
        [TestMethod]
        public void TestListSize()
        {
            MovieList movieList = new MovieList();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            Result[] list = { ro.results[0] };//add another movie
            movieList.populateSearchList(list);
            Assert.IsTrue(movieList.getListSize()==1, "Get movie test failed");
        }
    }
}
