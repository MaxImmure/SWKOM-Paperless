namespace PaperlessRestService.BusinessLogic.Entities
{
    public class Permission
    {
        public User[] Users { get; set; }
        public Group[] Groups { get; set; }
    }
}
