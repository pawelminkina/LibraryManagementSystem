using LibraryManagementSystem.Application.Commands.UploadBookDocument;
using LibraryManagementSystem.Application.Commands.UploadBookFile;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Application.Queries.AvailableBooks;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailableBooks()
    {
        var query = new AvailableBooksQuery();

        var res = await _mediator.Send(query);

        if (!res.Any())
            return NotFound();

        return Ok(res);
    }

    [HttpPost("File")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        var fileName = await _mediator.Send(new UploadBookFileCommand(file.OpenReadStream(), extension));

        return Ok(fileName);
    }

    [HttpPost("Document")]
    public async Task<IActionResult> UploadDocument(IFormFile file)
    {
        var name = await _mediator.Send(new UploadBookDocumentCommand(file.OpenReadStream()));

        return Ok(name);
    }
}
