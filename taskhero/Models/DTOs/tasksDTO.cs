using System.ComponentModel.DataAnnotations;

namespace taskhero.Models.DTOs
{
    public class tasksDTO
    {


        public int Id { get; set; }

        [Required]
        public int PrioritizationID { get; set; }
        [Required]
        public string TaskOwnerName { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string imageURL { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string ownerID { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string taskType { get; set; }
        [Required]
        public string timeCreated { get; set; }


    }
}
