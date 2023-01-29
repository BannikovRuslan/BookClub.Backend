using AutoMapper;
using BookClub.Application.Meetings.Quries;
using BookClub.Application.Meetings.ViewModels;
using BookClub.Application.Meetings.Commands;
using BookClub.Domains;
using BookClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookClub.WebApi.Controllers
{
    [Route("meetings")]
    public class MeetingController : BaseController
    {
        private readonly IMapper _mapper;

        public MeetingController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<MeetingListVm>> GetAll()
        {
            DateTime? dateString;
            if (Request.Query["date"].Count > 0)
            {
                dateString = DateTime.Parse(Request.Query["date"].ToString());
            }
            else
            {
                dateString = null;
            }

            int limit = Request.Query["_limit"].Count > 0 ? int.Parse(Request.Query["_limit"]) : 0;
            int page = Request.Query["_page"].Count > 0 ? int.Parse(Request.Query["_page"]) : 0;

            var query = new GetMeetingListQuery
            {
                SearchDate = dateString,
                limit= limit,
                page = page
            };

            var vm = await Mediator.Send(query);
            return Ok(vm.Meetings);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDetailsVm>> Get(Guid id)
        {
            var query = new GetMeetingDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Meeting>> Create([FromBody] CreateMeetingDto createMeetingDto)
        {
            var command = _mapper.Map<CreateMeetingCommand>(createMeetingDto);
            var meeting = await Mediator.Send(command);
            return Ok(meeting);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateMeetingDto updateMeetingDto)
        {
            var command = _mapper.Map<UpdateMeetingCommand>(updateMeetingDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMeetingCommand
            {
                Id = id
            };
            var vm = await Mediator.Send(command);
            return Ok(new { id = vm.Id });
        }
    }
}
