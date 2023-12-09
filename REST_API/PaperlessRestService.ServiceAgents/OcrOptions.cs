using System;

namespace PaperlessRestService.ServiceAgents.OCRLibrary;

public class OcrOptions
{
    public const string OCR = "OCR";

    public string Language { get; set; } = "eng";
    public string TessDataPath { get; set; } = "./tessdata";
}