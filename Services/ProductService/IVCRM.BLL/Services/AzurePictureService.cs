using IVCRM.BLL.Services.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace IVCRM.BLL.Services
{
    public class AzurePictureService : IPictureService
    {
        private readonly CloudBlobClient _blobClient;

        public AzurePictureService(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<CloudBlobContainer> GetContainerAsync(string containerName)
        {
            var container = _blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            return container;
        }

        public async Task<string> UploadPictureAsync(string containerName, string fileName, Stream pictureStream)
        {
            var container = await GetContainerAsync(containerName);
            var pictureBlob = container.GetBlockBlobReference(fileName);
            await pictureBlob.UploadFromStreamAsync(pictureStream);

            return pictureBlob.Uri.ToString();
        }

        public async Task DeletePictureAsync(string containerName, string fileName)
        {
            var container = await GetContainerAsync(containerName);
            var pictureBlob = container.GetBlockBlobReference(fileName);
            await pictureBlob.DeleteAsync();
        }
    }
}
