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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Map Dto to Domain Model
            var walkRepository = _mapper.Map<Walk>(addWalkRequestDTO);

          await  _walkRepository.CreateAsync(walkRepository);
         var result=   _mapper.Map<WalkDTO>(walkRepository);


            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _walkRepository.GetAllAsync();
            var walk = _mapper.Map<List<WalkDTO >> (result);
            return Ok(walk);
        }
        //api/walk/id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkRepository.GetWalkById(id);
            if (walk == null)
            {
                // it shows 4o4  error 
                return NotFound();
            }
            else
            {
               var result=  _mapper.Map<WalkDTO>(walk);
                return Ok(result);
            }

        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            var result= await _walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
