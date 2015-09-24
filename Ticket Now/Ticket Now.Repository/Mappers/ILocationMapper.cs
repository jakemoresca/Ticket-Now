﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface ILocationMapper
    {
        Location ToModel(LocationDto dto);
        LocationDto ToDto(Location model);
    }
}
