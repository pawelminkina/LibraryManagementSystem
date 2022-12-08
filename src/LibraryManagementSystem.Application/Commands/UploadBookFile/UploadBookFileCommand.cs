using LibraryManagementSystem.Application.Services.Files;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.UploadBookFile;

//used for azure emulators presentation
public class UploadBookFileCommand : IRequest
{
    public Stream Content { get; }
    public string Name { get; }

    public UploadBookFileCommand(Stream content, string name)
    {
        Content = content;
        Name = name;
    }
}

public class UploadBookFileCommandHandler : IRequestHandler<UploadBookFileCommand>
{
    private readonly IFileService _fileService;

    public UploadBookFileCommandHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    public async Task<Unit> Handle(UploadBookFileCommand request, CancellationToken cancellationToken)
    {
        await _fileService.UploadFile(request.Content, request.Name);
        
        return Unit.Value;
    }
}