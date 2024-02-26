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
        [HttpGet("all")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetHospitalDto>>> GetHospitals()
        {
            var hospitals = await _hospitalsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHospitalDto>>(hospitals);
            return Ok(records);
        }

        // GET: api/Countries/?StartIndex=0&PageSize=12&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHospitalDto>>> GetHospitals([FromQuery] QueryParameters queryParameters)
        {
            var pagedHospitalsResult = await _hospitalsRepository.GetAllAsync<GetHospitalDto>(queryParameters);

            return Ok(pagedHospitalsResult);
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
        // [Authorize(Roles = "Administrator")]
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

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital.Id);
        }

        // PUT: api/Hospitals/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
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

        // DELETE: api/Hospitals/5 [HttpDelete("{id}")] [Authorize(Roles = "Administrator")]
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
