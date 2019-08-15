using System.ComponentModel.DataAnnotations;

namespace DogRestService.API.Models
{
    public class ApiDog
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
