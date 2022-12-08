namespace LibraryManagementSystem.Application.Services.Files;

public interface IFileService
{
    Task<string> UploadFile(Stream content, string extension);
}