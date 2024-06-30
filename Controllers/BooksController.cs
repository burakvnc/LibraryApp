using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Features.CQRS.Commands.BookCommands;
using LibraryApp.Features.CQRS.Queries.BookQueries;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBook(int id)
        {
            var command = new BookDeleteCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, BookUpdateCommand command)
        {
            if (id != command.Id) return BadRequest();

            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var query = new GetBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
