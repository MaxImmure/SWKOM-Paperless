namespace PaperlessRestService.ServiceAgents.Interfaces.OCRLibrary;

public interface IOcrClient
{
    string OcrPdf(Stream pdfStream);
}
