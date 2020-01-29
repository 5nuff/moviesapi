using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;
using MoviesApi.ViewModels;



namespace MoviesApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MovieController : ControllerBase
  {
    [HttpGet("getallmovies")]
    public ActionResult GetAllMovies()
    {
      var db = new DatabaseContext();
      return Ok(db.Movies.OrderBy(movie => movie.Type));
    }
    [HttpGet("getmovie/{id}")]
    public ActionResult GetOneMovie2(int id)
    {
      var db = new DatabaseContext();
      var movie = db.Movies.FirstOrDefault(mo => mo.Id == id);

      if (movie == null)
      {
        return NotFound();
      }
      else
      {
        // create our json object///////////////////
        var rv = new MovieDetails
        {
          Id = movie.Id,
          Title = movie.Title,
          File = movie.File,
          Year = movie.Year,
          Genre = movie.Genre,
          Duration = movie.Duration,
          Director = movie.Director,
          Poster = movie.Poster
        };
        return Ok(rv);
      };

    }

    [HttpGet("getgenre/{genre}")]
    public ActionResult GetByGenre(string genre)
    {
      var db = new DatabaseContext();
      var movies = db.Movies.Where(it => it.Genre == genre);
      if (movies == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(movies);
      }
    }
    [HttpGet("{id}")]
    public ActionResult GetOneMovie(int id)
    {
      var db = new DatabaseContext();
      var movie = db.Movies.FirstOrDefault(it => it.Id == id);
      if (movie == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(movie);
      }
    }
    [HttpPost]
    public ActionResult CreateMovie(Movie movie)
    {
      var db = new DatabaseContext();
      movie.Id = 0;
      db.Movies.Add(movie);
      db.SaveChanges();
      return Ok(movie);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateMovie(Movie movie)
    {
      var db = new DatabaseContext();
      var prevMovie = db.Movies.FirstOrDefault(st => st.Id == movie.Id);
      if (prevMovie == null)
      {
        return NotFound();
      }
      else
      {
        prevMovie.Title = movie.Title;
        prevMovie.File = movie.File;
        prevMovie.Poster = movie.Poster;
        prevMovie.Year = movie.Year;
        prevMovie.Genre = movie.Genre;
        prevMovie.Duration = movie.Duration;
        prevMovie.Director = movie.Director;
        db.SaveChanges();
        return Ok(prevMovie);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteMovie(int id)
    {
      var db = new DatabaseContext();
      var movie = db.Movies.FirstOrDefault(st => st.Id == id);
      if (movie == null)
      {
        return NotFound();
      }
      else
      {
        db.Movies.Remove(movie);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}