namespace PaperlessRestService.ServiceAgents.Interfaces
{
    public class QueueReceivedEventArgs
    {
        public string Content { get; }
        public Guid MessageId { get; }

        public QueueReceivedEventArgs(string content, Guid documentId)
        {
            Content = content;
            MessageId = documentId;
        }
    }
}