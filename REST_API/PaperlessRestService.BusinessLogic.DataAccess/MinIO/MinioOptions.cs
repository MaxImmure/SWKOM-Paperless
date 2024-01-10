using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.MinIO
{
    public class MinioOptions : IMinioOptions
    {
        public string Endpoint { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public MinioOptions(string endpoint, string accessKey, string secretKey, string bucketName)
        {
            Endpoint = endpoint;
            AccessKey = accessKey;
            SecretKey = secretKey;
            BucketName = bucketName;
        }
    }
}
