using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.Queries;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Speakers.Commands;
using BookClub.Application.Speakers.Queries;
using BookClub.Application.Speakers.ViewModels;
using BookClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.WebApi.Controllers
{
    [Route("speakers")]
    public class SpeakerController : BaseController
    {
        private readonly IMapper _mapper;

        public SpeakerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<SpeakerListVm>> GetAll()
        {
            var searchText = Request.Query["q"].ToString();

            var query = new GetSpeakerListQuery
            {
                SearchText = searchText
            };

            var vm = await Mediator.Send(query);
            return Ok(vm.Speakers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakerDetailsVm>> Get(Guid id)
        {
            var query = new GetSpeakerDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateSpeakerDto createSpeakerDto)
        {
            var command = _mapper.Map<CreateSpeakerCommand>(createSpeakerDto);
            var speaker = await Mediator.Send(command);
            return Ok(speaker);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateSpeakerDto updateSpeakerDto)
        {
            var command = _mapper.Map<UpdateSpeakerCommand>(updateSpeakerDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSpeakerCommand
            {
                Id = id
            };
            var vm = await Mediator.Send(command);
            return Ok(new { id = vm.Id  });
        }
    }
}
