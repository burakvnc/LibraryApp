using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Features.CQRS.Commands.AuthorCommands;
using LibraryApp.Features.CQRS.Queries.AuthorQueries;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(AuthorCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAuthorById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAuthor(int id)
        {
            var command = new AuthorDeleteCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, AuthorUpdateCommand command)
        {
            if (id != command.Id) return BadRequest();

            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var query = new GetAuthorByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var query = new GetAuthorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
