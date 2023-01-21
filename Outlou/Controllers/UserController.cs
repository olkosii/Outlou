using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Outlou.DataModels;
using Outlou.DomainModels;
using Outlou.Reposetories;
using System.Threading.Tasks;

namespace Outlou.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[controller]/Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userRequest)
        {
            var user = await _repository.LogIn(_mapper.Map<User>(userRequest));

            if (user != null) 
                return Ok(user);

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            var createdUser = await _repository.Register(_mapper.Map<User>(user));

            return Ok(createdUser);
        }
    }
}
