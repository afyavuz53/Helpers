using iTextSharp.text.pdf;

namespace Afy
{
    class PdfHelper
    {
        
        /// <summary>
        /// GeneratePdfWithForm
        /// </summary>
        /// <param name="templatePath">Kullanılacak Pdf tepmlate dosya yolu</param>
        /// <param name="outputPdfFilePath">Çıktının kayıt edileceği dosya yolu. Dosya adı ile beraber. Örneğin: C:\...\Example.pdf</param>
        /// <returns></returns>
        public void GeneratePdfWithForm(string templatePath, string outputPdfFilePath)
        {
            using (var reader = new PdfReader(templatePath))
            {
                using (var stamper = new PdfStamper(reader, new FileStream(outputPdfFilePath, FileMode.Create)))
                {
                    stamper.AcroFields.SetField("Given Name Text Box", "Ahmet");
                    stamper.AcroFields.SetField("City Text Box", "İstanbul");

                    stamper.FormFlattening = false;
                    stamper.Writer.SetEncryption(null, null, PdfWriter.ALLOW_PRINTING, PdfWriter.STANDARD_ENCRYPTION_128);
                }
            }
        }
    }
}