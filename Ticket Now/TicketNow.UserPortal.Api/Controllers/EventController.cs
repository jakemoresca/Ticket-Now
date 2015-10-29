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
    [RoutePrefix("Event")]
    public class EventController : ApiController
    {
        private readonly IRepository<EventDto> _eventRepository;
        private readonly IEventMapper _eventMapper;

        public EventController(IRepository<EventDto> eventRepository, IEventMapper eventMapper)
        {
            _eventRepository = eventRepository;
            _eventMapper = eventMapper;
        }

        [HttpGet]
        [Authorize]
        public List<Event> Get()
        {
            var events = _eventRepository.GetAll().Select(u => _eventMapper.ToModel(u));
            return events.ToList();
        }
    }
}
