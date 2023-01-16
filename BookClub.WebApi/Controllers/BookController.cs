using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.Queries;
using BookClub.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAll()
        {
            var query = new GetBookListQuery
            {
                Id = 1
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsVm>> Get(int id)
        {
            var query = new GetBookDetailsQuery 
            { 
                Id = id 
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var Id = await Mediator.Send(command);
            return Ok(Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
