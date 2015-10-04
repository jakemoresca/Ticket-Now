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

        [HttpGet]
        [Authorize]
        public Schedule Get(string id)
        {
            var scheduleDto = _scheduleRepository.FindById(id);
            return _scheduleMapper.ToModel(scheduleDto);
        }

        [HttpPost]
        [Authorize]
        public Schedule Post([FromBody]Schedule scheduleModel)
        {
            scheduleModel.Id = Guid.NewGuid();
            var scheduleDto = _scheduleRepository.Add(_scheduleMapper.ToDto(scheduleModel));
            return _scheduleMapper.ToModel(scheduleDto);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public Schedule Put([FromBody]Schedule scheduleModel, string id)
        {
            var updatedRoleDto = _scheduleRepository.Update(_scheduleMapper.ToDto(scheduleModel));
            return _scheduleMapper.ToModel(updatedRoleDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public bool Delete(string id)
        {
            return _scheduleRepository.Delete(id);
        }
    }
}
