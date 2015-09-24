using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Now.Repository.Dtos
{
    [Table("Locations")]
    public class LocationDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ThumbnailId { get; set; }

        [ForeignKey("ThumbnailId")]
        public ThumbnailDto Thumbnail { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

    }
}
