namespace Application.Abstraction.Services;

public interface IFileService
{
    Task UploadFile();
    Task DeleteFile();
}
