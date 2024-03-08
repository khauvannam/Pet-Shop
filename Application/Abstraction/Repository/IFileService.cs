namespace Application.Abstraction.Repository;

public interface IFileService
{
    Task UploadFile();
    Task DeleteFile();
}
