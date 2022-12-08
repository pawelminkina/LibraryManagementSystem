using LibraryManagementSystem.Application.Services.Files;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.UploadBookFile;

//used for azure emulators presentation
public class UploadBookFileCommand : IRequest<string>
{
    public Stream Content { get; }
    public string Extension { get; }

    public UploadBookFileCommand(Stream content, string extension)
    {
        Content = content;
        Extension = extension;
    }
}

public class UploadBookFileCommandHandler : IRequestHandler<UploadBookFileCommand, string>
{
    private readonly IFileService _fileService;

    public UploadBookFileCommandHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    public async Task<string> Handle(UploadBookFileCommand request, CancellationToken cancellationToken)
    {
        var fileName = await _fileService.UploadFile(request.Content, request.Extension);
        
        return fileName;
    }
}