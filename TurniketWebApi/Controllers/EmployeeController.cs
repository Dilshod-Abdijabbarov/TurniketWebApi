using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;
using TurniketWebApi.Service.IServices;
using Xceed.Words.NET;
using System.Diagnostics;
using Xceed.Document.NET;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TurniketWebApi.Service.Exceptions;

namespace TurniketWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeService = employeeService;
            this.webHostEnvironment = webHostEnvironment;

        }

        [HttpGet("{JSHSHIR} DownloadFile")]
        public async ValueTask<IActionResult> DownloadFile([FromRoute] ulong JSHSHIR)
        {
            var employee = await employeeService.GetAsync(c => c.JSHSHIR == JSHSHIR);

            string path = webHostEnvironment.ContentRootPath;
            string imagePath = path + "Images//" + employee.Image + ".png";
            string FileName = "Document.docx";

            var doc = DocX.Create(FileName);

            if (System.IO.File.Exists(imagePath))
            {
                Xceed.Document.NET.Image img = doc.AddImage(imagePath);
                Picture p = img.CreatePicture();
                Paragraph par = doc.InsertParagraph($"Picture of {employee.Image} =>");
                par.AppendPicture(p);
            }
            Table t = doc.AddTable(2, 8);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulList;

            t.Rows[0].Cells[0].Paragraphs.First().Append("JSHSHIR");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Full Name");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Phone Number");
            t.Rows[0].Cells[3].Paragraphs.First().Append("Position");
            t.Rows[0].Cells[4].Paragraphs.First().Append("Description");
            t.Rows[0].Cells[5].Paragraphs.First().Append("Picture");
            t.Rows[0].Cells[6].Paragraphs.First().Append("Access Time");
            t.Rows[0].Cells[7].Paragraphs.First().Append("Exit Time");

            t.Rows[1].Cells[0].Paragraphs.First().Append(employee.JSHSHIR.ToString());
            t.Rows[1].Cells[1].Paragraphs.First().Append(employee.LastName + " " + employee.FirstName);
            t.Rows[1].Cells[2].Paragraphs.First().Append(employee.PhoneNumber);
            t.Rows[1].Cells[3].Paragraphs.First().Append(employee.Position);
            t.Rows[1].Cells[4].Paragraphs.First().Append(employee.Description);
            t.Rows[1].Cells[5].Paragraphs.First().Append(employee.Image);

            foreach (var item in employee.Registrations)
            {
                t.Rows[1].Cells[6].Paragraphs.First().Append(item.AccessTime.ToString() + "\n");
                t.Rows[1].Cells[7].Paragraphs.First().Append(item.ExitTime.ToString() + "\n");
            }

            doc.InsertTable(t);
            doc.Save();

            var pat = Path.Combine(Directory.GetCurrentDirectory(), FileName);
            var stream = new FileStream(pat, FileMode.Open);

            return File(stream, "application/octet-stream", FileName);
        }


        [HttpGet("{JSHSHIR} GetEmployee")]
        public async ValueTask<IActionResult> GetById([FromRoute] ulong JSHSHIR)
        {
            return Ok(await employeeService.GetAsync(c => c.JSHSHIR == JSHSHIR));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
           Ok(await employeeService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] EmployeeForCreationDTO employeeForCreation) =>
           Ok(await employeeService.CreateAsync(employeeForCreation));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] ulong JSHSHIR,
                   [FromBody] EmployeeForCreationDTO employeeForCreation) =>
          Ok(await employeeService.UpdateAsync(JSHSHIR, employeeForCreation));

        [HttpDelete("{JSHSHIR}")]
        public async ValueTask<IActionResult> Delete([FromRoute] ulong JSHSHIR) =>
          Ok(await employeeService.DeleteAsync(JSHSHIR));
    }
}
