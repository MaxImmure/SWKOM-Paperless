namespace PaperlessRestService.BusinessLogic.Entities
{
    public class Correspondents
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }

        public string Match { get; set; }
        public int MatchingAlgorithm { get; set; }
        public bool IsInsensitive { get; set; }

        public Correspondents LastCorrespondents { get; set; }
        public int Owner { get; set; }

        public Permission View { get; set; }
        public Permission Change { get; set; }

    }
}