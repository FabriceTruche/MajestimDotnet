using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Majestim._TestObjectListView
{
    public class PdfDDL
    {
        private const string _file =
                @"C:\Users\Fabrice\Dropbox\Fabrice\Seyssins\Baux\Doc\QUITTANCE_2019_novembre - Mr Jean Claude CALISE (9).pdf"
            ;

        public void _Run()
        {
            string ddl = @"
\document
{
  \section
  {
    \paragraph
    {
      Hello, World!
    }
    \paragraph
    {
      Hello, World! sdfsfssd
    }
  }
}";
            Document doc = DdlReader.DocumentFromString(ddl);

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = doc;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            const string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);

        }

        public void Run()
        {
            PdfDocument pdf = PdfReader.Open(_file, PdfDocumentOpenMode.Modify);
            DdlWriter ddlw = new DdlWriter("toto.txt");
            PdfDocumentRenderer render = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            //Document doc = new Document();

            render.PdfDocument = pdf;
            //render.Document = doc;
            render.RenderDocument();
            //render.WriteDocumentInformation();
            //ddlw.WriteDocument(doc);
            render.Save("titi.pdf");
            ddlw.Close();
        }
    }
}