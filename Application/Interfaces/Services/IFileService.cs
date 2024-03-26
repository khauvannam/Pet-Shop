namespace Application.Interfaces.Services;

public interface IFileService
{
    Task UploadFile();
    Task DeleteFile();
}
