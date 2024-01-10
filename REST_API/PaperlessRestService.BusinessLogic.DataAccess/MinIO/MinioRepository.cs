using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.MinIO
{
    public class MinioRepository : IMinioRepository
    {
        private readonly IMinioClient _minioClient;
        private readonly string _bucketName;

        public MinioRepository(MinioOptions options)
        {
            _minioClient = new MinioClient().WithEndpoint(options.Endpoint).WithCredentials(options.AccessKey, options.SecretKey).Build();
            _bucketName = options.BucketName;

            var beArgs = new BucketExistsArgs()
                .WithBucket(options.BucketName);
            bool found = _minioClient.BucketExistsAsync(beArgs).Result;
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(options.BucketName);
                _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }
        }

        public async Task UploadFileAsync(Stream fileStream, string filePath)
        {
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithStreamData(fileStream)
                .WithObject(filePath)
                .WithObjectSize(fileStream.Length);

            await _minioClient.PutObjectAsync(putObjectArgs);
        }

        public async Task<Stream> GetFileAsync(string filePath)
        {
            var memoryStream = new MemoryStream();
            var getObjectArgs = new GetObjectArgs().WithBucket(_bucketName).WithObject(filePath)
                .WithCallbackStream((stream) => stream.CopyTo(memoryStream));
            await _minioClient.GetObjectAsync(getObjectArgs);

            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var removeObjectArgs = new RemoveObjectArgs().WithBucket(_bucketName).WithObject(filePath);
            await _minioClient.RemoveObjectAsync(removeObjectArgs);
        }

        public async Task<bool> FileExistsAsync(string filePath)
        {
            var statObjectArgs = new StatObjectArgs().WithBucket(_bucketName).WithObject(filePath);
            var result = await _minioClient.StatObjectAsync(statObjectArgs);

            return result != null;
        }
    }
}
