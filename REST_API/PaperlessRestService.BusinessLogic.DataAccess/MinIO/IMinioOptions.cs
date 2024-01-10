namespace PaperlessRestService.BusinessLogic.DataAccess.MinIO;

public interface IMinioOptions
{
    public string Endpoint { get; set; }
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string BucketName { get; set; }
}