using System;

namespace Ticket_Now.Repository.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public bool Deleted { get; set; }
    }
}
