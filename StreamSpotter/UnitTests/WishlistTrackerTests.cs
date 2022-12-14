using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StreamSpotter;
using System;
using System.IO;

namespace UnitTests
{

    [TestClass]
    public class WishlistTrackerTests
    {
        static string BASE_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        static string WITCHER = "{\"results\":[{\"imdbID\":\"tt5180504\",\"tmdbID\":\"71912\",\"imdbRating\":83,\"imdbVoteCount\":456933,\"tmdbRating\":82,\"backdropPath\":\"/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/jBJWaqoSCiARWtfV0GlqHrcdidd.jpg\"},\"originalTitle\":\"The Witcher\",\"genres\":[28,12,18],\"countries\":[\"US\"],\"year\":2019,\"firstAirYear\":2019,\"lastAirYear\":2021,\"episodeRuntimes\":[60],\"cast\":[\"Henry Cavill\",\"Anya Chalotra\",\"Freya Allan\",\"Mimi Ndiweni\",\"Eamon Farren\",\"Wilson Radjou-Pujalte\",\"MyAnna Buring\"],\"significants\":[\"Lauren Schmidt Hissrich\"],\"title\":\"The Witcher\",\"overview\":\"Geralt of Rivia, a mutated monster-hunter for hire, journeys toward his destiny in a turbulent world where people often prove more wicked than beasts.\",\"video\":\"eb90gqGYP9c\",\"posterPath\":\"/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/7vjaCdMw15FEbXyLQTVa04URsPm.jpg\"},\"seasons\":2,\"episodes\":16,\"age\":17,\"status\":1,\"tagline\":\"\",\"streamingInfo\":{\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/80189685/\",\"added\":1600382656,\"leaving\":0}}},\"originalLanguage\":\"en\"},{\"imdbID\":\"tt12748032\",\"tmdbID\":\"108987\",\"imdbRating\":71,\"imdbVoteCount\":146,\"tmdbRating\":61,\"backdropPath\":\"/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"backdropURLs\":{\"1280\":\"https://image.tmdb.org/t/p/w1280/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"300\":\"https://image.tmdb.org/t/p/w300/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/5xGIXzU3s5015zKLvHWNftmWgqm.jpg\"},\"originalTitle\":\"The Witcher: A Look Inside the Episodes\",\"genres\":[99,6],\"countries\":[\"GB\"],\"year\":2020,\"firstAirYear\":2020,\"lastAirYear\":2020,\"episodeRuntimes\":[5],\"cast\":[\"Lauren Schmidt Hissrich\"],\"significants\":[],\"title\":\"The Witcher: A Look Inside the Episodes\",\"overview\":\"With series creator Lauren S. Hissrich as your guide, take an in-depth journey into the stories and themes powering the first season of The Witcher.\",\"video\":\"\",\"posterPath\":\"/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"posterURLs\":{\"154\":\"https://image.tmdb.org/t/p/w154/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"185\":\"https://image.tmdb.org/t/p/w185/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"342\":\"https://image.tmdb.org/t/p/w342/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"500\":\"https://image.tmdb.org/t/p/w500/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"780\":\"https://image.tmdb.org/t/p/w780/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"92\":\"https://image.tmdb.org/t/p/w92/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\",\"original\":\"https://image.tmdb.org/t/p/original/8EFkCGviYiyQJmIKx8YH1ooQa85.jpg\"},\"seasons\":1,\"episodes\":8,\"age\":-1,\"status\":4,\"tagline\":\"\",\"streamingInfo\":{\"netflix\":{\"us\":{\"link\":\"https://www.netflix.com/title/81294100/\",\"added\":1636213877,\"leaving\":0}}},\"originalLanguage\":\"en\"}],\"total_pages\":1}";
        [TestMethod]

        public void ChangeWishlists()
        {
            DatabaseAccess db = new DatabaseAccess();
            WishlistTracker wt = new WishlistTracker();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            db.addProfileDirectory(1);
            db.addJson(1, "List1");
            db.addProfileDirectory(2);
            db.addJson(2, "List2");
            db.addToWishlist(1, "List1", ro.results[0]);
            db.addToWishlist(2, "List2", ro.results[1]);
            wt.changeCurrentWishlist(1, "List1");
            Assert.AreEqual(wt.getCurrentWishlist()[0].title, db.getWishlist(1, "List1")[0].title, "Change wishlist failed");
        }

        [TestMethod]
        public void ChangeWishlistsTwice()
        {
            DatabaseAccess db = new DatabaseAccess();
            WishlistTracker wt = new WishlistTracker();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(WITCHER);
            db.addProfileDirectory(1);
            db.addJson(1, "List1");
            db.addProfileDirectory(2);
            db.addJson(2, "List2");
            db.addToWishlist(1, "List1", ro.results[0]);
            db.addToWishlist(2, "List2", ro.results[1]);
            wt.changeCurrentWishlist(1, "List1");
            wt.changeCurrentWishlist(2, "List2");
            Assert.AreEqual(wt.getCurrentWishlist()[0].title, db.getWishlist(2, "List2")[0].title, "Change wishlist twice failed");
        }

        [TestMethod]
        public void ChangeWishlistsNULL()
        {
            DatabaseAccess db = new DatabaseAccess();
            WishlistTracker wt = new WishlistTracker();
            wt.changeCurrentWishlist(1, null);
            Assert.AreEqual(wt.getCurrentWishlist(), null, "Failed to change to null wishlist");
        }
    }
}