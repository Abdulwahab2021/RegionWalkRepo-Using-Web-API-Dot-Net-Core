using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalkController(IMapper mapper,IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Map Dto to Domain Model
            var walkRepository = _mapper.Map<Walk>(addWalkRequestDTO);

          await  _walkRepository.CreateAsync(walkRepository);
         var result=   _mapper.Map<WalkDTO>(walkRepository);


            return Ok(result);
        }
    }
}
