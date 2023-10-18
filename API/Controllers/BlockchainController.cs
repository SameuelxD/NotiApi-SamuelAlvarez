using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BlockchainController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlockchainController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BlockchainDto>>> Get()
    {
        var blockchains = await _unitOfWork.Blockchains.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<BlockchainDto>>(blockchains);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Blockchain>> Post(BlockchainDto blockchainDto)
    {
        var blockchain = _mapper.Map<Blockchain>(blockchainDto);
        this._unitOfWork.Blockchains.Add(blockchain);
        await _unitOfWork.SaveAsync();
        if (blockchain == null)
        {
            return BadRequest();
        }
        blockchainDto.Id = blockchain.Id;
        return CreatedAtAction(nameof(Post), new { id = blockchainDto.Id }, blockchainDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BlockchainDto>> Get(int id)
    {
        var blockchain = await _unitOfWork.Blockchains.GetByIdAsync(id);
        if (blockchain == null){
            return NotFound();
        }
        return _mapper.Map<BlockchainDto>(blockchain);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlockchainDto>> Put(int id, [FromBody] BlockchainDto blockchainDto)
    {
        if (blockchainDto == null)
        {
            return NotFound();
        }
        var blockchains = _mapper.Map<Blockchain>(blockchainDto);
        _unitOfWork.Blockchains.Update(blockchains);
        await _unitOfWork.SaveAsync();
        return blockchainDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var blockchain = await _unitOfWork.Blockchains.GetByIdAsync(id);
        if (blockchain == null)
        {
            return NotFound();
        }
        _unitOfWork.Blockchains.Remove(blockchain);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}