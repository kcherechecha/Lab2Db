using DBLaba2Cherechecha.SqlModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBLaba2Cherechecha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlTestController : ControllerBase
    {
        private readonly Dblaba2CherechechaContext _context;

        public SqlTestController(Dblaba2CherechechaContext context)
        {
            _context = context;
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
                _context.Movies.Add(movie);
                _context.Reviews.Add(review);
                _context.Sessions.Add(session);
            }

            await _context.SaveChangesAsync();

            stopwatch.Stop();
            return Ok($"Час створення та збереження 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var movie = await _context.Movies.FindAsync(0);
            var review = await _context.Reviews.FindAsync(0);
            var session = await _context.Sessions.FindAsync(0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                _context.Movies.Remove(movie);
                _context.Reviews.Remove(review);
                _context.Sessions.Remove(session);
            }

            await _context.SaveChangesAsync();

            stopwatch.Stop();
            return Ok($"Час видалення 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }

        [HttpPatch]
        public async Task<IActionResult> Update()
        {
            var movie = await _context.Movies.FindAsync(0);
            var review = await _context.Reviews.FindAsync(0);
            var session = await _context.Sessions.FindAsync(0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                _context.Movies.Update(movie);
                _context.Reviews.Update(review);
                _context.Sessions.Update(session);
            }

            await _context.SaveChangesAsync();

            stopwatch.Stop();
            return Ok($"Час видалення 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                await _context.Movies.FindAsync(0);
                await _context.Reviews.FindAsync(0);
                await _context.Sessions.FindAsync(0);
            }

            stopwatch.Stop();
            return Ok($"Час отримання 1000 об'єктів: {stopwatch.ElapsedMilliseconds} мілісекунд");
        }
    }
}
