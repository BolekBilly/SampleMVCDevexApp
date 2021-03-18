using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using SampleMVCDevexApp.Models;
using System.Linq.Expressions;
//using OfficeOpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace SampleMVCDevexApp.Controllers
{

    [Route("api/[controller]")]
    public class GenerateElController : Controller
    {

        SamplemvcContext DbContext;
        public GenerateElController(SamplemvcContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public object GetTestData(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(DbContext.TestTable, loadOptions);
        }

        [HttpPost]
        public IActionResult Generate(string values)
        {
            var item = new ElObject();
            JsonConvert.PopulateObject(values, item);

            if (!TryValidateModel(item))
                return BadRequest("error");

            // TODO: Magia generatora Wordów....

            // - pobranie plików Word
            DateTime now = DateTime.Now;
            string dirPathRead = @"C:\Users\bmuzalewski\Desktop\PROJEKTY\000AppEL\ELdocs\"; //Settings.App.getSettingParameterValue("TEMPLATE_DIR", DbContext);
            string dirPathWrite = @"C:\Users\bmuzalewski\Desktop\PROJEKTY\000AppEL\ELdocsResults\"; //Settings.App.getSettingParameterValue("GEN_DECL_DIR", DbContext);
            
            string readPathEl = dirPathRead + "\\" + item.ElName + "_" + item.Language + ".docx";
            string readPathOWU = dirPathRead + "\\" + "OWU_" + item.Language + ".docx";
            string readPathRodo = dirPathRead + "\\" + "RODO_" + item.Language + ".docx";

            string writePath = dirPathWrite + "\\" + item.FileName + "_" + now.ToString("dd-MM-yyyy");

            // Open a WordprocessingDocument for editing using the filepath.
            //var wordDoc = WordprocessingDocument.Open(readPathEl, true);

            string strTxt = "Append text in body - OpenAndAddTextToWordDocument - " + item.ElName + " Hahaha!!!";
            OpenAndAddTextToWordDocument(readPathEl, strTxt);

            // przetłumaczyć kod VBA na C#

            // - wyplucie wypełnionej deklracji


            return Content("OK: " + item.ElName);
        }
        public static void OpenAndAddTextToWordDocument(string filepath, string txt)
        {
            // Open a WordprocessingDocument for editing using the filepath.
            var wordprocessingDocument =  WordprocessingDocument.Open(filepath, true);

            // Assign a reference to the existing document body.
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            // Add new text.
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(txt));

            // Close the handle explicitly.
            wordprocessingDocument.Close();
        }
    }
}