using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MoviesApi.ViewModels
{
  public class MovieDetails

  {
    public int Id { get; set; }
    public string File { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Duration { get; set; }
    public string Director { get; set; }
    public string Poster { get; set; }


  }
}