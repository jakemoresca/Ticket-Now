using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Admin.Api.Controllers
{
    [RoutePrefix("Location")]
    public class LocationController : ApiController
    {
        private readonly IRepository<LocationDto> _locationRepository;
        private readonly ILocationMapper _locationMapper;

        public LocationController(IRepository<LocationDto> locationRepository, ILocationMapper locationMapper)
        {
            _locationRepository = locationRepository;
            _locationMapper = locationMapper;
        }

        [HttpGet]
        [Authorize]
        public List<Location> Get()
        {
            var locations = _locationRepository.GetAll().Select(u => _locationMapper.ToModel(u));
            return locations.ToList();
        }

        [HttpGet]
        [Authorize]
        public Location Get(string id)
        {
            var locationDto = _locationRepository.FindById(id);
            return _locationMapper.ToModel(locationDto);
        }

        [HttpPost]
        [Authorize]
        public Location Post([FromBody]Location location)
        {
            location.Id = Guid.NewGuid();
            var locationDto = _locationRepository.Add(_locationMapper.ToDto(location));
            return _locationMapper.ToModel(locationDto);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public Location Put([FromBody]Location location, string id)
        {
            var updatedRoleDto = _locationRepository.Update(_locationMapper.ToDto(location));
            return _locationMapper.ToModel(updatedRoleDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public bool Delete(string id)
        {
            return _locationRepository.Delete(id);
        }
    }
}
