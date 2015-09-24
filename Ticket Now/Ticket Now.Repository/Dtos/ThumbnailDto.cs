﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Now.Repository.Dtos
{
    [Table("Thumbnails")]
    public class ThumbnailDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string ExtensionName { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
