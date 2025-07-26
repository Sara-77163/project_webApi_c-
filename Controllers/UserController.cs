using AutoMapper;
using final_project.BLL;
using final_project.Moddels.DTO;
using final_project.Moddels;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
 
        [HttpGet] 
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _userServices.GetAllUser();
            var userDtos = _mapper.Map<List<UserDTO>>(users);
            return Ok(userDtos);
        }
        [HttpGet("{id}")] 
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userServices.GetUserById(id); 
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        [HttpPost] 
        public async Task<ActionResult<UserDTO>> AddUser( UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var addedUser = await _userServices.AddUser(user);
            var addedUserDto = _mapper.Map<UserDTO>(addedUser);
            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.Id }, addedUserDto);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
         

            
            var existingUser = await _userServices.GetUserById(id); 
            if (existingUser == null)
            {
                return NotFound(); 
            }
            _mapper.Map(userDto, existingUser);
            var updatedUser = await _userServices.UpdateUser(existingUser);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userServices.GetUserById(id); 
            if (userToDelete == null)
            {
                return NotFound(); 
            }
            await _userServices.DeleteUser(id);
            return NoContent(); 
        }
    }


}

