using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;

namespace Majestim._TestObjectListView
{
    /// <summary>
    /// This sample is the obligatory Hello World program.
    /// </summary>
    class PdfTest
    {
        public void Run()
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);

            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        public void Read()
        {
            PdfDocument PDFDoc = PdfReader.Open(@"HelloWorld.pdf", PdfDocumentOpenMode.Import);
            PdfDocument PDFNewDoc = new PdfDocument();
            for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
            {
                PdfPage np = PDFNewDoc.AddPage(PDFDoc.Pages[Pg]);

                XGraphics gfx = XGraphics.FromPdfPage(np);
                XFont font = new XFont("Arial", 10, XFontStyle.Regular);
                gfx.DrawString("Fabrice AUdouard ... !!!", font, XBrushes.Black, new XRect(0, 0, np.Width, np.Height),
                    XStringFormats.BottomCenter);
            }
            PDFNewDoc.Save(@"HelloWorld3.pdf");

            // ...and start a viewer.
            Process.Start(@"HelloWorld3.pdf");
        }

        public void DrawArray()
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created by fabrice";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            for (int x = 0; x < 5; x++)
            {
                var X = 80 + x * 90;

                for (int y = 0; y < 20; y++)
                {
                    var Y = 20 + y * 20;

                    // Create a font
                    XFont font = new XFont("Verdana", 8);
                    XRect rect = new XRect(X,Y, 100, 20);

                    // Draw the text
                    gfx.DrawString(
                        $"X={X},Y={Y}", 
                        font, 
                        XBrushes.Black,
                        rect,
                        XStringFormats.Center);

                    gfx.DrawLine(XPens.DarkGreen, X, Y, X + 100, Y);
                    gfx.DrawLine(XPens.DarkGreen, X, Y, X, Y + 20);
                }
                //gfx.DrawLine(XPens.DarkGreen, X+100, Y, X, Y + 20);
            }
            //gfx.DrawLine(XPens.DarkGreen, 80 + x * 90, Y, 80 + x * 90 + 100, Y);


            // Save the document...
            const string filename = "array.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);

        }
    }
}