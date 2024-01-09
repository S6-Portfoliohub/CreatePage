using Azure.Storage.Blobs;
using System.Text;
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace FileUploadLayer
{
    public class FileDAO
    {
        string _containerName = "photos";
        private readonly BlobContainerClient _containerClient;
        public FileDAO(IOptions<BlobSettings> blobsettings)
        {
            _containerClient = new BlobContainerClient(blobsettings.Value.ConnectionString, _containerName);
            _containerClient.CreateIfNotExists();
        }

        public void UploadFile()
        {
            string blobName = "docs-and-friends-selfie-stick.png";
            string fileName = "docs-and-friends-selfie-stick.png";

            BlobClient blobClient = _containerClient.GetBlobClient(blobName);
            blobClient.Upload(fileName, true);
        }
    }
}
