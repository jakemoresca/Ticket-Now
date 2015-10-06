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

        [HttpGet]
        [Authorize]
        public Event Get(string id)
        {
            var eventDto = _eventRepository.FindById(id);
            return _eventMapper.ToModel(eventDto);
        }

        [HttpPost]
        [Authorize]
        public Event Post([FromBody]Event eventModel)
        {
            eventModel.Id = Guid.NewGuid();
            var eventDto = _eventRepository.Add(_eventMapper.ToDto(eventModel));
            return _eventMapper.ToModel(eventDto);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public Event Put([FromBody]Event eventModel, string id)
        {
            var updatedRoleDto = _eventRepository.Update(_eventMapper.ToDto(eventModel));
            return _eventMapper.ToModel(updatedRoleDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public bool Delete(string id)
        {
            return _eventRepository.Delete(id);
        }
    }
}
