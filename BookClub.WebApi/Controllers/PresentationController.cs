using AutoMapper;
using BookClub.Application.Presentations.Commands;
using BookClub.Application.Presentations.Queries;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Application.Speakers.Commands;
using BookClub.Application.Speakers.Queries;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using BookClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.WebApi.Controllers
{
    [Route("presentations")]
    public class PresentationController : BaseController
    {
        private readonly IMapper _mapper;

        public PresentationController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PresentationListVm>> GetAll()
        {
            // var searchText = Request.Query["q"].ToString();

            var query = new GetPresentationListQuery { };

            var vm = await Mediator.Send(query);
            return Ok(vm.Presentations);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PresentationDetailsVm>> Get(Guid id)
        {
            var query = new GetPresentationDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<PresentationDetailsVm>> Create([FromBody] CreatePresentationDto createPresentationDto)
        {
            var command = _mapper.Map<CreatePresentationCommand>(createPresentationDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePresentationDto updatePresentationDto)
        {
            var command = _mapper.Map<UpdatePresentationCommand>(updatePresentationDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePresentationCommand
            {
                Id = id
            };
            var vm = await Mediator.Send(command);
            return Ok(new { id = vm.Id });
        }
    }
}
