namespace IVCRM.BLL.Services.Interfaces
{
    public interface IPictureService
    {
        Task<string> UploadPictureAsync(string containerName, string fileName, Stream pictureStream);
        Task DeletePictureAsync(string containerName, string fileName);
    }
}
