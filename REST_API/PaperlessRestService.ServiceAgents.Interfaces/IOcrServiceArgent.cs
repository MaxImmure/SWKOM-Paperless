namespace PaperlessRestService.ServiceAgents.Interfaces.OCRLibrary;

public interface IOcrServiceArgent
{
    string OcrPdf(Stream pdfStream);
}
