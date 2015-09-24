﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public interface ILocationRepository
    {
        LocationDto FindByName(string locationName);

        LocationDto FindById(Guid id);
        LocationDto AddLocation(LocationDto location);
        bool DeleteLocation(Guid id);
        LocationDto UpdateLocation(LocationDto updatedLocation);
        List<LocationDto> GetAll();
    }
}
