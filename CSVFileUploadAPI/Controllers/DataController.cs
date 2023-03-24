using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVFileUploadAPI.Data;
using CSVFileUploadAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSVFileUploadAPI.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly ApiContext _context;

        public DataController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostFile(int fileId, IFormFile file)
        {

            var fileData = new FileData()
            {
                FileDataId = fileId,
                FileName = file.FileName
            };

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                var byteArray = stream.ToArray();
                fileData.Data = Encoding.ASCII.GetString(byteArray);
            }

            _context.fileDatas.Add(fileData);
            await _context.SaveChangesAsync();
            return Ok(_context.fileDatas.Find(fileId));
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAllData()
        {
            List<string> DataList = new List<string>();
            if (!_context.fileDatas.Any())
                return BadRequest(DataList);

            foreach (var item in _context.fileDatas)
            {
                string data = "";
                data += item.FileDataId + " " + item.FileName + "";
                data += item.Data.Remove(item.Data.FirstOrDefault('\n'));
                DataList.Add(data);
            }
            return Ok(DataList);
        }
    }
}

