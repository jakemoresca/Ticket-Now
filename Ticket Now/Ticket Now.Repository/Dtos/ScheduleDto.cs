using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Now.Repository.Dtos
{
    [Table("EventSchedules")]
    public class ScheduleDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public Guid EventId { get; set; }

        [ForeignKey("EventId")]
        public EventDto Event { get; set; }

        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

    }
}
