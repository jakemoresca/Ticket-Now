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
    [RoutePrefix("Schedule")]
    public class ScheduleController : ApiController
    {
        private readonly IRepository<ScheduleDto> _scheduleRepository;
        private readonly IScheduleMapper _scheduleMapper;

        public ScheduleController(IRepository<ScheduleDto> scheduleRepository, IScheduleMapper scheduleMapper)
        {
            _scheduleRepository = scheduleRepository;
            _scheduleMapper = scheduleMapper;
        }

        [HttpGet]
        [Authorize]
        public List<Schedule> Get()
        {
            var schedules = _scheduleRepository.GetAll().Select(u => _scheduleMapper.ToModel(u));
            return schedules.ToList();
        }
    }
}
