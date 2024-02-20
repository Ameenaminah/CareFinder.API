using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareFinder.API.Data;
using CareFinder.API.DTOs.Hospital;
using AutoMapper;
using CareFinder.API.Interfaces;

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
        public async Task<ActionResult<IEnumerable<GetHospitalDto>>> GetHospitals()
        {
            var hospitals = await _hospitalsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHospitalDto>>(hospitals);
            return Ok(records);
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHospitalDto>> GetHospital(int id)
        {
            var hospital = await _hospitalsRepository.GetDetails(id);

            if (hospital == null)
            {
                return NotFound();
            }
            var hospitalDto = _mapper.Map<GetHospitalDetailsDto>(hospital);
            return Ok(hospitalDto);
        }

        // PUT: api/Hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospital(int id, UpdateHospitalDto updateHospitalDto)
        {
            if (id != updateHospitalDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var hospital = await _hospitalsRepository.GetAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            _mapper.Map(updateHospitalDto, hospital);

            try
            {
                await _hospitalsRepository.UpdateAsync(hospital);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await HospitalExists(id))
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

        // POST: api/Hospitals
        [HttpPost]
        public async Task<ActionResult<Hospital>> PostHospital(CreateHospitalDto createHospital)
        {
            var hospital = _mapper.Map<Hospital>(createHospital);

            await _hospitalsRepository.AddAsync(hospital);

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital);
        }

        // DELETE: api/Hospitals/5
        [HttpDelete("{id}")]
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
