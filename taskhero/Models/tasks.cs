using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskhero.Models
{
    public class tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PrioritizationID { get; set; }
        public string TaskOwnerName { get; set; }

        public string category { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public string location { get; set; }
        public string ownerID { get; set; }
        public string price { get; set; }
        public string subject { get; set; }
        public string taskType { get; set; }
        public string timeCreated { get; set; }


    }

}