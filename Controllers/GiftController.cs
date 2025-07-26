using AutoMapper;
using final_project.BLL;
using final_project.Moddels;
using final_project.Moddels.DTO;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftServices _giftServices;
        private readonly IMapper _mapper;

        public GiftController(IGiftServices giftServices, IMapper mapper)
        {
            _giftServices = giftServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GiftDTO>>> GetAllGifts()
        {
            var gifts = await _giftServices.GetAllGifts();
            var giftDtos = _mapper.Map<List<GiftDTO>>(gifts);
            return Ok(giftDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiftDTO>> GetGiftById(int id)
        {
            var gift = await _giftServices.GetGiftById(id);
            if (gift == null)
            {
                return NotFound();
            }

            var giftDto = _mapper.Map<GiftDTO>(gift);
            return Ok(giftDto);
        }

        [HttpPost]
        public async Task<ActionResult<GiftDTO>> AddGift([FromBody] GiftDTO giftDto)
        {
            var giftToAdd = _mapper.Map<Gift>(giftDto);
            var addedGift = await _giftServices.AddGift(giftToAdd);

            var addedGiftDto = _mapper.Map<GiftDTO>(addedGift);
            return CreatedAtAction(nameof(GetGiftById), new { id = addedGift.Id }, addedGiftDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGift(int id, [FromBody] GiftDTO giftDto)
        {
            var existingGift = await _giftServices.GetGiftById(id);
            if (existingGift == null)
                return NotFound();
            _mapper.Map(giftDto, existingGift);

            await _giftServices.UpdateGift(existingGift);

            return NoContent();
        }
        [HttpGet("filter")] 
        public async Task<ActionResult<List<GiftDTO>>> FilteredGifts(
            [FromQuery] string? giftName,
            [FromQuery] string? donorName,
            [FromQuery] int? numBuyers)
        {
          var filteredGifts = await _giftServices.FilteredGifts(giftName,donorName,numBuyers);
          var giftDtos = _mapper.Map<List<GiftDTO>>(filteredGifts);
            return Ok(giftDtos); 
        }
    }
        }
