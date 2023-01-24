using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.Queries;
using BookClub.Application.Books.ViewModels;
using BookClub.Domains;
using BookClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookClub.WebApi.Controllers
{
    [Route("books")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAll()
        {
            var searchText = Request.Query["q"].ToString();
            var tag = Request.Query["tags_like"].ToString();
            
            var query = new GetBookListQuery
            {
                SearchText = searchText,
                Tag = tag
            };

            var vm = await Mediator.Send(query);
            return Ok(vm.Books);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsVm>> Get(Guid id)
        {
            var query = new GetBookDetailsQuery 
            { 
                Id = id 
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var book = await Mediator.Send(command);
            return Ok(book);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}
