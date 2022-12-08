using LibraryManagementSystem.Application.Commands.AddLibrary;
using LibraryManagementSystem.Application.Commands.UpdateBook;
using LibraryManagementSystem.Application.Commands.UploadBookDocument;
using LibraryManagementSystem.Application.Commands.UploadBookFile;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Application.Queries.BooksFromSelectedLibraries;
using LibraryManagementSystem.Application.Queries.PagesFromLibraryGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers;

[Route("api/main")]
public class MainController : ControllerBase
{
    private readonly IMediator _mediator;

    public MainController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Method used to retrieve books in selected libraries combined in collection of titles
    /// <param name="titleStartsWith">This is filter for returning only books which starts with that value, it's optional</param>
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksForFixedLibraries([FromQuery] string titleStartsWith)
    {
        var query = new BooksFromSelectedLibrariesQuery(titleStartsWith, GetFixedLibraryIds());

        var res = await _mediator.Send(query);

        if (!res.Any())
            return NotFound();

        return Ok(res);
    }

    [HttpGet("BooksFromLibraryGroup")]
    public async Task<ActionResult<BooksFromLibraryGroupQueryDto>> GetBooksFromLibraryGroup([FromQuery] Guid groupId)
    {
        return Ok(await _mediator.Send(new BooksFromLibraryGroupQuery(groupId)));
    }

    [HttpPost]
    public async Task<IActionResult> AddLibrary([FromBody] AddLibraryCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("File")]
    public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string fileName)
    {
        await _mediator.Send(new UploadBookFileCommand(file.OpenReadStream(), fileName));

        return NoContent();
    }

    [HttpPost("Document")]
    public async Task<IActionResult> UploadDocument(IFormFile file)
    {
        var name = await _mediator.Send(new UploadBookDocumentCommand(file.OpenReadStream()));

        return Ok(name);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    private static IEnumerable<Guid> GetFixedLibraryIds() => new[]
    {
            Guid.Parse("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
            Guid.Parse("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
            Guid.Parse("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea")
    };
}
