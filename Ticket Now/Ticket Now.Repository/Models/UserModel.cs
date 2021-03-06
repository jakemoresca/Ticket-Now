﻿using System.Collections.Generic;

namespace Ticket_Now.Repository.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string HomeTown { get; set; }
        public int ZipCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Claim> Claims { get; set; }

        public Role Role { get; set; }
    }
}
