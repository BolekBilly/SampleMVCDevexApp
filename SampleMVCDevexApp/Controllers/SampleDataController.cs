using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using SampleMVCDevexApp.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace SampleMVCDevexApp.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        SamplemvcContext DbContext;
        public SampleDataController(SamplemvcContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public object GetTestData(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(DbContext.TestTable, loadOptions);
        }

        public object GetTreeList(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(DbContext.TestTable, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertTestData(string values)
        {
            var item = new TestTable();
            JsonConvert.PopulateObject(values, item);

            if (!TryValidateModel(item))
                return BadRequest("error");

            DbContext.TestTable.Add(item);
            DbContext.SaveChanges();
            return Ok();
        }
        public IActionResult InsertTreeList(string values)
        {
            var item = new TestTable();
            JsonConvert.PopulateObject(values, item);

            if (!TryValidateModel(item))
                return BadRequest("error");

            DbContext.TestTable.Add(item);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTestData(string key, string values)
        {
            var item = DbContext.TestTable.First(a => a.Id == key);
            JsonConvert.PopulateObject(values, item);

            if (!TryValidateModel(item))
                return BadRequest("Error");// ModelState.GetFullErrorMessage());

            DbContext.SaveChanges();
            return Ok();
        }
        public IActionResult UpdateTreeList(string key, string values)
        {
            var item = DbContext.TestTable.First(a => a.Id == key); //String.Compare(key, a.Id, StringComparison.OrdinalIgnoreCase));
            JsonConvert.PopulateObject(values, item);

            if (!TryValidateModel(item))
                return BadRequest("Error");// ModelState.GetFullErrorMessage());

            DbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTestData(string key)
        {
            var item = DbContext.TestTable.First(a => a.Id == key);

            if (!TryValidateModel(item))
                return BadRequest("Error");// ModelState.GetFullErrorMessage());

            DbContext.TestTable.Remove(item);
            DbContext.SaveChanges();
            return Ok();
        }

        public IActionResult DeleteTreeList(string key)
        {
            var item = DbContext.TestTable.First(a => a.Id == key);

            if (!TryValidateModel(item))
                return BadRequest("Error");// ModelState.GetFullErrorMessage());

            DbContext.TestTable.Remove(item);
            DbContext.SaveChanges();
            return Ok();
        }


    }
}