using AutoMapper;
using final_project.BLL;
using final_project.Moddels;
using final_project.Moddels.DTO;
using Microsoft.AspNetCore.Mvc;


namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorServices _donorServices;
        private readonly IMapper _mapper;
        public DonorController(IDonorServices donorServices, IMapper mapper)
        {
            _donorServices = donorServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<DonorDTO>>> GetAllDonor()
        {
            List<Donor> donors = await _donorServices.GetAllDonor();
            List<DonorDTO> donorDtos = _mapper.Map<List<DonorDTO>>(donors);
            return Ok(donorDtos);
        }
        [HttpGet("getById")]
        public async Task<ActionResult<DonorDTO>> GetDonorById(int id)
        {
            Donor? donor = await _donorServices.GetDonorByID(id);
            if (donor == null)
            {
                return NotFound();
            }
            DonorDTO donorDto = _mapper.Map<DonorDTO>(donor);
            return Ok(donorDto);
        }

        [HttpPost]
        public async Task<ActionResult<Donor>> AddDonor(DonorDTO donorDto)
        {
            Donor donorToAdd = _mapper.Map<Donor>(donorDto);
            Donor addedDonor = await _donorServices.AddDonor(donorToAdd);
            var addedDonorDto = _mapper.Map<DonorDTO>(addedDonor);
            return CreatedAtAction(nameof(GetDonorById), new { id = addedDonor.Id }, addedDonorDto);
        }
        [HttpPut]
        public async Task<ActionResult<DonorDTO>> UpdateDonor(DonorDTO donorDto, int id)
        {
                Donor? existingDonor = await _donorServices.GetDonorByID(id);
                if (existingDonor == null)
                {
                    return NotFound();
                }
                _mapper.Map(donorDto, existingDonor);
                var updatedDonor = await _donorServices.Updatedonor(existingDonor);
                var updatedDonorDto = _mapper.Map<DonorDTO>(updatedDonor);
                return Ok(updatedDonorDto); 
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonor(int id)
        {
            var donorToDelete = await _donorServices.GetDonorByID(id);
            if (donorToDelete == null)
            {
                return NotFound();
            }
            await _donorServices.DeleteDonor(id);
            return NoContent(); 

        }
        [HttpGet("filter")]

        public async Task<ActionResult<List<DonorDTO>>> GetFilteredDonors(
          [FromQuery] string? name,
          [FromQuery] string? email,
          [FromQuery] string? giftName)
        {
            var donors = await _donorServices.GetDonorsFiltered(name, email, giftName);
            var donorDtos = _mapper.Map<List<DonorDTO>>(donors);
            return Ok(donorDtos);

        }
    }

    }