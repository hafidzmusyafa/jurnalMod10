using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300162.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // static list untuk menyimpan data (in-memory)
        private static List<Movie> _movieList = new List<Movie>
        {
            new Movie { Title = "The Shawshank Redemption", Director = "Frank Darabont",   Stars = new List<string> {"Tim Robbins","Morgan Freeman","Bob Gunton"}, Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola",   Stars = new List<string> { "Marlon Brando", "Al Pacino", "James Caan"}, Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie { Title = "Schindler's List", Director = "Steven Spielberg",   Stars = new List<string> { "Liam Neeson", "Raplh Fiennes", "Ben Kingsley"}, Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis."}
        };

        // GET /api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(_movieList);
        }

        // GET /api/Movies/{index}
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            // Asumsi input selalu benar 
            if (id < 0 || id >= _movieList.Count)
            {
                return NotFound($"Movie dengan id {id} tidak ditemukan.");
            }
            return Ok(_movieList[id]);
        }

        // POST /api/Movies
        [HttpPost]
        public ActionResult Post([FromBody] Movie newMovie)
        {
            // Asumsi input selalu benar
            _movieList.Add(newMovie);
            return CreatedAtAction(nameof(Get), new { index = _movieList.Count - 1 }, newMovie);
        }

        // DELETE /api/Movies/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Asumsi input selalu benar
            if (id < 0 || id >= _movieList.Count)
            {
                return NotFound($"Movies dengan id {id} tidak ditemukan.");
            }
            _movieList.RemoveAt(id);

            return NoContent();
        }
    }
}
