using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Admin.Models;
using Dream.Logger;
using System.IO;
using System.Text;
using Dream.Util;
using System.Data;
using Dream.Model;
using Newtonsoft.Json;
using Dream.Model.Api;

namespace Dream.Admin.Controllers
{
    public class DataProcessController : Controller
    {

        private ILog _logger;
        private string _processApiUrl = $"{ConfigUtil.GetConfig<AppSettings>("AppSettings").DataServer}/dream/order";
        public DataProcessController(ILog l)
        {
            _logger = l;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Import()
        {
            try
            {
                var fileToProcess = Request.Form.Files.FirstOrDefault();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles", DateTime.Now.ToString("yyyyMMdd"), fileToProcess.FileName);
                var fileDirectory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);
                if (fileToProcess != null && fileToProcess.Length > 0)
                {
                    using (var inputStream = new FileStream(filePath, FileMode.Create))
                    {
                        // read file to stream
                        await fileToProcess.CopyToAsync(inputStream);
                    }
                    DataTable dtBackData = ExcelHelper.Import(filePath);
                    var orders = OrderInfo.FromDataTable(dtBackData);
                    orders.ForEach(async order =>
                    {
                        var orderJson = JsonConvert.SerializeObject(order);
                        var orderBytes = Encoding.UTF8.GetBytes(orderJson);
                        await RequestUtil.DoRequestWithBytesPostDataAsync(_processApiUrl, "post", "application/json", 60 * 1000, 60 * 1000 * 3, orderBytes);
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
