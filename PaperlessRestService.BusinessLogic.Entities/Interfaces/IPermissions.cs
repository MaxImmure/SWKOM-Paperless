namespace PaperlessRestService.BusinessLogic.Entities
{
    public interface IPermissions
    {
        User[] Users { get; set; }
        Group[] Groups { get; set; }
    }
}
