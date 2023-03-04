using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.API.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public double rate { get; set; }
        [MaxLength(2500)]
        public string storeline { get; set; }
        public byte[] Poster { get; set; }
        public byte GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
