using DBLaba2Cherechecha.NoSqlModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;

namespace DBLaba2Cherechecha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoSqlTestController : ControllerBase
    {
        private readonly IMongoCollection<Movie> _movie;
        private readonly IMongoCollection<Review> _review;
        private readonly IMongoCollection<Session> _session;


        public NoSqlTestController(IConfiguration config)
        {
            string connectionString = config.GetConnectionString("NoSqlConnection");
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Bohdan");

            _movie = database.GetCollection<Movie>("Movies");
            _review = database.GetCollection<Review>("Reviews");
            _session = database.GetCollection<Session>("Sessions");
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var movie = new Movie()
            {
                MovieName = "movie",
                MovieDuration = 100,
                MovieRating = 5,
            };

            var review = new Review()
            {
                ReviewDate = new DateOnly(2023, 01, 01),
                Rating = 1,
                ReviewText = "test",
                FkMovie = movie
            };

            var session = new Session()
            {
                SessionNumber = 1,
                FkSessionStatusId = 1,
                FkHallId = "1",
                FkMovie = movie,
            };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    movie.MovieId = null;
                    review.ReviewId = null;
                    session.SessionId = null;

                    await _movie.InsertOneAsync(movie);
                    await _review.InsertOneAsync(review);
                    await _session.InsertOneAsync(session);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            stopwatch.Stop();
            return Ok($"Час створення та збереження 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                await _movie.DeleteOneAsync(Builders<Movie>.Filter.Empty);
                await _review.DeleteOneAsync(Builders<Review>.Filter.Empty);
                await _session.DeleteOneAsync(Builders<Session>.Filter.Empty);
            }

            stopwatch.Stop();
            return Ok($"Час видалення 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }

        [HttpPatch]
        public async Task<IActionResult> Update()
        {
            var filterMovie = Builders<Movie>.Filter.Empty;
            var filterReview = Builders<Review>.Filter.Empty;
            var filterSession = Builders<Session>.Filter.Empty;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                var updateMovie = Builders<Movie>.Update.Set("MovieName", "name");
                await _movie.UpdateOneAsync(filterMovie, updateMovie);

                var updateReview = Builders<Review>.Update.Set("ReviewText", "test");
                await _review.UpdateOneAsync(filterReview, updateReview);

                var updateSession = Builders<Session>.Update.Set("FkHallId", "1");
                await _session.UpdateOneAsync(filterSession, updateSession);
            }

            stopwatch.Stop();
            return Ok($"Час оновлення 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    await _movie.FindAsync(Builders<Movie>.Filter.Empty);
                    await _review.FindAsync(Builders<Review>.Filter.Empty);
                    await _session.FindAsync(Builders<Session>.Filter.Empty);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            stopwatch.Stop();
            return Ok($"Час отримання 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }
    }
}
