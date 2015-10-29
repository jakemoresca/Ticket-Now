using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace TicketNow.UserPortal.Api.Controllers
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
    }
}
