using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoti.Controllers
{
    public class BlockChainController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BlockChainDto>>> Get()
        {
            var blockChains = await _unitOfWork.BlockChains.GetAllAsync();
            return _mapper.Map<List<BlockChainDto>>(blockChains);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDto>>Get(int id)
        {
            var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
            if(blockChain == null)
            {
                return NotFound();
            }
            return _mapper.Map<BlockChainDto>(blockChain);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlockChainDto>>Post(BlockChainDto blockChainDto)
        {
            var blockChain = _mapper.Map<BlockChain>(blockChainDto);

            if(blockChainDto.FechaCreacion == DateTime.MinValue)
            {
                blockChainDto.FechaCreacion = DateTime.Now; 
            }
            if(blockChainDto.FechaModificacion == DateTime.MinValue)
            {
                blockChainDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.BlockChains.Add(blockChain);
            await _unitOfWork.SaveAsync();
            
            if(blockChain == null)
            {
                return BadRequest();
            }
            blockChainDto.Id = blockChain.Id;
            return CreatedAtAction(nameof(Post), new {id = blockChainDto.Id}, blockChain);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDto>> Put(int id, [FromBody] BlockChainDto blockChainDto)
        {
            if(blockChainDto == null)
            {
                return NotFound();
            }
            var blockChains = _mapper.Map<BlockChain>(blockChainDto);
            _unitOfWork.BlockChains.Update(blockChains);
            await _unitOfWork.SaveAsync();
            return blockChainDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
            if(blockChain == null)
            {
                return NotFound();
            }
            _unitOfWork.BlockChains.Remove(blockChain);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}