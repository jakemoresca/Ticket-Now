using System.ComponentModel.DataAnnotations;

namespace Ticket_Now.Repository.Models
{
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
