using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareFinder.API.Data;
using CareFinder.API.DTOs.Hospital;
using AutoMapper;
using CareFinder.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CareFinder.API.Exceptions;
using CareFinder.API.DTOs;
using Microsoft.AspNetCore.OData.Query;
using CsvHelper;
using System.Globalization;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iText.Kernel.Exceptions;
using iText.Layout.Properties;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace CareFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHospitalsRepository _hospitalsRepository;

        public HospitalsController(IMapper mapper, IHospitalsRepository hospitalsRepository)
        {
            this._mapper = mapper;
            this._hospitalsRepository = hospitalsRepository;
        }

        // GET: api/Hospitals
        [HttpGet]
        // [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetHospitalDto>>> GetHospitals()
        {
            var hospitals = await _hospitalsRepository.GetAllHospitalAsync();
            var records = _mapper.Map<List<GetHospitalDto>>(hospitals);
            return Ok(records);
        }

        // GET: api/Hospitals/?StartIndex=0&PageSize=12&PageNumber=1
        // [HttpGet("all")]
        // [EnableQuery]
        // public async Task<ActionResult<IEnumerable<GetHospitalDto>>> GetHospitals([FromQuery] QueryParameters queryParameters)
        // {
        //     var pagedHospitalsResult = await _hospitalsRepository.GetAllAsync<GetHospitalDto>(queryParameters);

        //     return Ok(pagedHospitalsResult);
        // }

        [HttpGet("export")]
        public async Task<IActionResult> ExportCsv()
        {
            var hospitals = await _hospitalsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHospitalDto>>(hospitals);

            if (records == null || records.Count == 0)
                return NoContent();

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }

                return File(memoryStream.ToArray(), "text/csv", "hospitals.csv");
            }
        }

        [HttpGet("share")]
        public async Task<IActionResult> ExportToPdf()
        {
            var hospitals = await _hospitalsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHospitalDto>>(hospitals);

            if (records == null || records.Count == 0)
                return NoContent();

            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                var title = new Paragraph("List of Hospitals")
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetFontSize(20).SetPaddingBottom(20);
                document.Add(title);

                // Add Table Header
                var table = new Table(3);
                table.AddHeaderCell("Number");
                table.AddHeaderCell("Name");
                table.AddHeaderCell("Specialization");
                foreach (var record in records)
                {
                    table.AddCell(record.Id.ToString());
                    table.AddCell(record.Name);
                    table.AddCell(record.Specialization);
                }
                document.Add(table);
                document.Close();

                // Save the PDF to a file or stream
                // return File(stream.ToArray(), "application/pdf", "hospitals.pdf");

                // byte[] pdfBytes = stream.ToArray();

                // // Encode the PDF as a Base64 string
                // string base64Pdf = Convert.ToBase64String(pdfBytes);

                // string downloadLink = $"data:application/pdf;base64,{base64Pdf}";

                // // Email Subject containing the download link
                // string subject = "Download Hospitals PDF";

                // // Email Body
                // string body = "Please find attached the PDF containing the list of hospitals. " +
                //               $"You can also download it directly from the link below:\n\n{downloadLink}";

                // // Prepare the mailto URI
                // string mailtoUri = $"mailto:?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

                // // Redirect to the mailto URI
                // return Redirect(mailtoUri);

                // string fileName = $"hospitals_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                // var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", fileName);
                // System.IO.File.WriteAllBytes(filePath, stream.ToArray());

                // // Generate shareable link
                // string url = $"{Request.Scheme}://{Request.Host}/pdfs/{fileName}";
                // return Ok(url);

                // Save the PDF to a temporary location
                var pdfFileName = $"hospitals.pdf";
                var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", pdfFileName);
                System.IO.File.WriteAllBytes(pdfFilePath, stream.ToArray());

                var downloadLink = Url.Action("DownloadPdf", "Pdf", new { fileName = pdfFileName });
                return Content($"PDF generated. <a href='{downloadLink}'>Download</a>");

                // Generate the shareable link
                // var baseUrl = $"{Request.Scheme}://{Request.Host}";
                // var shareableLink = $"{baseUrl}/api/Hospitals/share/hospitals";

                // return Ok(new { ShareableLink = shareableLink });
            }
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHospitalDto>> GetHospital(int id)
        {
            var hospital = await _hospitalsRepository.GetDetails(id);

            if (hospital is null)
            {
                throw new NotFoundException(nameof(GetHospitals), id);
            }
            var hospitalDto = _mapper.Map<GetHospitalDetailsDto>(hospital);
            return Ok(hospitalDto);
        }

        // POST: api/Hospitals
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Hospital>> PostHospital(CreateHospitalDto createHospital)
        {
            if (await _hospitalsRepository.ExistsByNameAsync(createHospital.Name))
            {
                ModelState.AddModelError(createHospital.Name, "Hospital with this name already exists");
                return BadRequest(ModelState);
            }

            var hospital = _mapper.Map<Hospital>(createHospital);

            await _hospitalsRepository.AddAsync(hospital);

            Console.WriteLine(hospital.Id);
            Console.WriteLine("Add something");

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital);
        }

        // PUT: api/Hospitals/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PutHospital(int id, UpdateHospitalDto updateHospitalDto)
        {
            if (id != updateHospitalDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var hospital = await _hospitalsRepository.GetAsync(id);

            if (hospital == null)
            {
                throw new NotFoundException(nameof(PutHospital), id);
            }
            _mapper.Map(updateHospitalDto, hospital);

            try
            {
                await _hospitalsRepository.UpdateAsync(hospital);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HospitalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Hospitals/5 
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await _hospitalsRepository.GetAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            await _hospitalsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HospitalExists(int id)
        {
            return await _hospitalsRepository.Exists(id);
        }
    }
}
