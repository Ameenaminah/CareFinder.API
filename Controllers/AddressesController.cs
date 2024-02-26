using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareFinder.API.Data;
using CareFinder.API.Interfaces;
using AutoMapper;
using CareFinder.API.DTOs.Address;

namespace CareFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesRepository _addressesRepository;
        private readonly IMapper _mapper;

        public AddressesController(IAddressesRepository addressesRepository, IMapper mapper)
        {
            this._addressesRepository = addressesRepository;
            this._mapper = mapper;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses()
        {
            var addresses = await _addressesRepository.GetAllAsync();
            return Ok(_mapper.Map<List<AddressDto>>(addresses));
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddress(int id)
        {
            var address = await _addressesRepository.GetAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AddressDto>(address));
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressDto addressDto)
        {
            if (id != addressDto.Id)
            {
                return BadRequest();
            }

            var address = await _addressesRepository.GetAsync(id);
            if (address is null)
            {
                return NotFound();
            }
            _mapper.Map(addressDto, address);

            try
            {
                await _addressesRepository.UpdateAsync(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AddressExists(id))
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

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult> PostAddress(CreateAddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressesRepository.AddAsync(address);

            return CreatedAtAction("GetAddress", new { id = address.Id }, address.Id);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _addressesRepository.GetAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            await _addressesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AddressExists(int id)
        {
            return await _addressesRepository.Exists(id);
        }
    }
}
