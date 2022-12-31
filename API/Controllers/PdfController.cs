using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Auth;
using BLL.DTOs;
using BLL.Services;
using iText.Html2pdf;

namespace API.Controllers
{
    /*[LoggedIn]*/
    [EnableCors("*", "*", "*")]
    public class PdfController : ApiController
    {
        [HttpGet]
        [Route("api/pdf")]
        public HttpResponseMessage Pdf()
        {
            var pdf = GeneratePdf();
            return Request.CreateErrorResponse(HttpStatusCode.OK, pdf);
        }

        public string GeneratePdf()
        {
            try
            {
                var trip = TripService.GetAll().Last();

                var html = $@"
                        <!DOCTYPE html>
                        <html lang='en'>
                        <head>
                            <meta charset='UTF-8'>
                            <title>Title</title>
                        </head>
                        <body>
                        <h1 style='text-align: center'>Wise Trips</h1>
                        <h2>Trip Details</h2>
                        <p><b>Username: </b> {UserService.Get(trip.UserId).Username}</p>
                        <p><b>Package Name: </b>{PackageService.Get(trip.PackageId).Name}</p>
                        <p><b>Package Details: </b>{PackageService.Get(trip.PackageId).Details}</p>
                        <p><b>Hotel Name: </b>{HotelService.Get(trip.HotelId).Name}</p>
                        <p><b>Hotel Details: </b>{HotelService.Get(trip.HotelId).Description}</p>
                        <p><b>Total Persons: </b>{trip.Persons}</p>
                        <p><b>Date: </b>{trip.Date}</p>
                        <p><b>Total Paid: </b>${trip.Paid}</p>
                        </body>
                        </html>";

                var mapPath = HostingEnvironment.MapPath("~\\PDF\\");
                /*var filename = System.Guid.NewGuid().ToString().Substring(0, 5);*/
                var filename = UserService.Get(trip.UserId).Username + "_" + trip.Date.ToString("yyyy-MM-dd_HH-mm-ss");
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
