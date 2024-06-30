using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Features.CQRS.Commands.LibraryCommands;
using LibraryApp.Features.CQRS.Queries.LibraryQueries;
using LibraryApp.DTOs;


namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly IMediator _mediator;

        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<LibraryDto>> PostLibrary(LibraryCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLibraryById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteLibrary(int id)
        {
            var command = new LibraryDeleteCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibraryDto>> UpdateLibrary(int id, LibraryUpdateCommand command)
        {
            if (id != command.Id) return BadRequest();

            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> GetLibraryById(int id)
        {
            var query = new GetLibraryByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryDto>>> GetLibraries()
        {
            var query = new GetLibrariesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{libraryId}/books/{bookId}")]
        public async Task<ActionResult<bool>> RemoveBookFromLibrary(int libraryId, int bookId)
        {
            var command = new RemoveBookFromLibraryCommand
            {
                LibraryId = libraryId,
                BookId = bookId
            };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpPost("{libraryId}/books/{bookId}")]
        public async Task<ActionResult<bool>> AddBookToLibrary(int libraryId, int bookId)
        {
            var command = new AddBookToLibraryCommand
            {
                LibraryId = libraryId,
                BookId = bookId
            };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }
    }
}
