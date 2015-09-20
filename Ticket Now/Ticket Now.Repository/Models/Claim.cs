using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Now.Repository.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
