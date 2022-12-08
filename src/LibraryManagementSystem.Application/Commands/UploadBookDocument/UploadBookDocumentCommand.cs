using LibraryManagementSystem.Application.Services.Documents;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.UploadBookDocument;

//used for azure emulators presentation
public class UploadBookDocumentCommand : IRequest<string>
{
    public Stream Document { get; }

    public UploadBookDocumentCommand(Stream document)
    {
        Document = document;
    }
}

public class UploadBookDocumentCommandHandler : IRequestHandler<UploadBookDocumentCommand, string>
{
    private readonly IBookDocumentService _service;

    public UploadBookDocumentCommandHandler(IBookDocumentService service)
    {
        _service = service;
    }
    public async Task<string> Handle(UploadBookDocumentCommand request, CancellationToken cancellationToken)
    {
        var name = Guid.NewGuid().ToString();
        await _service.UploadDocumentAsStream(request.Document, name);

        return name;
    }
}