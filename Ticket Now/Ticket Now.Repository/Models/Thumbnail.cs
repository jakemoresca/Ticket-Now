using System;

namespace Ticket_Now.Repository.Models
{
    public class Thumbnail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExtensionName { get; set; }
        public byte[] Content { get; set; }
    }
}
