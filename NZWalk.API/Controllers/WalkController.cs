using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.CustomActionfilters;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;
using System.Globalization;

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
        //Get:http://localhost:portnumber/api/walk/?filterOn=WalkName&filterQuery=Track&Sortby=Name&IsAscending=true

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? Sortby , [FromQuery] bool? IsAscending,
             [FromQuery] int PagerNumber = 1, [FromQuery] int Pagesize=1000)
        {
            var result = await _walkRepository.GetAsync(filterOn  ,filterQuery , Sortby , IsAscending??true,PagerNumber,Pagesize);
            var walkDto = _mapper.Map<List<WalkDTO>>(result);

            return Ok(walkDto);
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
                var result = _mapper.Map<WalkDTO>(walk);
                return Ok(result);
            }

        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            var result = await _walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if (result == null)
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
