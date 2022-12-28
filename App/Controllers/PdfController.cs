using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using BLL.Services;
using iText.Html2pdf;

namespace App.Controllers
{
    public class PdfController : ApiController
    {
        [HttpGet]
        [Route("api/pdf")]
        public HttpResponseMessage Logout()
        {
            return Request.CreateErrorResponse(HttpStatusCode.OK, GeneratePdf());
        }

        public string GeneratePdf()
        {
            try
            {
                var html = @"<!DOCTYPE html><html><head> <meta charset=""utf-8""/> <title></title></head><body><h1>Hello World</h1><h2>Hello!</h2></body></html>";

                var mapPath = HostingEnvironment.MapPath("~\\PDF\\");
                var filename = System.Guid.NewGuid().ToString();
                var pdfPath = mapPath + filename + ".pdf";
                var serverPdfPath = "https://localhost:44373/PDF/" + filename + ".pdf";

                CreatePdf("https://localhost:44373", html, pdfPath);

                return serverPdfPath;
            } catch
            {
                return null;
            }
        }

        public void CreatePdf(string baseUri, string html, string destination)
        {
            try
            {
                var prop = new ConverterProperties();
                prop.SetBaseUri(baseUri);
                HtmlConverter.ConvertToPdf(html, new FileStream(destination, FileMode.Create), prop);
            } catch
            {
                // ignored
            }
        }
    }
}
