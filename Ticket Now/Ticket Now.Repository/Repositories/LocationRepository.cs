using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public class LocationRepository : IRepository<LocationDto>
    {
        private readonly ApplicationDbContext _ctx;

        public LocationRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public LocationDto Add(LocationDto location)
        {
            var newLocation = _ctx.Locations.Add(location);
            _ctx.SaveChanges();
            return newLocation;
        }

        public bool Delete(string id)
        {
            var location = FindById(id);
            _ctx.Locations.Remove(location);
            _ctx.SaveChanges();
            return true;
        }

        public LocationDto FindById(string id)
        {
            return _ctx.Locations.FirstOrDefault(l => l.Id == new Guid(id));
        }

        public LocationDto FindByName(string name)
        {
            return _ctx.Locations.FirstOrDefault(l => l.Name == name);
        }

        public List<LocationDto> GetAll()
        {
            return _ctx.Locations.ToList();
        }

        public LocationDto Update(LocationDto updatedLocation)
        {
            _ctx.Entry(updatedLocation).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedLocation;
        }
    }
}
