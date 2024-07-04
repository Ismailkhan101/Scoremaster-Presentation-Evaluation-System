using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Diagnostics;
using System.IO;

public class PDFGenerator
{
    public void GeneratePDF(string htmlContent)
    {
        // Generate a unique file name for the PDF
        string fileName = $"GeneratedPDF_{DateTime.Now:yyyyMMddHHmmss}.pdf";

        // Construct the full output path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "GeneratedPDFs", fileName);

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a new PDF document
        PdfDocument document = new PdfDocument();

        // Add a page to the document
        PdfPage page = document.AddPage();

        // Create a PDF graphics object from the page
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Create a font (Times New Roman, size 12)
        XFont font = new XFont("Times New Roman", 12);

        // Draw the HTML content on the PDF
        gfx.DrawString(htmlContent, font, XBrushes.Black,
            new XRect(40, 40, page.Width - 80, page.Height - 80),
            XStringFormats.TopLeft);

        // Save the document to the specified output path
        document.Save(outputPath);

        // Optionally, open the PDF file after saving
        Process.Start(outputPath);
    }
}
