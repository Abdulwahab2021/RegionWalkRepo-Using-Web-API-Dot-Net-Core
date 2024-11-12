using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.CustomActionfilters;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly NZWalkDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(NZWalkDbContext dbContext,IRegionRepository regionRepository,IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]

        //Get:http://localhost:portnumber/api/region
        public async Task<IActionResult> GetAll()
        {

         var RegionsDomainModel= await   _regionRepository.GetAllAsync();

            // var RegionsDomainModel= await _dbContext.Regions.ToListAsync();

            // var regionDto = new List<RegionShowDTO>();
            //foreach (var region in RegionsDomainModel)
            //{
            //    regionDto.Add(new RegionShowDTO()
            //    {
            //         Id= region.Id,
            //        Code = region.Code,
            //         RegionImageUrl = region.RegionImageUrl,
            //         RegionName = region.RegionName,
            //    });
            //}

            var regionDto =  _mapper.Map<List<RegionShowDTO>>(RegionsDomainModel);
            return Ok(regionDto);
        }

        //Get:http://localhost:portnumber/api/region/{id}
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute]  Guid id)
        {
            //var region = _dbContext.Regions.Find(id);
            var regionDomainModel = await _regionRepository.GetById(id);


            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // convert Domain model to DTO

            //var RegionDTO = new RegionShowDTO()
            //{
            //     Id= regionDomainModel.Id,
            //     Code = regionDomainModel.Code,
            //     RegionImageUrl = regionDomainModel.RegionImageUrl,
            //      RegionName = regionDomainModel.RegionName,

            //};

            var RegionDTO = _mapper.Map<RegionShowDTO>(regionDomainModel);
            return Ok(RegionDTO);
        }
        //POST:http://localhost:portnumber/api/region

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody]  AddRegionRequestDto addRegionRequestDto)
        {
            //var regionDomainModel = new Region()
            //{
            //    Code = addRegionRequestDto.Code,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            //    RegionName = addRegionRequestDto.RegionName

            //};

            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            regionDomainModel= await _regionRepository.CreateAsync(regionDomainModel);

            // Convert Domain Modal to DTO


            //var regionDto = new RegionShowDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //    RegionName = regionDomainModel.RegionName

            //};

            var regionDto=_mapper.Map<RegionShowDTO>(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }

        //Put:http://localhost:portnumber/api/region/{id}
        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public  async Task<IActionResult> UpdateRegion(Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            //convert to Dto to Domain Model

            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionDTO.Code,
            //    RegionImageUrl = updateRegionDTO.RegionImageUrl,
            //    RegionName = updateRegionDTO.RegionName
            //};

            var regionDomainModel = _mapper.Map<Region>(updateRegionDTO);


            var ExistingregionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if(ExistingregionDomainModel == null)
            {
                return NotFound();
            }
            else
            {
                // Convert DomainModel to DTO
                //var RegionShowDto = new RegionShowDTO
                //{
                //    Id = ExistingregionDomainModel.Id,
                //    Code = ExistingregionDomainModel.Code,
                //    RegionImageUrl = ExistingregionDomainModel.RegionImageUrl,
                //    RegionName = ExistingregionDomainModel.RegionName

                //};
                var RegionShowDto = _mapper.Map<RegionShowDTO>(ExistingregionDomainModel);
                return Ok(RegionShowDto);

            }
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteRegion(Guid id)
        {
           var regionDomainModel = await _regionRepository.DeleteRegion(id);




            // convert domain model to Dto

            //var RegionShowDto = new RegionShowDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl= regionDomainModel.RegionImageUrl,
            //    RegionName=regionDomainModel.RegionName

            //};

            var RegionShowDto = _mapper.Map<RegionShowDTO>(regionDomainModel);

            return Ok(RegionShowDto);

        }


    }
}
