using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models;
using DocumentFormat.OpenXml.Packaging;
using System.Diagnostics;

namespace Veterinaria.Controllers
{
    class DocumentoController
    {
        //[POST]
        #region snippet_ Write
        public void Write(Documento documento)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(documento.GetRuta, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                docText = docText.Replace(documento.GetCadenaInicial, documento.GetCadenaFinal);

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
        #endregion

        #region snippet_Generate
        public string Generate(int id, string folder, string nombreArchivo)
        {
            var rutaInicial = @"..\..\Resources\Templates\" + nombreArchivo + ".docx";
            var rutaDestino = @"..\..\Resources\" + folder + "\\" + id + ".docx";

            File.Copy(rutaInicial, rutaDestino, true);

            return rutaDestino;
        }
        #endregion

        //[GET]
        #region snippet_Print
        public void Print(int id, string folder)
        {
            var rutaDestino = @"..\..\Resources\" + folder +"\\" + id + ".docx";

            ProcessStartInfo info = new ProcessStartInfo(rutaDestino);
            info.Verb = "Print";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(info);
        }
        #endregion
    }
}
