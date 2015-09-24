using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Admin.Api.Controllers
{
    [RoutePrefix("Location")]
    public class LocationController : ApiController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationMapper _locationMapper;

        public LocationController(ILocationRepository locationRepository, ILocationMapper locationMapper)
        {
            _locationRepository = locationRepository;
            _locationMapper = locationMapper;
        }

        [HttpGet]
        [Authorize]
        public List<Location> Get()
        {
            var roles = _locationRepository.GetAll().Select(u => _locationMapper.ToModel(u));
            return roles.ToList();
        }

        [HttpGet]
        [Authorize]
        public Location Get(Guid id)
        {
            var locationDto = _locationRepository.FindById(id);
            return _locationMapper.ToModel(locationDto);
        }

        [HttpPost]
        [Authorize]
        public Location Post([FromBody]Location location)
        {
            var locationDto = _locationRepository.AddLocation(_locationMapper.ToDto(location));
            return _locationMapper.ToModel(locationDto);
        }

        [HttpPut]
        [Authorize]
        [Route("{name}")]
        public Location Put([FromBody]Location location, string name)
        {
            var updatedRoleDto = _locationRepository.UpdateLocation(_locationMapper.ToDto(location));
            return _locationMapper.ToModel(updatedRoleDto);
        }

        [HttpDelete]
        [Authorize]
        public bool Delete(Guid id)
        {
            return _locationRepository.DeleteLocation(id);
        }
    }
}
