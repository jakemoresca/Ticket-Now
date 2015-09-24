using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private ApplicationDbContext _ctx;

        public LocationRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public LocationDto AddLocation(LocationDto location)
        {
            var newLocation = _ctx.Locations.Add(location);
            _ctx.SaveChanges();
            return newLocation;
        }

        public bool DeleteLocation(Guid id)
        {
            var location = FindById(id);
            _ctx.Locations.Remove(location);
            _ctx.SaveChanges();
            return true;
        }

        public LocationDto FindById(Guid id)
        {
            return _ctx.Locations.Find(id);
        }

        public LocationDto FindByName(string locationName)
        {
            return _ctx.Locations.Where(l => l.Name == locationName).FirstOrDefault();
        }

        public List<LocationDto> GetAll()
        {
            return _ctx.Locations.ToList();
        }

        public LocationDto UpdateLocation(LocationDto updatedLocation)
        {
            _ctx.Entry(updatedLocation).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedLocation;
        }
    }
}
