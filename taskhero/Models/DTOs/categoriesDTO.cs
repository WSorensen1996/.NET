using System.ComponentModel.DataAnnotations;

namespace taskhero.Models.DTOs
{
    public class categoriesDTO
    {

        public int Id { get; set; }

        [Required]
        public string category { get; set; }
      
        [Required]
        public string imageURL { get; set; }


    }
}
