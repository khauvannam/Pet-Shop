namespace Application.Abstraction;

public interface IFileService
{
    Task UploadFile();
    Task DeleteFile();
}
