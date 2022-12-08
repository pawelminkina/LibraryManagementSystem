namespace LibraryManagementSystem.Application.Services.Files;

public interface IFileService
{
    Task UploadFile(Stream content, string filename);
}