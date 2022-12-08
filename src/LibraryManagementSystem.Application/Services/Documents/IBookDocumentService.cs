namespace LibraryManagementSystem.Application.Services.Documents;

public interface IBookDocumentService
{
    Task UploadDocumentAsStream(Stream document, string name);
}